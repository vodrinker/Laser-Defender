using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private float waveInterval = 0;
    [SerializeField] List<WaveConfig> waveConfigs;
    private int shipIndex = 0;
    //private WaveConfig currentWave;
    public class shipSpawnInfo
    {
        public string tag;
        public WaitForSeconds time;
    }
    List<shipSpawnInfo> shipSpawnInfos = new List<shipSpawnInfo>();

    void Start()
    {
        //currentWave = waveConfigs[waveIndex];
        for (int i = 0; i < waveConfigs.Count; i++)
        {
            for (int j = 0; j < waveConfigs[i].GetShipsAmount(); j++)
            {
                float cooldown = waveConfigs[i].GetSpawnInterval();
                cooldown += (j == 0) ? waveInterval : 0;
                shipSpawnInfo temp = new shipSpawnInfo();
                temp.tag = waveConfigs[i].GetShipPrefab();
                temp.time = new WaitForSeconds(cooldown);
                shipSpawnInfos.Add(temp);
                //Debug.Log($"")
            }
        }
        StartCoroutine(SpawnShip());
    }

    private IEnumerator SpawnShip()
    {
        yield return shipSpawnInfos[shipIndex].time;
        ObjectPooler.instance.SpawnFromPool(shipSpawnInfos[shipIndex].tag, transform.position, Quaternion.identity);
        shipIndex++;
        if (shipIndex == shipSpawnInfos.Count - 1)
        {
            shipIndex = 0;
        }
        StartCoroutine(SpawnShip());
    }
}