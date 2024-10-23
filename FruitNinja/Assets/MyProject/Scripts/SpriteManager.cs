using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase gestiona una lista de sprites,
/// controla su eliminacion y tambien maneja la condicion de "fin de juego" 
/// </summary>
public class SpriteManager : MonoBehaviour
{
    public List<GameObject> sprites = new List<GameObject>();
    private int spriteIndex = 0;
    public bool isGameOver = false; 
    private int bombCount = 0; 

    /// <summary>
    /// Inicializa la lista de sprites anadiendo todos los hijos del objeto actual en la lista.
    /// </summary>
    void Start()
    {
        foreach (Transform child in transform)
        {
            sprites.Add(child.gameObject);
        }
    }

    /// <summary>
    /// Desactiva un sprite visible de la lista y actualiza el indice.
    /// Si no quedan sprites, se indica el fin del juego.
    /// </summary>
    public void RemoveSprite()
    {
        if (spriteIndex < sprites.Count)
        {
            sprites[spriteIndex].SetActive(false);
            spriteIndex++;

            if (spriteIndex == sprites.Count)
            {
                Debug.Log("¡Juego terminado! No hay más sprites visibles.");
            }
        }
    }

    /// <summary>
    /// Incrementa el contador de bombas tocadas. Si el numero de bombas tocadas alcanza 3, se termina el juego.
    /// </summary>
    public void IncrementBombCount()
    {
        bombCount++;
        Debug.Log("Bombas tocadas: " + bombCount);

        if (bombCount >= 3)
        {
            isGameOver = true; 
            Debug.Log("¡Juego terminado! Se han tocado 3 bombas.");
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
