
using UnityEngine;
using UnityEngine.UI;

public class UIController : ObjectController
{

    public Text displayText;

    private void Start()
    {
        base.Start();

        if (displayText)
            displayText.gameObject.SetActive(false);
    }

    public enum ButtonName
    {
        Start,
        Instructions,
        Quit,
        None
    }

    public ButtonName buttonName;

    public override void OnPointerClick()
    {
        base.OnPointerClick();
        if (buttonName == ButtonName.Start)
            sceneCanvasManager.LoadLevel1();
        else if (buttonName == ButtonName.Quit)
        {
            Application.Quit();
        }
    }

    public override void OnPointerEnter()
    {
        base.OnPointerEnter();

        if (displayText)
            displayText.gameObject.SetActive(true);

        Debug.Log("Hovered on : " + name);

        if (sceneCanvasManager)
            sceneCanvasManager.SetDebugText("Hovered on : " + name);
        
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();

        if (displayText)
            displayText.gameObject.SetActive(false);

    }


}
