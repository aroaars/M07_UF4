using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if(player != null)
            transform.position = player.transform.position;
    }
    public void DestroyComponent()
    {
        Destroy(this);
    }
}
