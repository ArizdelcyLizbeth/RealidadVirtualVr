using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public AudioClip cutSound; // Clip de sonido para el efecto de corte
    private AudioSource audioSource; // Componente de AudioSource
    [Range(0f, 1f)]
    public float cutSoundVolume = 1f; // Volumen del sonido de corte (de 0 a 1)

    void Start()
    {
        // Obtener el componente AudioSource
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

    // Método para reproducir el sonido de corte
    public void PlayCutSound()
    {
        if (cutSound != null)
        {
            audioSource.PlayOneShot(cutSound, cutSoundVolume); // Reproduce el sonido una vez con el volumen ajustado
        }
    }
}
