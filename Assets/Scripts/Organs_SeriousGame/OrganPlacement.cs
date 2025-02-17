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
            if (other.gameObject.name == correctOrganName)
            {
                Debug.Log("�rgan col�locat correctament!");
                other.GetComponent<OrganCollector>().LeaveOrgan();
                Destroy(other.gameObject);

            }
            else
            {
                Debug.Log("�rgan incorrecte!");
            }
        }

    }
}
