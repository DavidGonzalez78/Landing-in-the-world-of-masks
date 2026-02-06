using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip sonidoDeDestruccion; // Arrastra tu audio aquí desde el inspector

    private void OnEnable()
    {
        // Nos suscribimos al evento definido en DeactiveThisObject
        DeactiveThisObject.OnObjectDeactivate += PlaySound;
        audioSource.volume = 0;
    }

    private void OnDisable()
    {
        // ¡Muy importante! Darnos de baja cuando se desactiva el script para evitar errores de memoria
        DeactiveThisObject.OnObjectDeactivate -= PlaySound;
    }

    private void PlaySound()
    {
        if (sonidoDeDestruccion != null)
        {
            audioSource.volume = 1;
            //audioSource.Play();
        }
    }
}