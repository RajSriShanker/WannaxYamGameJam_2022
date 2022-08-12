using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent (typeof (AudioSource))]
public class InstrumentVoice : MonoBehaviour
{
    AudioSource[] sources;

    public bool playing;

    // Start is called before the first frame update
    void Awake()
    {
        sources = GetComponents<AudioSource>();
    }

    public void PlayNote(Note note)
    {
        StartCoroutine(NewPedalTone(note.start, note.loop));
        playing = true;
    }

    public void StopNote()
    {
        sources[1].Stop();
        playing = false;
    }

    public void StopNote(float fadeLength)
    {
        StartCoroutine(FadeNote(fadeLength));
    }

    IEnumerator NewPedalTone(AudioClip start, AudioClip loop)
    {
        sources[0].volume = 1;
        sources[1].volume = 0;
        sources[0].PlayOneShot(start);
        sources[1].clip = loop;
        sources[1].Play();

        float elapsedTime = 0;
        float targetTime = 1;

        while(elapsedTime < targetTime)
        {
            sources[0].volume = 1-elapsedTime;
            sources[1].volume = elapsedTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        sources[0].volume = 0;
        sources[1].volume = 1;            
    }

    public IEnumerator FadeNote(float fadeTime)
    {
        float elapsedTime = 0;

        while(elapsedTime < fadeTime)
        {
            sources[1].volume = 1-elapsedTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        sources[1].volume = 0;
    }

}
