using UnityEngine;
using TMPro; 

/// <summary>
/// Esta clase lleva el conteo de las frutas cortadas en el juego y actualiza
/// un texto en pantalla usando TextMeshPro para reflejar el conteo.
/// </summary>
public class FruitCounter : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    
    private int fruitCutCount = 0;

    private SpriteManager spriteManager;

    /// <summary>
    /// Metodo Start es llamado al inicio del juego. Aqui se obtiene la referencia al SpriteManager
    /// y se inicializa el texto de conteo de frutas.
    /// </summary>
    void Start()
    {
        spriteManager = GameObject.Find("Panel").GetComponent<SpriteManager>();
        
        UpdateFruitCountText();
    }

    /// <summary>
    /// Incrementa el numero de frutas cortadas y actualiza el texto, siempre que el juego no haya terminado.
    /// </summary>
    public void IncrementFruitCount()
    {
        if (spriteManager != null && !spriteManager.IsGameOver())
        {
            fruitCutCount++;
            UpdateFruitCountText();
        }
    }

    /// <summary>
    /// Actualiza el texto de TextMeshPro para visualizar el numero actual de frutas cortadas.
    /// </summary>
    private void UpdateFruitCountText()
    {
        textMeshPro.text = "Frutas Cortadas: " + fruitCutCount;
    }
}
