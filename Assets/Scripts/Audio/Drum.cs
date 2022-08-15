using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Drum : MusicInstrument
{
    public DrumHit[] samples;

    Dictionary<int, DrumHit> sampleDict = new Dictionary<int, DrumHit>();

    // Start is called before the first frame update
    override public void Start()
    {
        LoadSamples();  
        base.LoadVoices(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadSamples()
    {
        for(int i = 0; i < samples.Length; i++)
        {
            sampleDict.Add(i, samples[i]);
        }
    }

    public void PlaySample(int sample)
    {
        voices[0].PlaySample(sampleDict[sample]);

        /*
        for(int i = 0; i < voices.Length; i++)
        {
            if(!voices[i].playing)
            {
                voices[i].PlaySample(sampleDict[sample]);
                lastVoicePlayed = i;
                break;
            }
        }

        if(lastVoicePlayed == 0)
            voices[voices.Length - 1].PlayNote(sampleDict[sample]);
        else
            voices[lastVoicePlayed - 1].PlayNote(sampleDict[sample]);

            */

    }


}

[Serializable]
public class DrumHit:Note
{
    public AudioClip sample;
}
