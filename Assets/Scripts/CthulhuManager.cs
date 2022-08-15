using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CthulhuManager : MonoBehaviour
{

    public Transform endpoint;
    public Transform target;
    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float lookAtSpeed;

    private float elapsedTime;

    public float desiredDuration = 5f;

    private float percentageComplete;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        percentageComplete = elapsedTime / desiredDuration;

        Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
        transform.LookAt(targetPosition);

    }

    public void DeadHead()
    {
        transform.position = Vector3.Lerp(transform.position, endpoint.position, percentageComplete);
    }

    public void EvilWins()
    {

    }
}
