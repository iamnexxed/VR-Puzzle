using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzle : MonoBehaviour
{
    public enum LightColors
    {
        None,
        Green
    }

    public Pillar[] pillars;

    public List<LightElement> lightSources;

    // Start is called before the first frame update
    void Start()
    {
        // puzzleSet = new GameObject[pillars.Length + 1];
    }

    // Update is called once per frame
    void Update()
    {
        foreach(LightElement lightElement in lightSources)
        {
            //if (lightElement.isPathComplete)
            //    continue;

            bool isComplete = true;
            foreach(Pillar pillar in pillars)
            {
                if(pillar.isActive)
                {
                    // if(Physics.Linecast(pillar.transform.GetChild(0).position, li))
                    lightElement.AddToList(pillar.transform.GetChild(0).gameObject);
                }
                else
                {
                    lightElement.RemoveFromList(pillar.transform.GetChild(0).gameObject);
                    isComplete = false;
                }
            }
            if(isComplete)
            {
                // Debug.Log("Puzzle Complete");
                lightElement.LaserComplete();
            }
        }
    }


}
