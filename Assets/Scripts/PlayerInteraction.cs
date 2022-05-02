using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Camera cam;

    RaycastHit hit;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Debug.DrawRay(cam.transform.forward, hit.point, Color.red);
    }

    public void CheckForInteraction()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 5f))
        {
            Debug.Log(hit.transform.name);
        }
    }
}