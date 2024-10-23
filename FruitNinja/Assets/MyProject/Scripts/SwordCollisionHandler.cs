using UnityEngine;

/// <summary>
/// Esta clase maneja las colisiones de la espada con frutas y bombas.
/// Al cortar una fruta, aumenta el contador de frutas y reproduce un efecto de sonido.
/// Al tocar una bomba, se actualiza el estado del juego y se elimina un sprite.
/// </summary>
public class SwordCollisionHandler : MonoBehaviour
{
    private SpriteManager spriteManager;
    private FruitCounter fruitCounter; 
    private SoundEffectManager soundEffectManager; 

    /// <summary>
    /// Inicializa las referencias a SpriteManager, FruitCounter y SoundEffectManager.
    /// </summary>
    void Start()
    {
        spriteManager = GameObject.Find("Panel").GetComponent<SpriteManager>();

        fruitCounter = GameObject.Find("frutasCortadas").GetComponent<FruitCounter>();

        soundEffectManager = GameObject.FindObjectOfType<SoundEffectManager>();

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
    /// Detecta cuando la espada entra en contacto con frutas o bombas y maneja las interacciones
    /// </summary>
    /// <param name="other">El collider del objeto con el que se ha chocado.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
            Debug.Log("¡Fruta destruida!");

            if (fruitCounter != null)
            {
                fruitCounter.IncrementFruitCount();
            }

            if (soundEffectManager != null)
            {
                soundEffectManager.PlayCutSound();
            }
        }
        else if (other.CompareTag("Bomb"))
        {
            Debug.Log("Se termina el juego. ¡Has tocado una bomba!");

            if (spriteManager != null)
            {
                spriteManager.RemoveSprite(); 
                spriteManager.IncrementBombCount(); 
            }
            else
            {
                Debug.LogError("Referencia a SpriteManager no asignada en SwordCollisionHandler.");
            }
        }
    }
}
