using UnityEngine;

public class PickupLevitation : MonoBehaviour
{
    [Header("Configuración de Levitación")]
    public float altura = 0.5f;      // Qué tan alto sube y baja
    public float velocidad = 2f;     // Qué tan rápido se mueve

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float desplazamientoY = Mathf.Sin(Time.time * velocidad) * altura;
        transform.position = posicionInicial + new Vector3(0f, desplazamientoY, 0f);
    }
}
