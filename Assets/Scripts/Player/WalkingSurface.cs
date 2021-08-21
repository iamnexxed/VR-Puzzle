
using UnityEngine;

public class WalkingSurface : MonoBehaviour
{
    PlayerController playerController;
    CameraPointer cameraPointer;

    

    bool showGUI = false;
    // Start is called before the first frame update
    void Start()
    {

        // NavMeshBuilder.BuildNavMesh();
        playerController = FindObjectOfType<PlayerController>();
        if(!playerController)
        {
            Debug.Log("Player Controller Not FOUND!");
        }
        cameraPointer = FindObjectOfType<CameraPointer>();
        if(!cameraPointer)
        {
            Debug.Log("Camera Pointer Not FOUND!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        showGUI = true;
    }

    public void OnPointerExit()
    {
        showGUI = false;
    }

    public void OnPointerClick()
    {
        // Debug.Log("On Pointer Click : " + name + " Move to Position : " + cameraPointer.gazedObjectPosition);
        playerController.MoveTo(cameraPointer.gazedObjectPosition);
    }

    private void OnGUI()
    {
        if(showGUI)
            GUI.Label(new Rect(10, 10, 1000, 40), name);
    }
}
