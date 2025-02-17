using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organ : MonoBehaviour
{
    public GameObject organRightPlace;

    public void DestroyComponent()
    {
        organRightPlace.SetActive(true);
        Destroy(gameObject);
    }
}
