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
        if (textMeshPro == null)
        {
            Debug.LogError("TextMeshPro no está asignado en FruitCounter.");
        }
        UpdateFruitCountText();
    }

    // Método para incrementar el contador de frutas cortadas
    public void IncrementFruitCount()
    {
        fruitCutCount++;
        Debug.Log("Contador de frutas cortadas: " + fruitCutCount); // Mensaje de depuración
        UpdateFruitCountText();
    }

    // Actualizar el texto del contador
    private void UpdateFruitCountText()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = "Frutas Cortadas: " + fruitCutCount;
            Debug.Log("Texto actualizado: " + textMeshPro.text); // Mensaje de depuración
        }
        else
        {
            Debug.LogError("TextMeshPro no está asignado, no se puede actualizar el texto.");
        }
    }
}
