using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    // Lista para almacenar los sprites que se deben ocultar
    public List<GameObject> sprites = new List<GameObject>();

    private int spriteIndex = 0;

    void Start()
    {
        // Inicializar la lista con los hijos del Panel (asumiendo que los sprites son hijos directos del Panel)
        foreach (Transform child in transform)
        {
            sprites.Add(child.gameObject);
        }
    }

    // Método que es llamado cuando se toca una bomba
    public void RemoveSprite()
    {
        if (spriteIndex < sprites.Count)
        {
            // Ocultar el siguiente sprite
            sprites[spriteIndex].SetActive(false);
            spriteIndex++;

            // Si se han ocultado todos los sprites, detener el juego
            if (spriteIndex == sprites.Count)
            {
                // Lógica para detener el juego
                Debug.Log("¡Juego terminado! No hay más sprites visibles.");
                // Aquí puedes añadir lógica adicional para finalizar el juego, como desactivar el spawner o mostrar un menú de fin de juego.
            }
        }
    }
}
