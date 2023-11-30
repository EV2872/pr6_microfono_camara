using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class grabarAudio : MonoBehaviour {
    public AudioSource audioSource;
    private bool grabando;
    void Start() {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) {
            // If AudioSource is not found, add it to the game object
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        foreach (var device in Microphone.devices) {
            Debug.Log("Audio: " + device);
        }
        audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
        grabando = true;
    }

    // Update is called once per frame
    void Update() {           
        if (Input.GetKey("r") && !grabando) {
            audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
            grabando = true;
        }
        if (Input.GetKey("y") && grabando) {
            Microphone.End(Microphone.devices[0]);
            audioSource.Play();
            grabando = false;
        }
    }
}
