using UnityEngine;

public class AtraerObjeto : MonoBehaviour
{
    [Header("Configuración")]
    private Transform player;            // Referencia al objeto player
    public float radioDeteccion = 10f;  // El "área" de detección
    public float velocidad = 5f;        // Qué tan rápido se acerca
    public float distanciaMinima = 1f;  // A qué distancia debe parar (1 metro)

    [Tooltip("El tag del objeto mascara que tiene que tener activa el player para que se cumpla")]
    public string tagMascara;

    [Tooltip("SI necesitamos que haya mas de una mascara a perseguir, activar el check")]
    public bool tiene2Mascaras;
    public string tagMascara2;

    private Rigidbody rb;
    [Header("Modo")]
    public bool repel = false;         // MARCA ESTO PARA ALEJAR EL OBJETO

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

        // 1. Obtenemos TODOS los BoxColliders que sean hijos del Player (usando un array)
        BoxCollider[] collidersHijos = player.GetComponentsInChildren<BoxCollider>();

        // Variables para saber qué máscaras tiene puestas
        bool tieneMascara1 = false;
        bool tieneMascara2 = false;

        // 2. Recorremos el array para ver qué tags encontramos
        foreach (BoxCollider col in collidersHijos)
        {
            // Comprobamos la Máscara 1
            if (!string.IsNullOrEmpty(tagMascara) && col.CompareTag(tagMascara))
            {
                tieneMascara1 = true;
            }

            // Comprobamos la Máscara 2 (Solo si está activada la opción)
            if (tiene2Mascaras && !string.IsNullOrEmpty(tagMascara2) && col.CompareTag(tagMascara2))
            {
                tieneMascara2 = true;
            }
        }

        // 3. Lógica de decisión: ¿Debe moverse?
        bool debePerseguir = false;

        if (!puedeMoverse)
        {
            debePerseguir = false;
        }
        else if (tiene2Mascaras)
        {
            // Si exige 2 máscaras, necesita tener AMBAS true
            debePerseguir = tieneMascara1 && tieneMascara2;
        }
        else
        {
            // Si solo exige 1, solo necesita la primera (o la que no esté vacía)
            // Nota: Si tagMascara está vacío, permitimos movimiento por defecto (o puedes poner !string.IsNullOrEmpty)
            if (!string.IsNullOrEmpty(tagMascara))
            {
                debePerseguir = tieneMascara1;
            }
            else
            {
                // Si no hay tag definido, permitimos que se mueva (comportamiento por defecto anterior)
                debePerseguir = true;
            }
        }

        // 4. Aplicamos la decisión
        if (!debePerseguir)
        {
            rb.velocity = Vector3.zero;
            if (animator != null) animator.SetBool("IsMoving", false);
            return;
        }

        // --- AQUI VA EL RESTO DE TU CÓDIGO DE MOVIMIENTO (SIN CAMBIOS) ---
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
                if (animator != null) animator.SetBool("IsMoving", true);
                rb.velocity = direccion * velocidad;
            }
            else
            {
                rb.velocity = Vector3.zero;
                if (animator != null) animator.SetBool("IsMoving", false);
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