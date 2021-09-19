using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : ObjectController
{
    public bool isActive = false;
    public GameObject crystalObject;

    public Collector playerCollector;

    // public LightPuzzle.LightColors pillarColor;

   

    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        isActive = false;
        crystalObject.SetActive(isActive);

        if (!playerCollector)
        {
            playerCollector = FindObjectOfType<Collector>();
        }
    }


    public override void OnPointerClick()
    {
        base.OnPointerClick();
        ToggleCrystal();
    }

    public override void OnPointerEnter()
    {
        if(playerCollector.crystals > 0 || isActive)
        {
            canHighlight = true;
        }
        else
        {
            canHighlight = false;
        }
        base.OnPointerEnter();
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
    }

    public void ToggleCrystal()
    {
        if(isActive)
        {
            playerCollector.CollectCrystal();
            isActive = false;
        }
        else
        {
            if(playerCollector.crystals > 0)
            {
                isActive = true;
                playerCollector.PlaceCrystal();
            }
                
        }
        
        crystalObject.SetActive(isActive);
    }


    private void OnTriggerEnter(Collider other)
    {
       
    }
}
