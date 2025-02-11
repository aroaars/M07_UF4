using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoneSwitcher1 : MonoBehaviour
{
    public CinemachineVirtualCamera normalCamera;
    public CinemachineVirtualCamera topDownCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Switching to Top-Down Camera");
            EnableCamera(topDownCamera);
            DisableCamera(normalCamera);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Switching back to Normal Camera");
            EnableCamera(normalCamera);
            DisableCamera(topDownCamera);
        }
    }

    private void EnableCamera(CinemachineVirtualCamera cam)
    {
        cam.Priority = 10; // Assegura que té una prioritat més alta
        cam.gameObject.SetActive(true);
    }

    private void DisableCamera(CinemachineVirtualCamera cam)
    {
        cam.Priority = 0; // Baixa la prioritat perquè no domini la vista
        cam.gameObject.SetActive(false);
    }
}