using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    private Text text;

    private void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        text.text = score.ToString("000 000 ");
    }
}
