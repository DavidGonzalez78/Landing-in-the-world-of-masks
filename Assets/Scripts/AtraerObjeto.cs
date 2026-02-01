using System.Collections.Generic;
using UnityEngine;

public class AtraerObjeto : MonoBehaviour
{
    [Header("Configuración")]
    private Transform player;            // Referencia al objeto player
    public float radioDeteccion = 10f;  // El "área" de detección
    public float velocidad = 5f;        // Qué tan rápido se acerca
    public float distanciaMinima = 1f;  // A qué distancia debe parar (1 metro)

    [Tooltip("Lista de tags válidos. Si el Player tiene AL MENOS UNO de estos tags, el objeto reaccionará.")]
    public List<string> tagsMascaras = new List<string>();

    public Rigidbody rb;
    [Header("Modo")]
    public bool repel = false;         // MARCA ESTO PARA ALEJAR EL OBJETO

    private Animator animator;

    public bool puedeMoverse = true;
    public bool moviendose = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }


    void FixedUpdate()
    {
        if (player == null) return;

        // 1. Obtenemos TODOS los BoxColliders que sean hijos del Player (usando un array)
        BoxCollider[] collidersHijos = player.GetComponentsInChildren<BoxCollider>();
        bool tieneMascaraValida = false;

        if (tagsMascaras.Count == 0)
        {
            tieneMascaraValida = true;
        }
        else
        {
            foreach (BoxCollider col in collidersHijos)
            {
                // Comprobamos si este collider tiene ALGÚN tag de nuestra lista
                if (tagsMascaras.Contains(col.tag))
                {
                    tieneMascaraValida = true;
                    break; // Encontramos uno, no hace falta seguir buscando en este collider
                }
            }
        }
        // 3. Lógica de decisión: Debe moverse?
        bool debePerseguir = puedeMoverse && tieneMascaraValida;

        if (!puedeMoverse)
        {
            debePerseguir = false;
        }

        // 4. Aplicamos la decisión
        if (!debePerseguir)
        {
            rb.velocity = Vector3.zero;
            //if (animator != null) animator.SetBool("IsMoving", false);
            return;
        }

 
        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia < radioDeteccion)
        {
            Vector3 direccion;
            bool seMueveFisicamente = false;

            if (!repel)
            {
                direccion = (player.position - transform.position).normalized;
                if (distancia > distanciaMinima) seMueveFisicamente = true;
            }
            else
            {
                direccion = (transform.position - player.position).normalized;
                if (distancia < distanciaMinima) seMueveFisicamente = true;
            }

            if (seMueveFisicamente)
            {
                //if (animator != null) animator.SetBool("IsMoving", true);
                rb.velocity = direccion * velocidad;
                moviendose = true;
            }
            else
            {
                rb.velocity = Vector3.zero;
                moviendose = false; 
                //if (animator != null) animator.SetBool("IsMoving", false);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            moviendose = false;
            //if (animator != null) animator.SetBool("IsMoving", false);
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