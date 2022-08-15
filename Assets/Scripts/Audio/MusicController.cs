using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicController : MonoBehaviour
{
    MusicInstrument[] instruments;
    Drum drum;

    public List<Measure> gameMusic = new List<Measure>();

    public int currentMeasure;
    public int activeMeasure;

    TempoController tempoController;

    // Start is called before the first frame update
    void Start()
    {
        instruments = GetComponentsInChildren<MusicInstrument>();
        drum = GetComponentInChildren<Drum>();
        tempoController = transform.parent.GetComponent<TempoController>();
    }

    public void StepMusic(int beatCount)
    {
        if(gameMusic[currentMeasure].DrumHit[beatCount-1] > 0)
            drum.PlaySample(gameMusic[currentMeasure].DrumHit[beatCount-1]);

        if(tempoController.ringCount % 2 == 0)
        {
            if(gameMusic[currentMeasure].SynthNote[beatCount-1] > 0)
                instruments[1].PlayNote(GetNoteFromStep(gameMusic[currentMeasure].SynthNote[beatCount-1]));

            if(gameMusic[currentMeasure].PedalTone[beatCount-1] > 0)
                instruments[0].PlayNote(GetNoteFromStep(gameMusic[currentMeasure].PedalTone[beatCount-1]));
        }
        else
        {
            instruments[1].StopNotes();
            instruments[0].StopNotes();
        }

        
        activeMeasure = currentMeasure;
    }

    string GetNoteFromStep(int step)
    {
        switch(step)
        {
            case 1:
                return "A";
            case 2:
                return "B";
            case 3:
                return "C";
            case 4:
                return "D";
            case 5:
                return "E";
            case 6:
                return "F";
            case 7:
                return "G";
            case 8:
                return "A";

        }
        return null;
    }

}

[Serializable]
public class Measure
{
    public List<int> PedalTone = new List<int>(4);
    public List<int> SynthNote = new List<int>(4);
    public List<int> DrumHit = new List<int>(4);
}
