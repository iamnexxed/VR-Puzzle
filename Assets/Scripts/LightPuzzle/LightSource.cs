using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{
    public List<GameObject> linkedObjects;

    public LineRenderer lineRenderer;

    public Link link;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Pillar pillar = other.GetComponent<Pillar>();

        if (other.CompareTag("Pillar"))
        {
            if(pillar.isActive)
            {
                AddToList(other.gameObject);
                
            }
            else
            {
                RemoveFromList(other.gameObject);
            }
        }
    }


    void AddToList(GameObject newObject)
    {
        if(!linkedObjects.Contains(newObject))
        {
            linkedObjects.Add(newObject);
            if(linkedObjects.IndexOf(newObject) == 0)
                link.Next = newObject;

            CheckEnd();
        }
    }

    void RemoveFromList(GameObject getObject)
    {
        if (linkedObjects.Contains(getObject))
        {
            
            linkedObjects.Remove(getObject);
        }
    }

    void CheckEnd()
    {
        Link pointer = link;
        while(pointer)
        {
            if(pointer.Next == null)
            {
                if(pointer.GetComponent<LightButton>())
                {
                    Debug.Log("Path Complete");
                }
            }
            pointer = pointer.Next.GetComponent<Link>();
        }
    }
}
