using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickOrgans : MonoBehaviour
{
    public GameObject organ;
    private bool agafant = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Organ"))
        {
            agafant = true;
            organ = other.gameObject; // Assigna l'òrgans que es toca
        }
    }

    void Update()
    {
        if (agafant && Input.GetKeyDown(KeyCode.E)) // Per exemple, tecla "E" per agafar l'òrgan
        {
            agafarOrgan();
        }
    }

    void agafarOrgan()
    {
        if (organ != null)
        {
            organ.transform.SetParent(this.transform); // Assigna l'òrgan al personatge
            organ.transform.localPosition = Vector3.zero; // Col·loca l'òrgan a l'interior del personatge
            organ.GetComponent<Collider>().enabled = false; // Desactiva el collider per evitar més interaccions
        }
    }
}
