using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int Score => score; // Propietat per accedir a la puntuació

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Punts: " + score);
    }
}