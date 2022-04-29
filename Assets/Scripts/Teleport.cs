using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleport : MonoBehaviour
{
    public Transform Park;

    public GameObject Player;
    public GameObject TransitionUI;

    void OnTriggerEnter(Collider other) {
        TransitionUI.SetActive(true);
        Invoke("TpPlayer", 1.5f);
        Invoke("TransitionUI.SetActive(false);", 5f);
    }

    void TpPlayer() {
        Debug.Log(Player.transform.position.y);
        Player.transform.position = Park.transform.position;
        Debug.Log(Player.transform.position.y);
    }
}
