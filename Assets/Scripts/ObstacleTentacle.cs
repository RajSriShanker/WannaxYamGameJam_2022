using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTentacle : MonoBehaviour
{
    private Vector3 startingPosition;
    [SerializeField]
    private Vector3 endPosition;
    public float desiredDuration = 2f;
    private float elapsedTime;
    public float deathTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        Destroy(gameObject,deathTime);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        //float percentageComplete = elapsedTime / desiredDuration;

        transform.position = Vector3.Lerp(startingPosition, new Vector3(startingPosition.x, endPosition.y,startingPosition.z), Mathf.PingPong(elapsedTime, desiredDuration));
    }
}
