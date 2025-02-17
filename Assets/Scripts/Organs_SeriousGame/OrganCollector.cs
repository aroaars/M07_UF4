using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganCollector : MonoBehaviour
{
    public bool isCarryingOrgan = false;
    public Transform CarriedOrg;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Organ") && !isCarryingOrgan)
        {
            isCarryingOrgan = true;
            CarriedOrg = other.transform;
            other.gameObject.transform.parent = gameObject.transform; //fer null quan arribis on l'has d deixar
            Debug.Log("Òrgan recollit: " + other.name);
        }
    }
    public void LeaveOrgan()
    {
                    isCarryingOrgan = false;
            CarriedOrg.parent = null;
    }
}
