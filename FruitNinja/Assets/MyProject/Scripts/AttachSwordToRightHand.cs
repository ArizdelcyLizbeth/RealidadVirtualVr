using UnityEngine;

public class AttachSwordToRightHand : MonoBehaviour
{
    // Prefab de la espada Sushui
    public GameObject sushuiPrefab;

    // Referencia al controlador derecho
    public Transform rightController;

    private GameObject sushuiInstance;

    void Start()
    {
        if (rightController != null && sushuiPrefab != null)
        {
            // Instanciar el prefab Sushui y hacerlo hijo del controlador derecho
            sushuiInstance = Instantiate(sushuiPrefab, rightController);

            // Asegúrate de que esté bien posicionado y rotado localmente
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
