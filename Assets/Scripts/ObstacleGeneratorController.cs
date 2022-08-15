using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Audio;

public class ObstacleGeneratorController : MonoBehaviour
{
    public GameObject[] obstacles;
    public float waitTime;

    public AudioClip tentacleUp;

    private Vector3 randomSpawnPosition;

    [Header("Spawn Position Parameters")]
    [SerializeField] private float MinXPosition = -9f;
    [SerializeField] private float MaxXPosition = 9;
    [SerializeField] private float MinZPosition = -4f;
    [SerializeField] private float MaxZPosition = 4;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObstacleTentacleSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        randomSpawnPosition = new Vector3(Random.Range(MinXPosition, MaxXPosition), -2.41f, Random.Range(MinZPosition,MaxZPosition));
    }

    private IEnumerator ObstacleTentacleSpawn()
    {
        yield return new WaitForSeconds(waitTime);
        int randomNumber = Random.Range(0, obstacles.Length - 1);
        Instantiate(obstacles[randomNumber], randomSpawnPosition, obstacles[randomNumber].transform.rotation);

        //newObstacle.GetComponent<AudioSource>().PlayOneShot(tentacleUp,.5f);
        StartCoroutine(ObstacleTentacleSpawn());
    }
}
