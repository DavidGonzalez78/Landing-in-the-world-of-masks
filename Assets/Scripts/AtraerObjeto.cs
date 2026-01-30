using UnityEngine;

public class AtraerObjeto : MonoBehaviour
{
    [Header("Configuración")]
    private Transform player;            // Referencia al objeto player
    public float radioDeteccion = 10f;  // El "área" de detección
    public float velocidad = 5f;        // Qué tan rápido se acerca
    public float distanciaMinima = 1f;  // A qué distancia debe parar (1 metro)

    private Rigidbody rb;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 1. Calcular distancia actual
        float distancia = Vector3.Distance(transform.position, player.position);

        // 2. Verificar si está dentro del radio PERO fuera de la distancia mínima
        if (distancia < radioDeteccion && distancia > distanciaMinima)
        {
            // Calcular dirección hacia el jugador
            Vector3 direccion = (player.position - transform.position).normalized;

            // Mover usando el Rigidbody
            // Usamos velocity para que sea un movimiento físico fluido
            rb.velocity = direccion * velocidad;
        }
        else
        {
            // Si está muy lejos o ya llegó a 1 metro, frenamos el movimiento
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