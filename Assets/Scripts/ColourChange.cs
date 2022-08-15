using System.Collections;
using System.Collections.Generic;
using TheDeveloper.ColorChanger;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public PS_ColorChanger colorChangerScript;
    public ParticleSystem ps;
    public float changeTime = 2.5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartChange()
    {
        StartCoroutine(ColourChangeStart());
    }

    IEnumerator ColourChangeStart()
    {
        colorChangerScript.ChangeColor();
        yield return new WaitForSeconds(changeTime);
        colorChangerScript.ChangeColor();

    }
}
