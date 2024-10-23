using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Esta clase GameReset se encarga de reiniciar el juego cargando nuevamente la escena activa.
/// </summary>
public class GameReset : MonoBehaviour
{
    /// <summary>
    /// Reinicia el juego al volver a cargar la escena actual.
    /// </summary>
    public void RestartGame()
    {
        Debug.Log("Reiniciando el juego...");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
