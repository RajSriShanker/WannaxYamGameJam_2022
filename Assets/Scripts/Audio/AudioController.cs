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

    public void SetMusicLevel(System.Single value)
    {
        value = -20f * (1 - value);
        mainMixer.SetFloat("musicVol", value);

        if(value == -80 && performanceSaver)
            musicMuted = true;

        if(value > -80 && performanceSaver && musicMuted)
            musicMuted = false;
    }

    public void SetSFXLevel(System.Single value)
    {
        value = -20f * (1 - value);
        mainMixer.SetFloat("sfxVol", value);

        if(value == -80 && performanceSaver)
            sfxMuted = true;

        if(value > -80 && performanceSaver && sfxMuted)
            sfxMuted = false;
    }
}
