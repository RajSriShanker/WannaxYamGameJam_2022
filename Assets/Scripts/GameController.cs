using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    public PlayerRuneSelection playerRuneSelectionScript;

    AudioSource audioSource;
    public AudioClip runeMatch;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RuneMatch()
    {
        if (playerRuneSelectionScript.conveyorRune == playerRuneSelectionScript.playerRune)
        {
            Debug.Log("1 Point");
            audioSource.PlayOneShot(runeMatch);
        }
        else
        { 
            Debug.Log("Miss");
        }
    }
}
