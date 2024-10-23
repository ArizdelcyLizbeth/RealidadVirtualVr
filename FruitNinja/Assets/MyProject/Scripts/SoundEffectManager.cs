using UnityEngine;

/// <summary>
/// Esta clase se encarga de reproducir efectos de sonido en el juego,
/// especificamente el sonido de corte cuando se invoca el metodo correspondiente.
/// </summary>
public class SoundEffectManager : MonoBehaviour
{
    public AudioClip cutSound; 
    private AudioSource audioSource; 
    [Range(0f, 1f)]
    public float cutSoundVolume = 1f; 

    /// <summary>
    /// El metodo Start inicializa el componente AudioSource y lo configura con el clip de sonido de corte.
    /// </summary>
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        if (cutSound != null)
        {
            audioSource.clip = cutSound;
        }
        else
        {
            Debug.LogError("Falta el clip de sonido de corte en SoundEffectManager.");
        }
    }

    /// <summary>
    /// Reproduce el sonido de corte con el volumen configurado.
    /// Este metodo puede ser llamado en el momento de cortar una fruta u otro objeto en el juego.
    /// </summary>
    public void PlayCutSound()
    {
        if (cutSound != null)
        {
            audioSource.PlayOneShot(cutSound, cutSoundVolume); 
        }
    }
}
