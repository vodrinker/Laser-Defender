using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] string shipPrefabTag;
    [SerializeField] float spawnInterval;
    [SerializeField] int shipsAmount;

    public string GetShipPrefab()
    {
        return shipPrefabTag;
    }

    public float GetSpawnInterval()
    {
        return spawnInterval;
    }

    public int GetShipsAmount()
    {
        return shipsAmount;
    }

    public float GetSummaryIntervals()
    {
        return spawnInterval * shipsAmount;
    }
}
