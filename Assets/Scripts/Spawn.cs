using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float waveInterval = 0;
    [SerializeField] List<WaveConfig> waveConfigs;
    private int waveIndex = 0;
    private WaveConfig currentWave;

    void Start()
    {
        currentWave = waveConfigs[waveIndex];
        StartCoroutine(SpawnWave(currentWave));
    }

    private IEnumerator SpawnWave(WaveConfig waveConfig)
    {
        //Debug.Log($"Wave: {waveIndex+1}/{waveConfigs.Count}");
        GameObject shipPrefab = waveConfig.GetShipPrefab();
        for (int shipsCounter = 0; shipsCounter < waveConfig.GetShipsAmount(); shipsCounter++)
        {
            StartCoroutine(SpawnShip(shipPrefab, waveConfig.GetSpawnInterval() * shipsCounter));
        }

        var timer = waveConfig.GetSummaryIntervals() + waveInterval;
        yield return new WaitForSeconds(timer);

        waveIndex = (waveIndex < waveConfigs.Count - 1) ? waveIndex + 1 : 0;
        currentWave = waveConfigs[waveIndex];
        StartCoroutine(SpawnWave(currentWave));
    }

    private IEnumerator SpawnShip(GameObject prefab, float interval)
    {
        yield return new WaitForSeconds(interval);
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}