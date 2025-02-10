using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Organ", menuName = "Joc/Organ", order = 1)]
public class OrganScriptable : ScriptableObject
{
    public string nom;                  // Nom de l'òrgan
    public bool recollit = false;       // Si l'òrgan ja ha estat recollit
    public Transform puntLocation;   // On s'ha de col·locar l'òrgan en la escena
    public GameObject modelOrgan;       // Model 3D de l'òrgan
}