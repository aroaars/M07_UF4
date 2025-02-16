using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class SeriousGame : MonoBehaviour
{
    public CinemachineVirtualCamera VCamDisable;
    public CinemachineVirtualCamera VCamEnable;
    public GameObject UI;
    private PlayerMover _playerMover;
    private bool _canBuy = true;
    public GameObject HUD;
    private void OnTriggerEnter(Collider other)
    {
        
        _playerMover = other.GetComponent<PlayerMover>();

        if (_canBuy)
        {
            VCamDisable.gameObject.SetActive(false);
            VCamEnable.gameObject.SetActive(true);
            Camera.main.GetComponent<CinemachineBrain>().enabled = true;
            Camera.main.cullingMask &= ~(1 << 9); //Treu la capa 9 per no veure ni poder moure al Player.
            _playerMover.canMove = true;
            _playerMover._moveDirection = Vector3.zero;
            UI.SetActive(true);
            HUD.SetActive(false);
            _canBuy = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _playerMover.canMove = true;
        VCamDisable.gameObject.SetActive(true);
        VCamEnable.gameObject.SetActive(false);
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        Camera.main.cullingMask |= (1 << 9); //Tornar a afegir la capa 9. Player tornarà a la normalitat, i al cap d’un segon es podrà tornar a entrar.
        HUD.SetActive(true);
        UI.SetActive(false);
    }


  
}