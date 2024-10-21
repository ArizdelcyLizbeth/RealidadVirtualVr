using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{
    // Método que se llamará al presionar el botón de reinicio
    public void RestartGame()
    {
        Debug.Log("Reiniciando el juego...");
        // Recargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

