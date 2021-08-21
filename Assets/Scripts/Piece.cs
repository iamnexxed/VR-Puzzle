using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int colorNum = 0;

    public Material defaultMat;
    public Material highlightMat;

    MeshRenderer meshRenderer;

    ButtonPuzzle puzzle;

    private void Start()
    {
        puzzle = FindObjectOfType<ButtonPuzzle>();
        if(puzzle == null)
        {
            Debug.LogWarning("Puzzle Script not found!");
        }

        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = defaultMat;
    }

    public void OnPointerEnter()
    {
        
    }

    public void OnPointerExit()
    {
        meshRenderer.material = defaultMat;
    }

    public void OnPointerClick()
    {
        // Set Material
        puzzle.AddToCurrentSequence(colorNum);
        meshRenderer.material = highlightMat;
    }

    
}
