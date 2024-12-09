using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI CoinText, OrbText;
    //public Image Item1, Item2;
    public static GameManager gameManager;
    public int Orbs = 0, Coins = 0;

    public void OrbCollected()
    {
        Orbs++;
        //OrbText.text =  "Orbs: " + Orbs;
    }
      public void CoinCollected(int i)
    {
        Coins+=i;
        CoinText.text = "Coins: " + Coins;
    }

    public void ItemCollected(Sprite sprite, int id)
    {
        //Item[id].sprite = sprite;
    }
    private void Awake()
    {
        if (GameManager.gameManager != null && GameManager.gameManager != this)
            Destroy (gameObject);
        else
        {
            GameManager.gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}