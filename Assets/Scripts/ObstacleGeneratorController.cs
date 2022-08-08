using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneratorController : MonoBehaviour
{
    public GameObject obstacle;
    public float waitTime;

    private Vector3 randomSpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ObstacleTentacleSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        randomSpawnPosition = new Vector3(Random.Range(-9, 9), obstacle.transform.position.y, Random.Range(-4,4));
    }

    private IEnumerator ObstacleTentacleSpawn()
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(obstacle, randomSpawnPosition, Quaternion.identity);
        StartCoroutine("ObstacleTentacleSpawn");
    }
}
