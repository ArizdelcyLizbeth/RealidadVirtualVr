using UnityEngine;

/// <summary>
/// Esta clase se encarga de reproducir musica de fondo en el juego.
/// Configura y controla el volumen, reproduccion y bucle de la musica.
/// </summary>
public class MusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic; 
    private AudioSource audioSource; 

    [Range(0f, 1f)]
    public float backgroundMusicVolume = 0.5f; 

    /// <summary>
    /// El metodo Start inicializa el componente AudioSource y comienza a reproducir la musica de fondo
    /// </summary>
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true; 
            audioSource.volume = backgroundMusicVolume; 
            audioSource.Play(); 
        }
        else
        {
            Debug.LogError("Falta el clip de música de fondo en MusicManager.");
        }
    }
}
