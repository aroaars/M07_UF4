using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganCollector : MonoBehaviour
{
    public bool isCarryingOrgan = false;
    public GameObject CarriedOrg;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Organ") && !isCarryingOrgan)
        {
            isCarryingOrgan = true;
            CarriedOrg = other.gameObject;
            other.gameObject.transform.parent = gameObject.transform; //fer null quan arribis on l'has d deixar
            Debug.Log("Òrgan recollit: " + other.name);
        }
    }
    public void LeaveOrgan()
    {
                    isCarryingOrgan = false;
            var organ = CarriedOrg.GetComponent<Organ>();
            CarriedOrg.transform.parent = null;
            CarriedOrg.tag= "Untagged";
                        organ.DestroyComponent();

    }
}
