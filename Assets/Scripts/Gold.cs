using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    [SerializeField] private int gold = 0;
    [SerializeField] private Text text;

    public void AddGold(int newGold)
    {
        gold += newGold;
        FormatGold();
    }

    public int GetGold()
    {
        return gold;
    }

    public void SpendGold(int amount)
    {
        gold -= amount;
        FormatGold();
    }

    private void FormatGold()
    {
        text.text = gold.ToString("000 000 ");
    }
}
