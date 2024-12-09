using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Seller : MonoBehaviour
{
   public CinemachineVirtualCamera VCamDisable;
   public CinemachineVirtualCamera VCamEnable;
   public GameObject UI;
   private PlayerMover _playerMover;
   private bool _canBuy = true;
   private float time = 1f;

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
          UI.SetActive(true);
          _canBuy = false;
     }
   }

   private void OnTriggerExit(Collider other)
   {
        StartCoroutine(WaitForABit());
   }

   public void ExitStore()
   {
        _playerMover.canMove = true;
        VCamDisable.gameObject.SetActive(true);
        VCamEnable.gameObject.SetActive(false);
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        Camera.main.cullingMask |= (1 << 8); //Tornar a afegir la capa 8. Player tornarà a la normalitat, i al cap d’un segon es podrà tornar a entrar.
        UI.SetActive(true);
   }

   private IEnumerator WaitForABit()
   {
        yield return new WaitForSeconds(time);
        _canBuy = true;
   }




}
