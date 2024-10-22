using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Clip de audio para la música de fondo
    private AudioSource audioSource; // Componente de AudioSource

    [Range(0f, 1f)]
    public float backgroundMusicVolume = 0.5f; // Control del volumen de la música

    void Start()
    {
        // Obtener el componente AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();

        if (backgroundMusic != null)
        {
            // Configurar el AudioSource
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; // Repetir la música
            audioSource.volume = backgroundMusicVolume; // Establecer el volumen
            audioSource.Play(); // Reproducir la música
        }
        else
        {
            Debug.LogError("Falta el clip de música de fondo en MusicManager.");
        }
    }
}
