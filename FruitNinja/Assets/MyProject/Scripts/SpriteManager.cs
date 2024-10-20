using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public List<GameObject> sprites = new List<GameObject>();
    private int spriteIndex = 0;
    public bool isGameOver = false; // Para rastrear si el juego ha terminado
    private int bombCount = 0; // Contador de bombas tocadas

    void Start()
    {
        foreach (Transform child in transform)
        {
            sprites.Add(child.gameObject);
        }
    }

    public void RemoveSprite()
    {
        if (spriteIndex < sprites.Count)
        {
            sprites[spriteIndex].SetActive(false);
            spriteIndex++;

            // Si se han ocultado todos los sprites, detener el juego
            if (spriteIndex == sprites.Count)
            {
                Debug.Log("¡Juego terminado! No hay más sprites visibles.");
            }
        }
    }

    public void IncrementBombCount()
    {
        bombCount++;
        Debug.Log("Bombas tocadas: " + bombCount);

        // Verificar si se han tocado 3 bombas
        if (bombCount >= 3)
        {
            isGameOver = true; // Marcar el juego como terminado
            Debug.Log("¡Juego terminado! Se han tocado 3 bombas.");
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}

