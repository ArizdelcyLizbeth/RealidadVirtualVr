using UnityEngine;
using TMPro;

/// <summary>
/// Esta clase gestiona la logica de mostrar un mensaje de "Fin de Juego" en pantalla
/// cuando el estado del juego indica que ha terminado.
/// </summary>
public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finDeJuegoText;

    private SpriteManager spriteManager;

    /// <summary>
    /// El metodo Start se ejecuta al inicio del juego. Inicializa el SpriteManager y
    /// oculta el texto de "Fin de Juego" al comenzar.
    /// </summary>
    void Start()
    {
        spriteManager = GameObject.Find("Panel").GetComponent<SpriteManager>();

        if (finDeJuegoText != null)
        {
            finDeJuegoText.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// En cada frame, este metodo verifica si el juego ha terminado. Si es asi,
    /// se muestra el texto de "Fin de Juego".
    /// </summary>
    void Update()
    {
        if (spriteManager != null && spriteManager.IsGameOver())
        {
            ShowGameOverText();
        }
    }

    /// <summary>
    /// Activa y muestra el texto de "Fin de Juego" en la interfaz de usuario.
    /// </summary>
    private void ShowGameOverText()
    {
        if (finDeJuegoText != null)
        {
            finDeJuegoText.gameObject.SetActive(true);
            finDeJuegoText.text = "Fin de Juego"; 
        }
    }
}
