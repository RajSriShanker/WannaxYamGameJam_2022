using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoController : MonoBehaviour
{
    public static bool checkTempo;
    public static bool countingBeats;

    public static int beatNumber;
    public float beatCount;

    public static int currentSubdivision;

    Coroutine subCount;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            BellToll();
    }

    public static void ChangeTempo()
    {
        //this is assuming that the check tempo is being called on a rune success rather than a new rune appearing
        //change to 1 if it's on a new rune I guess
        beatNumber = 0;
        checkTempo = true;
    }

    public void BellToll()
    {
        currentSubdivision = 1;
        beatNumber++;
        Debug.Log("Ding!");

        ProcessBeat();
        Debug.Log("Beat Number = " + beatNumber);
        
        if(subCount != null)
            StopCoroutine(subCount);
        subCount = StartCoroutine(SubdivideBeat());
        
        StartCoroutine(CountBeats());
    }

    void ProcessBeat()
    {
        if (beatNumber > 2)
            beatNumber = 1;

        if (beatNumber == 1 && !countingBeats)
        {
            countingBeats = true;
        }
    }

    IEnumerator CountBeats()
    {
        float newTempo = 0;
        while (countingBeats && beatNumber == 1)
        {
            newTempo += Time.deltaTime;
            yield return null;
        }
        beatCount = newTempo;
        countingBeats = false;
    }

    IEnumerator SubdivideBeat()
    {
        float elapsedTime = 0;
        currentSubdivision = 1;
        while (elapsedTime < beatCount)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > (beatCount * (.25 * currentSubdivision)))
            {
                int newBeat = currentSubdivision + 1;
                if (newBeat == 5)
                    newBeat = 4;
                currentSubdivision = newBeat;
            }
            yield return null;
        }
    }
}
