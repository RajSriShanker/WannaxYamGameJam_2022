using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageParticleController : MonoBehaviour
{
    private ParticleSystem afterImageParticleSystem;
    public float emittingTime;

    private void Awake()
    {
        afterImageParticleSystem = GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        afterImageParticleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(StartParticleSystem());
        }
    }

    IEnumerator StartParticleSystem()
    {
        afterImageParticleSystem.Play();
        yield return new WaitForSeconds(emittingTime);
        afterImageParticleSystem.Stop();
    }
}
