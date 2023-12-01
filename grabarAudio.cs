using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class grabarAudio : MonoBehaviour {
    public AudioSource audioSource;
    private bool grabando;
    void Start() {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        foreach (var device in Microphone.devices) {
            Debug.Log("Dispositivo de Audio: " + device);
        }
        audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
        grabando = true;
    }

    // Update is called once per frame
    void Update() {           
        if (Input.GetKey("r") && !grabando) {
            grabando = true;
            audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
        }
        if (Input.GetKey("y") && grabando) {
            grabando = false;
            Microphone.End(Microphone.devices[0]);
            audioSource.Play();
        }
    }
}
