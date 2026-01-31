using UnityEngine;

public class Empujar : MonoBehaviour
{
    [Header("Configuración")]
    private Transform player;            // Referencia al objeto player
    public float radioDeteccion = 10f;  // El "área" de detección
    public float velocidad = 5f;        // Qué tan rápido se acerca
    public float distanciaMinima = 1f;  // A qué distancia debe parar (1 metro)

    private Rigidbody rb;
    [Header("Modo")]

    private Animator animator;

    public bool puedeMoverse = true;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }


    void FixedUpdate()
    {
        if (player == null) return;

        

        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia < radioDeteccion)
        {
            Vector3 direccion;
            bool debeMoverse = false;

            direccion = (player.position - transform.position).normalized;
            if (distancia > distanciaMinima)
            {
                debeMoverse = true;

                // if(animator!=null)  animator.SetBool("IsMoving", true);
            }

            if (debeMoverse)
            {
                if (animator != null) animator.SetBool("IsMoving", true);
                rb.velocity = direccion * velocidad;
            }
            else
            {
                rb.velocity = Vector3.zero;
                if (animator != null)  animator.SetBool("IsMoving", false);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            if (animator != null) animator.SetBool("IsMoving", false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaMinima);
    }
}