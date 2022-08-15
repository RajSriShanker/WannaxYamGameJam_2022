using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeSystem : MonoBehaviour
{
    public ParticleSystem particleSystemScript;
    public float changeTime;

    // Start is called before the first frame update
    void Start()
    {
        particleSystemScript = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartColourChange()
    {
        StartCoroutine(ColourChange());
    }

    public IEnumerator ColourChange()
    {
        ParticleSystem.MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = Color.cyan;
        yield return new WaitForSeconds(changeTime);
        main.startColor = Color.red;
    }
}
