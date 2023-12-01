using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioColision : MonoBehaviour
{
    public AudioClip audioAColisionar;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("spider")) {
            ReproducirAudio();
        }
    }

    private void ReproducirAudio() {
        if (audioAColisionar != null) {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioAColisionar;
            audioSource.Play();
            Destroy(audioSource, audioAColisionar.length);
        }
    }
}
