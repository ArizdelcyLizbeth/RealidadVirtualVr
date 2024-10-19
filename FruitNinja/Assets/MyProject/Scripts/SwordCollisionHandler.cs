using UnityEngine;

public class SwordCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            // Destruir la fruta
            Destroy(other.gameObject);
            Debug.Log("¡Fruta destruida!");
        }
        else if (other.CompareTag("Bomb"))
        {
            // Imprimir mensaje en la consola
            Debug.Log("Se termina el juego. ¡Has tocado una bomba!");
            // Aquí puedes agregar lógica adicional para terminar el juego
        }
    }
}
