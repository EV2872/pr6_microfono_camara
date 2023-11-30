using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioColision : MonoBehaviour
{
    public AudioClip audioAColisionar;  // El audio que se reproducirá al colisionar
    private void OnCollisionEnter(Collision collision) {
        // Verifica si la colisión involucra al objeto B
        if (collision.gameObject.CompareTag("spider")) {
            ReproducirAudio();
        }
    }

    private void ReproducirAudio() {
        // Verifica si se asignó un audio a reproducir
        if (audioAColisionar != null) {
            // Crea un nuevo AudioSource temporal para reproducir el audio
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            // Asigna el clip de audio
            audioSource.clip = audioAColisionar;
            // Reproduce el audio
            audioSource.Play();
            // Destruye el AudioSource temporal después de reproducir el audio
            Destroy(audioSource, audioAColisionar.length);
        }
    }
}
