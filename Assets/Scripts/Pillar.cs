using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : ObjectController
{
    public bool isActive = false;
    public GameObject crystalObject;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        ToggleCrystal();
    }


    public override void OnPointerClick()
    {
        base.OnPointerClick();
        ToggleCrystal();
    }

    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
    }

    public void ToggleCrystal()
    {
        crystalObject.SetActive(!crystalObject.activeInHierarchy);
    }
}
