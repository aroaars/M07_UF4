using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveOrgan : MonoBehaviour
{
    public Organ organ;  // Referència a l'òrgan ScriptableObject

    void Update()
    {
        // Comprova si l'òrgan està a prop del lloc de col·locació i si el jugador prem una tecla
        if (Vector3.Distance(transform.position, organ.puntLeave.position) < 1f && Input.GetKeyDown(KeyCode.X))
        {
            PutOrgan();
        }
    }

    void LeaveOrgan()
    {
        if (organ.recollit)
        {
            // Col·loca l'òrgan en el lloc definit
            transform.position = organ.puntLeave.position;
            Debug.Log(organ.nom + " Col·locat!");
        }
    }
}
