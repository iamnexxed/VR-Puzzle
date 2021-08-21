using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : ObjectController
{
    public Collector collectorScript;
    
    private void Start()
    {
        base.Start();
        if(collectorScript == null)
        {
            collectorScript = FindObjectOfType<Collector>();
        }
        
    }

    public override void OnPointerClick()
    {
        base.OnPointerClick();

        Debug.Log("Clicked on : " + name);


        collectorScript.CollectCrystal();
        gameObject.SetActive(false);

    }

    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
    }
}
