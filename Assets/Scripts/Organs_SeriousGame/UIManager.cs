using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;

    private void Update()
    {
        scoreText.text = "Punts: " + ScoreManager.Instance.Score;
    }
}
