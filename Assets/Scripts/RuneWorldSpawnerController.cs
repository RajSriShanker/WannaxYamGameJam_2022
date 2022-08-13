using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RuneWorldSpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject RunePrefab;
    
    [SerializeField] private float spawnIntervalTime = 2f;
    [SerializeField] private float RuneLifetime = 6f;
    [SerializeField] private int TotalRuneCapacity = 8;

    [Header("Spawn Position Parameters")] 
    [SerializeField] private float MinXPosition = -9f;
    [SerializeField] private float MaxXPosition = 9;
    [SerializeField] private float MinZPosition = -4f;
    [SerializeField] private float MaxZPosition = 4;
    [SerializeField] private float MinDistanceBetweenRunes = 2f;

    private float _spawnTimer = 0f;

    private List<Tuple<Transform, float>> _spawnedRunesList = new();
    private void Update()
    {
        // Spawn a new Rune if spawn interval cycle is ready, else increment the spawn timer
        if (_spawnTimer > spawnIntervalTime)
        {
            SpawnRune();
            _spawnTimer = 0f;
        }
        else if (_spawnedRunesList.Count < TotalRuneCapacity)
        {
            _spawnTimer += Time.deltaTime;
        }

        // Check if the oldest Rune in the scene needs to be destroyed
        if (_spawnedRunesList.Count > 0 && _spawnedRunesList.First().Item2 > RuneLifetime)
        {
            DestroyExpiredRune();
        }
        
        // Increment the lifetime timer of each spawned Rune in the scene
        for (int i = 0; i < _spawnedRunesList.Count; i++)
        {
            if (_spawnedRunesList[i].Item1 == null)
            {
                _spawnedRunesList.RemoveAt(i);
                continue;
            }
            _spawnedRunesList[i] = new Tuple<Transform, float>(_spawnedRunesList[i].Item1, _spawnedRunesList[i].Item2 + Time.deltaTime);
        }
    }

    private void SpawnRune()
    {
        Vector3 spawnPosition;
        bool isSpawnPositionValid = true;
        
        // Generate a spawn position that is not too close to another spawned Rune
        do
        {
            spawnPosition = new Vector3(Random.Range(MinXPosition, MaxXPosition), RunePrefab.transform.position.y, Random.Range(MinZPosition, MaxZPosition));
            isSpawnPositionValid = true;
            foreach (var rune in _spawnedRunesList)
            {
                if (Vector3.Distance(spawnPosition, rune.Item1.position) < MinDistanceBetweenRunes)
                {
                    isSpawnPositionValid = false;
                    break;
                }
            }
        } while (!isSpawnPositionValid);
        
        // Spawn a new Rune
        var runeInstance = Instantiate(RunePrefab, transform).transform;
        runeInstance.position = spawnPosition; // TODO @RAJ - This is the rune's spawn position
        _spawnedRunesList.Add(new Tuple<Transform, float>(runeInstance, 0f));
    }

    private void DestroyExpiredRune()
    {
        var expiredRune = _spawnedRunesList.First();
        Destroy(expiredRune.Item1.gameObject);
        _spawnedRunesList.RemoveAt(0);
    }
}
