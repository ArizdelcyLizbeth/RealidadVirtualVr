using UnityEngine;

/// <summary>
/// Esta clase se encarga de instanciar y adjuntar un prefab de una espada llamada "Sushui" 
/// al controlador derecho, asegurando que la espada este correctamente posicionada y rotada.
/// </summary>
public class AttachSwordToRightHand : MonoBehaviour
{
    // Prefab de la espada Sushui que sera instanciada y adjuntada al controlador derecho.
    public GameObject sushuiPrefab;

    /// Transform del controlador derecho al cual se adjuntara la espada.
    public Transform rightController;

    // Instancia del objeto Sushui una vez que haya sido creado
    private GameObject sushuiInstance;

    /// <summary>
    /// Metodo Start es llamado al inicio del juego. 
    /// </summary>
    void Start()
    {
        if (rightController != null && sushuiPrefab != null)
        {
            sushuiInstance = Instantiate(sushuiPrefab, rightController);

            sushuiInstance.transform.localPosition = Vector3.zero;
            sushuiInstance.transform.localRotation = Quaternion.identity;

            Debug.Log("Espada Sushui pegada al controlador derecho.");
        }
        else
        {
            Debug.LogError("Faltan referencias al prefab o al controlador derecho.");
        }
    }
}
