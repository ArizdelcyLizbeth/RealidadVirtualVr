using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    // Referencia al objeto TextMeshPro para mostrar el mensaje de fin de juego
    public TextMeshProUGUI finDeJuegoText;

    // Referencia al SpriteManager
    private SpriteManager spriteManager;

    void Start()
    {
        // Buscar el SpriteManager en el Panel
        spriteManager = GameObject.Find("Panel").GetComponent<SpriteManager>();

        // Asegúrate de que el texto esté desactivado al inicio
        if (finDeJuegoText != null)
        {
            finDeJuegoText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Verificar si el juego ha terminado
        if (spriteManager != null && spriteManager.IsGameOver())
        {
            ShowGameOverText();
        }
    }

    private void ShowGameOverText()
    {
        // Activar el texto de fin de juego
        if (finDeJuegoText != null)
        {
            finDeJuegoText.gameObject.SetActive(true);
            finDeJuegoText.text = "Fin de Juego"; // Cambiar el texto si lo deseas
        }
    }
}
