using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public List<LightElement> connectedElements;

    // Start is called before the first frame update
    void Start()
    {
        connectedElements = new List<LightElement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Crystal"))
        {
            LightElement lightElement = other.GetComponent<LightElement>();
            if (lightElement)
            {
                if (!connectedElements.Contains((lightElement)) && lightElement.isSource)
                {
                    connectedElements.Add(lightElement);
                    
                }

                if (lightElement.isSource)
                    lightElement.AddToList(gameObject);
            }
            else
            {
                Crystal otherCrystal = other.GetComponent<Crystal>();
                if(otherCrystal)
                {
                    foreach(LightElement light in otherCrystal.connectedElements)
                    {
                        if(!connectedElements.Contains(light))
                        {
                            connectedElements.Add(light);
                        }
                    }
                        
                }
            }

           

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crystal"))
        {
            LightElement otherLightElement = other.GetComponent<LightElement>();
            if (otherLightElement)
            {
                if (connectedElements.Contains((otherLightElement)))
                    connectedElements.Remove(otherLightElement);

                if (otherLightElement.isSource)
                    otherLightElement.RemoveFromList(gameObject);
            }
            else
            {
                Crystal otherCrystal = other.GetComponent<Crystal>();
                if (otherCrystal)
                {
                    foreach (LightElement light in otherCrystal.connectedElements)
                    {
                        if (connectedElements.Contains(light))
                        {
                            connectedElements.Remove(light);
                        }
                    }

                }
            }
            
        }
    }

    public void AddCrystal(Crystal otherCrystal)
    {

    }

    public void DisconnectCrystal(LightElement removeElement)
    {
        if (connectedElements.Contains(removeElement))
            connectedElements.Remove(removeElement);
    }
}
