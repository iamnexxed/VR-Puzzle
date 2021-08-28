using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightElement : MonoBehaviour
{
    public bool isSource = true;

    public LightPuzzle.LightColors sourceColor;

    public List<GameObject> connectedObjects;

    public GameObject finalObject;

    public bool isPathComplete = false;

    LineRenderer lineRenderer;

    private void Start()
    {
        if (!isSource)
            return;
        lineRenderer = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        // DrawLine();
    }

    public void ClearConnectedElements()
    {
        connectedObjects.Clear();
    }

    public void AddToList(GameObject newObject)
    {
        if (!isSource || isPathComplete)
            return;

        if(!connectedObjects.Contains(newObject))
        {
            connectedObjects.Add(newObject);
            CheckFinalConnection();
        }
        DrawLine();
    }

    public void RemoveFromList(GameObject newObject)
    {
        if (!isSource)
            return;

        if (connectedObjects.Contains(newObject))
        {
            for(int i = connectedObjects.IndexOf(newObject); i < connectedObjects.Count; i++)
            {
                connectedObjects.Remove(connectedObjects[i]);
                //if(connectedObjects[i].GetComponent<Crystal>())
                //{
                //    connectedObjects[i].GetComponent<Crystal>().DisconnectCrystal(this);
                //}
            }
                
        }
        DrawLine();
    }

    public void CheckFinalConnection()
    {
        if (!isSource)
            return;

        foreach (GameObject element in connectedObjects)
        {
            if(element.GetComponent<LightElement>())
            {
                if(element.GetComponent<LightElement>().sourceColor == sourceColor)
                {
                    if (!element.GetComponent<LightElement>().isSource)
                    {
                        Debug.Log("Path Found!");
                        isPathComplete = true;
                        break;
                    }
                }    
                
            }
        }
    }


    void DrawLine()
    {
        if (connectedObjects.Count <= 0)
            return;

        lineRenderer.positionCount = connectedObjects.Count + 1;
        lineRenderer.SetPosition(0, transform.position);
        for(int i = 1; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, connectedObjects[i - 1].transform.position);
        }
    }

    public void LaserComplete()
    {
        isPathComplete = true;
        connectedObjects.Add(finalObject);
        DrawLine();
    }
   
}
