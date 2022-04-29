using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    public AudioClip aclip;
    public float volume = 1f;

    void Start()
    {
        AudioSource.PlayClipAtPoint(aclip, transform.position, volume);
    }
}
