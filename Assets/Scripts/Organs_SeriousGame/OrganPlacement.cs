using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganPlacement : MonoBehaviour
{
    public string correctOrganName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            if (other.gameObject.GetComponent<OrganCollector>().CarriedOrg.name == correctOrganName)
            {
                Debug.Log("Organ collocat correctament!");
                var organC = other.GetComponent<OrganCollector>();

                organC.LeaveOrgan();

                Destroy(gameObject, 0.1f);

            }
            else
            {
                Debug.Log("Organ incorrecte!");
            }
        }

    }
}
