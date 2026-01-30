using UnityEngine;

public class AtraerObjeto : MonoBehaviour
{
    [Header("Configuración")]
    private Transform player;            // Referencia al objeto player
    public float radioDeteccion = 10f;  // El "área" de detección
    public float velocidad = 5f;        // Qué tan rápido se acerca
    public float distanciaMinima = 1f;  // A qué distancia debe parar (1 metro)

    private Rigidbody rb;
    [Header("Modo")]

    public bool repel = false;         // MARCA ESTO PARA ALEJAR EL OBJETO

    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 1. Calcular distancia actual
        float distancia = Vector3.Distance(transform.position, player.position);

        // 2. Verificar que el objeto esté dentro del área de detección (Radio)
        if (distancia < radioDeteccion)
        {
            Vector3 direccion;
            bool debeMoverse = false;

            if (!repel)
            {
                // --- MODO ATRAER ---
                // Calcula dirección HACIA el player
                direccion = (player.position - transform.position).normalized;

                // Se mueve solo si está lejos (más de 1 metro)
                if (distancia > distanciaMinima)
                {
                    debeMoverse = true;
                }
            }
            else
            {
                // --- MODO REPELER ---
                // Calcula dirección DESDE el player HACIA afuera (invertida)
                direccion = (transform.position - player.position).normalized;

                // Se mueve solo si está muy cerca (menos de 1 metro)
                // Esto mantiene el "escudo" de 1 metro
                if (distancia < distanciaMinima)
                {
                    debeMoverse = true;
                }
            }

            // 3. Aplicar movimiento
            if (debeMoverse)
            {
                rb.velocity = direccion * velocidad;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            // Si está fuera del radio, frenamos por seguridad
            rb.velocity = Vector3.zero;
        }
    }

    // Para ver el área de detección en el Editor (Gizmo)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaMinima);
    }
}