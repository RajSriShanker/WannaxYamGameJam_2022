using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    MusicInstrument[] instruments;

    // Start is called before the first frame update
    void Start()
    {
        instruments = GetComponentsInChildren<MusicInstrument>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
