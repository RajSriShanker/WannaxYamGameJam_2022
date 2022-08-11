using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Range((int)0.1,1)]
    public float dashSpeed;

    public float dashTime;

    private Vector3 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        float startTime = Time.time;
        Vector3 playerDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        while (Time.time < startTime + dashTime)
        {
            transform.Translate(playerDirection * dashSpeed);

            yield return null;
        }
    }
}
