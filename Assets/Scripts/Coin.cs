using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectables
{
    public void Collect()
    {
        GameManager. gameManager.CoinCollected();
        Destroy(gameObject);
    }
}
