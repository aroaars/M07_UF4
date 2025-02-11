using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Organ", menuName = "OrganCollectable", order = 1)]
public class OrganCollectable : ScriptableObject
{
    public string nom;                  // Nom de l'òrgan
    public bool recollit = false;       // Si l'òrgan ja ha estat recollit
    public Transform puntPut;   // On s'ha de col·locar l'òrgan en la escena
    public GameObject modelOrgan;       // Model 3D de l'òrgan
}