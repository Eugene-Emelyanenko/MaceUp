using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private Transform[] targetSpawnPoints;
    [SerializeField] private Transform[] coinSpawnPoints;

    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private GameObject coinPrefab;

    private void Start()
    {
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        int rand = Random.Range(0, targetSpawnPoints.Length);
        Instantiate(targetPrefab, targetSpawnPoints[rand].position, Quaternion.identity);
        Instantiate(coinPrefab, coinSpawnPoints[rand].position, Quaternion.identity);
    }
}
