using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoneSwitcher: MonoBehaviour
{
    public CinemachineVirtualCamera normalCamera;
    public CinemachineVirtualCamera topDownCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            normalCamera.gameObject.SetActive(false);
            topDownCamera.gameObject.SetActive(true);
        }
        Debug.Log("hola");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            topDownCamera.gameObject.SetActive(false);
            normalCamera.gameObject.SetActive(true);
        }
        Debug.Log("adéu");
    }


}