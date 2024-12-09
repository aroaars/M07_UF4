using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour, ICollectables
{
    public void Collect()
    {
        GameManager.gameManager.OrbCollected();
        Destroy(gameObject);
    }
}    
