using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleManager : MonoBehaviour
{
    public int score;
    public GameManager gameManager;

    void Awake()
    {
        gameManager = GetComponentInParent<GameManager>();
    }

    public void UpdateScore()
    {
        gameManager.Scoring(score);
    }
}
