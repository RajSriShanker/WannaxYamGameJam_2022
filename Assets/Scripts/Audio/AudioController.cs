using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class AudioController : MonoBehaviour
{
    public AudioMixer mainMixer;

    public bool performanceSaver;

    public bool sfxMuted;
    public bool musicMuted;

    public void SetMusicLevel(float value)
    {
        mainMixer.SetFloat("musicVol", value);

        if(value == -80 && performanceSaver)
            musicMuted = true;

        if(value > -80 && performanceSaver && musicMuted)
            musicMuted = false;
    }

    public void SetSFXLevel(float value)
    {
        mainMixer.SetFloat("sfxVol", value);

        if(value == -80 && performanceSaver)
            sfxMuted = true;

        if(value > -80 && performanceSaver && sfxMuted)
            sfxMuted = false;
    }
}
