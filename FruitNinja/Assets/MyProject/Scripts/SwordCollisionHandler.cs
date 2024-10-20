using UnityEngine;

public class SwordCollisionHandler : MonoBehaviour
{
    private SpriteManager spriteManager;

    void Start()
    {
        // Buscar automáticamente el SpriteManager en el Panel
        spriteManager = GameObject.Find("Panel").GetComponent<SpriteManager>();

        if (spriteManager == null)
        {
            Debug.LogError("No se encontró el SpriteManager en el Panel.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            // Destruir la fruta
            Destroy(other.gameObject);
            Debug.Log("¡Fruta destruida!");
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
