using UnityEngine;

public class SwordCollisionHandler : MonoBehaviour
{
    private SpriteManager spriteManager;
    private FruitCounter fruitCounter; // Nueva referencia para el contador de frutas

    void Start()
    {
        // Buscar automáticamente el SpriteManager en el Panel
        spriteManager = GameObject.Find("Panel").GetComponent<SpriteManager>();

        // Buscar el FruitCounter en el objeto frutasCortadas
        fruitCounter = GameObject.Find("frutasCortadas").GetComponent<FruitCounter>();

        if (spriteManager == null)
        {
            Debug.LogError("No se encontró el SpriteManager en el Panel.");
        }

        if (fruitCounter == null)
        {
            Debug.LogError("No se encontró el FruitCounter en frutasCortadas.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            // Destruir la fruta
            Destroy(other.gameObject);
            Debug.Log("¡Fruta destruida!");

            // Incrementar el contador de frutas cortadas
            if (fruitCounter != null)
            {
                fruitCounter.IncrementFruitCount();
            }
        }
        else if (other.CompareTag("Bomb"))
        {
            // Imprimir mensaje en la consola
            Debug.Log("Se termina el juego. ¡Has tocado una bomba!");

            // Llamar al método RemoveSprite del SpriteManager
            if (spriteManager != null)
            {
                spriteManager.RemoveSprite(); // Desactivar sprite
                spriteManager.IncrementBombCount(); // Incrementar contador de bombas
            }
            else
            {
                Debug.LogError("Referencia a SpriteManager no asignada en SwordCollisionHandler.");
            }
        }
    }
}
