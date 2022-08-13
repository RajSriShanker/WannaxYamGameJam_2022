using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicInstrument : MonoBehaviour
{
    public Note[] notes;
    Dictionary<string, Note> noteDict = new Dictionary<string, Note>();

    public InstrumentVoice[] voices;

    public int lastVoicePlayed;

    public bool isDrum;
    
    // Start is called before the first frame update
    virtual public void Start()
    {
        LoadVoices();
        LoadNotes();
    }

    void LoadNotes()
    {
        foreach(Note note in notes)
        {
            string name = note.start.name[0].ToString();
            Debug.Log(name);
            noteDict.Add(name, note);
        }
    }

    public void LoadVoices()
    {
        voices = GetComponentsInChildren<InstrumentVoice>();
    }

    void PlayNote(string note)
    {
        for(int i = 0; i < voices.Length; i++)
        {
            if(!voices[i].playing)
            {
                voices[i].PlayNote(noteDict[note]);
                lastVoicePlayed = i;
                break;
            }
        }

        if(lastVoicePlayed == 0)
            voices[voices.Length - 1].PlayNote(noteDict[note]);
        else
            voices[lastVoicePlayed - 1].PlayNote(noteDict[note]);

    }
}

[Serializable]
public class Note
{
        public AudioClip start;
        public AudioClip loop;
}