using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartGame : MonoBehaviour
{

    public CinemachineVirtualCamera VCamDisable;
    public CinemachineVirtualCamera VCamEnable;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            Debug.Log("m'activo");
               Camera.main.GetComponent<CinemachineBrain>().enabled = true;

            VCamDisable.gameObject.SetActive(false);
            VCamEnable.gameObject.SetActive(true);

        }

    }

    private void OnTriggerExit(Collider other)
    {
                if(other.gameObject.layer == 8)
{
        VCamDisable.gameObject.SetActive(true);
        VCamEnable.gameObject.SetActive(false);
             Camera.main.GetComponent<CinemachineBrain>().enabled = false;
}


    }
}
