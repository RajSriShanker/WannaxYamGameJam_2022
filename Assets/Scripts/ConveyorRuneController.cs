using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorRuneController : MonoBehaviour
{
    private Vector3 startingPosition;
    public Transform endPoint;
    private float elapsedTime;
    public float desiredDuration;

    [SerializeField]
    private AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        endPoint = GameObject.Find("Conveyor End Point").transform;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;

        transform.position = Vector3.Lerp(startingPosition, endPoint.position, curve.Evaluate(percentageComplete));


        if (gameObject.transform.position == endPoint.transform.position)
        { 
            Destroy(gameObject);
        }
    }
}
