using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganPlacement : MonoBehaviour
{
    public string correctOrganName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == correctOrganName)
        {
            Debug.Log("Òrgan col·locat correctament!");
            ScoreManager.Instance.AddPoints(2); // Afegeix punts
        }
        else
        {
            Debug.Log("Òrgan incorrecte!");
        }
    }
}
