using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NPC : MonoBehaviour
{
   public CinemachineVirtualCamera VCamDisable;
   public CinemachineVirtualCamera VCamEnable;
   public GameObject UI;
   private PlayerMover _playerMover;
   private bool _canBuy = true;
   private float time = 1f;
   public GameObject HUD;
   private void OnTriggerEnter(Collider other)
   {
     Debug.Log(other.gameObject.name);
     _playerMover = other.GetComponent<PlayerMover>();

     if(_canBuy)
     {
          VCamDisable.gameObject.SetActive(false);
          VCamEnable.gameObject.SetActive(true);
          Camera.main.GetComponent<CinemachineBrain>().enabled = true;
          Camera.main.cullingMask &= ~(1 << 8); //Treu la capa 8 per no veure ni poder moure al Player.
          _playerMover.canMove = false;
          _playerMover._moveDirection = Vector3.zero;
          UI.SetActive(true);
          HUD.SetActive(false);
          _canBuy = false;
     }
   }

   private void OnTriggerExit(Collider other)
   {
        StartCoroutine(WaitForABit());
   }

   public void ExitQuestions()
   {
        _playerMover.canMove = true;
        VCamDisable.gameObject.SetActive(true);
        VCamEnable.gameObject.SetActive(false);
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        Camera.main.cullingMask |= (1 << 8); //Tornar a afegir la capa 8. Player tornarà a la normalitat, i al cap d’un segon es podrà tornar a entrar.
        HUD.SetActive(true);
        UI.SetActive(false);
   }

   private IEnumerator WaitForABit()
   {
        yield return new WaitForSeconds(time);
        _canBuy = true;
   }




}