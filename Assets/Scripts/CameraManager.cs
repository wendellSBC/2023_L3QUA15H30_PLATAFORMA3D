using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cameraB;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "wall")
        {
            cameraB.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            cameraB.SetActive(false);
        }
    }

}
