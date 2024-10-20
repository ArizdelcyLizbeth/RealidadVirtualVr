using UnityEngine;
using TMPro; 

public class FruitCounter : MonoBehaviour
{
    // Referencia al objeto TextMeshPro para mostrar el contador
    public TextMeshPro textMeshPro;
    private int fruitCutCount = 0;

    void Start()
    {
        // Asegúrate de que el texto esté inicializado
        UpdateFruitCountText();
    }

    // Método para incrementar el contador de frutas cortadas
    public void IncrementFruitCount()
    {
        fruitCutCount++;
        UpdateFruitCountText();
    }

    // Actualizar el texto del contador
    private void UpdateFruitCountText()
    {
        textMeshPro.text = "Frutas Cortadas: " + fruitCutCount;
    }
}

