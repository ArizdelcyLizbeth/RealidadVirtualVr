using UnityEngine;

/// <summary>
/// Esta clase se encarga de reproducir efectos de sonido en el juego,
/// incluyendo el sonido de corte y el sonido de bomba.
/// </summary>
public class SoundEffectManager : MonoBehaviour
{
    public AudioClip cutSound; // Clip de sonido para el corte.
    public AudioClip bombSound; // Clip de sonido para la bomba.
    private AudioSource audioSource; 
    [Range(0f, 1f)]
    public float cutSoundVolume = 1f; // Volumen del sonido de corte.
    [Range(0f, 1f)]
    public float bombSoundVolume = 1f; // Volumen del sonido de bomba.

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

    /// <summary>
    /// Reproduce el sonido de bomba con el volumen configurado.
    /// Este metodo puede ser llamado cuando se toca una bomba en el juego.
    /// </summary>
    public void PlayBombSound()
    {
        if (bombSound != null)
        {
            audioSource.PlayOneShot(bombSound, bombSoundVolume); 
        }
    }
}
