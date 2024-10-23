using UnityEngine;

/// <summary>
/// Esta clase maneja las colisiones de la espada con frutas y bombas.
/// Al cortar una fruta, aumenta el contador de frutas y reproduce un efecto de sonido.
/// Al tocar una bomba, se actualiza el estado del juego, se reproduce un sonido de bomba y se elimina un sprite.
/// </summary>
public class SwordCollisionHandler : MonoBehaviour
{
    private SpriteManager spriteManager; // Referencia al SpriteManager para manejar el estado del juego.
    private FruitCounter fruitCounter; // Referencia al contador de frutas cortadas.
    private SoundEffectManager soundEffectManager; // Referencia al gestor de efectos de sonido.

    /// <summary>
    /// Inicializa las referencias a SpriteManager, FruitCounter y SoundEffectManager.
    /// </summary>
    void Start()
    {
        spriteManager = GameObject.Find("Panel").GetComponent<SpriteManager>();
        fruitCounter = GameObject.Find("frutasCortadas").GetComponent<FruitCounter>();
        soundEffectManager = GameObject.FindObjectOfType<SoundEffectManager>();

        // Verificación de referencias encontradas.
        if (spriteManager == null)
        {
            Debug.LogError("No se encontró el SpriteManager en el Panel.");
        }

        if (fruitCounter == null)
        {
            Debug.LogError("No se encontró el FruitCounter en frutasCortadas.");
        }

        if (soundEffectManager == null)
        {
            Debug.LogError("No se encontró el SoundEffectManager.");
        }
    }

    /// <summary>
    /// Detecta cuando la espada entra en contacto con frutas o bombas y maneja las interacciones.
    /// </summary>
    /// <param name="other">El collider del objeto con el que se ha chocado.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Si la colisión es con una fruta.
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject); // Destruir la fruta.
            Debug.Log("¡Fruta destruida!");

            // Incrementar el contador de frutas.
            if (fruitCounter != null)
            {
                fruitCounter.IncrementFruitCount();
            }

            // Reproducir el sonido de corte.
            if (soundEffectManager != null)
            {
                soundEffectManager.PlayCutSound();
            }
        }
        // Si la colisión es con una bomba.
        else if (other.CompareTag("Bomb"))
        {
            Debug.Log("Se termina el juego. ¡Has tocado una bomba!");

            // Actualizar el estado del juego y reproducir el sonido de bomba.
            if (spriteManager != null)
            {
                spriteManager.RemoveSprite(); 
                spriteManager.IncrementBombCount(); 
            }

            // Reproducir el sonido de bomba.
            if (soundEffectManager != null)
            {
                soundEffectManager.PlayBombSound(); // Asegúrate de tener este método en SoundEffectManager.
            }
        }
    }
}
