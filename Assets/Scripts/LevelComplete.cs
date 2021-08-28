using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public enum Levels
    {
        Level1,
        Level2
    }

    public Levels currentLevel = Levels.Level1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Level Complete");

            if(currentLevel == Levels.Level1)

            // Load next level
                SceneManager.LoadScene("Level2");
            else if(currentLevel == Levels.Level2)
            {
                // Show win screen
                Debug.Log("Level 2 Complete");
            }
        }
    }
}
