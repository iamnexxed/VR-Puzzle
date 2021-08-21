// using UnityEditor.AI;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPuzzle : MonoBehaviour
{
    public int[] puzzleSolution = { 0, 0, 2, 1, 2, 1 };
    public int[] currentSequence;
    public Slider progression;

    bool isComplete = false;

    public GameObject elevatorBlock;

    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentSequence = new int[puzzleSolution.Length];
        ResetPuzzle();
        progression.maxValue = puzzleSolution.Length;
    }

    public void AddToCurrentSequence(int number)
    {
        if (isComplete)
            return;

        currentSequence[currentIndex] = number;

        if(currentSequence[currentIndex] != puzzleSolution[currentIndex])
        {
            ResetPuzzle();
            Debug.Log("Wrong Sequence");
            return;
        }

        progression.value = currentIndex + 1;

        if (currentSequence[puzzleSolution.Length - 1] == puzzleSolution[puzzleSolution.Length - 1])
        {
            PuzzleFinished();
            // ShowSequenceDebug();
            // Debug.Log("Puzzle Complete");
            return;
        }

        

        currentIndex++;
        // ShowSequenceDebug();
    }

    void ResetPuzzle()
    {
        for(int i = 0; i < currentSequence.Length; ++i)
        {
            currentSequence[i] = -1;
        }
        currentIndex = 0;

        isComplete = false;
        progression.value = 0;
    }

    void ShowSequenceDebug()
    {
        string seq = "";
        for(int i = 0; i < currentSequence.Length; ++i)
        {
            seq += " " + currentSequence[i];
        }
        Debug.Log("Current Sequence is : " + seq);
    }

    void PuzzleFinished()
    {
        isComplete = true;
        elevatorBlock.SetActive(false);
        // NavMeshBuilder.BuildNavMesh();
        // Debug.Log("NavMesh Syncing : " + NavMeshBuilder.isRunning);
    }
}
