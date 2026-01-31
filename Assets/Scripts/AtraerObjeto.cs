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

    private Rigidbody rb;
    [Header("Modo")]
    public bool repel = false;         // MARCA ESTO PARA ALEJAR EL OBJETO

    private Animator animator;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }


    void FixedUpdate()
    {
        if (player == null) return;

        // --- INICIO SOLUCIÓN ERROR TAG VACÍO ---

        BoxCollider colliderHijo = player.GetComponentInChildren<BoxCollider>();
        bool tieneElTagCorrecto = false;

        if (colliderHijo != null)
        {
            // Verificamos que 'tagMascara' no esté vacío ni sea nulo antes de usarlo
            if (!string.IsNullOrEmpty(tagMascara))
            {
                tieneElTagCorrecto = colliderHijo.CompareTag(tagMascara);
            }
            else
            {
                // Si el campo está vacío en el inspector, avisamos en consola y no movemos nada
                // Debug.LogWarning("El campo 'Tag Mascara' está vacío. El objeto no se moverá."); 
            }
        }

        // Si NO tiene el tag correcto (se quitó la máscara):
        if (!tieneElTagCorrecto)
        {
            // 1. Forzamos al Rigidbody a detenerse inmediatamente
            rb.velocity = Vector3.zero;

            // 2. Le decimos al animador que deje de caminar
            if (animator != null) animator.SetBool("IsMoving", false);

            // 3. Salimos de la función
            return;
        }

        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia < radioDeteccion)
        {
            Vector3 direccion;
            bool debeMoverse = false;

            if (!repel)
            {
                direccion = (player.position - transform.position).normalized;
                if (distancia > distanciaMinima)
                {
                    debeMoverse = true;

                    // if(animator!=null)  animator.SetBool("IsMoving", true);
                }
            }
            else
            {
                direccion = (transform.position - player.position).normalized;
                if (distancia < distanciaMinima)
                {
                    debeMoverse = true;
                    //if (animator != null) animator.SetBool("IsMoving", true);
                }
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