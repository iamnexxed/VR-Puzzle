using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Collector : MonoBehaviour
{
    public int crystals = 0;
    public Text crystalTextCounter;

    // Start is called before the first frame update
    void Start()
    {
        ResetCollector();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectCrystal()
    {
        crystals++;
        UpdateCrystalText();
    }

    public void PlaceCrystal()
    {
        crystals--;
        if(crystals <= 0)
        {
            crystals = 0;
        }
        UpdateCrystalText();
    }

    public void ResetCollector()
    {
        crystals = 0;
        UpdateCrystalText();
    }

    void UpdateCrystalText()
    {
        if(crystalTextCounter)
        {
            crystalTextCounter.text = "x " + crystals;
        }
    }


}
