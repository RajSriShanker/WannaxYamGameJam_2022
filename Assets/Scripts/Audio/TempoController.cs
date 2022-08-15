using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TempoController : MonoBehaviour
{
    public static bool checkTempo;
    public static bool countingBeats;

    public static int beatNumber;
    public float beatCount;

    public int currentSubdivision;

    Coroutine subCount;

    AudioSource audioSource;
    public AudioClip bellClip;

    public int ringCount;

    MusicController musicController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicController = GetComponentInChildren<MusicController>();
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
        beatNumber++;
        ringCount++;

        audioSource.PlayOneShot(bellClip);

        ProcessBeat();
        
        if(subCount != null)
            StopCoroutine(subCount);

        if(beatCount != 0)
            subCount = StartCoroutine(SubdivideBeat());
        
        if(beatCount == 0)
            StartCoroutine(CountBeats());

        if(ringCount % 4 == 0 && musicController.currentMeasure != musicController.gameMusic.Count - 1)
        {
            musicController.currentMeasure++;
        }
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
        musicController.StepMusic(currentSubdivision);

        while (elapsedTime < beatCount)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > (beatCount * (.25 * currentSubdivision)))
            {
                int newBeat = currentSubdivision + 1;
                if (newBeat == 5)
                    newBeat = 4;
                currentSubdivision = newBeat;
                musicController.StepMusic(currentSubdivision);
            }
            yield return null;
        }
    }
}
