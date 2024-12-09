using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //public TextMeshProUGUI CoinText, OrbText;
    //public Image Item1, Item 2, Item 3, Item 4;
    public static GameManager gameManager;
    public int Orbs = 0, Coins = 0;

    public void OrbCollected()
    {
        Orbs++;
        //OrbText.text =  "Orbs: " + Orbs;
    }
      public void CoinCollected()
    {
        Coins++;
        //CoinText.text = "coins: " + Coins;
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