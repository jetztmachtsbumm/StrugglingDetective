using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerInput playerInput;

    private Camera cam;

    RaycastHit hit;

    private void Awake()
    {
        playerInput = new PlayerInput();
        cam = Camera.main;

        playerInput.CharacterControls.Interaction.performed += ctx => CheckForInteraction();
    }

    private void Update()
    {
        Debug.DrawRay(cam.transform.forward, hit.point, Color.red);
    }

    private void CheckForInteraction()
    {
        Debug.Log("Pressed E");
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 5f))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
