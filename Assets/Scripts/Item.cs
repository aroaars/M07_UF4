using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ICollectables
{

public int ID;
public Sprite Sprite;

public void Collect()
{
    GameManager.gameManager.ItemCollected(Sprite, ID);
    Destroy(gameObject);
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
