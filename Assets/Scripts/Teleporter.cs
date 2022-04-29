using UnityEngine;
using UnityEngine.UIElements;

public class Teleporter : MonoBehaviour
{
    public Transform Park;
    public GameObject Player;
    public GameObject TransitionUI;

    void OnTriggerEnter(Collider other) {
        TransitionUI.SetActive(true);
        Invoke("TpPlayer", 1.5f);
        Invoke("HideTransition", 5f);
    }

    void TpPlayer() {
        Player.transform.position = Park.transform.position;
    }

    void HideTransition() {
        TransitionUI.SetActive(false);
    }
}
