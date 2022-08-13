using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Drum : MusicInstrument
{
    public DrumHit[] samples;

    Dictionary<string, DrumHit> sampleDict = new Dictionary<string, DrumHit>();

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
        foreach(DrumHit sample in samples)
        {
            string name = sample.sample.name[0].ToString();
            Debug.Log(name);
            sampleDict.Add(name, sample);
        }
    }

    void PlaySample(string sample)
    {
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

    }


}

[Serializable]
public class DrumHit:Note
{
    public AudioClip sample;
}
