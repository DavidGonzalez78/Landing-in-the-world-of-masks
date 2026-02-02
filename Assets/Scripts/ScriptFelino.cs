using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFelino : MonoBehaviour
{
    public enum FelinoState { Quieto, Paseando, Huyendo, Siguiendo }
    public FelinoState estado = FelinoState.Quieto;

    private Animator animator;
    private GameObject player;
    private PlayerController playerScript;
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;

    [Header("Configuración de Movimiento")]
    public float radioDeteccion = 5f;
    public float velocidad_normal = 2f;
    public float velocidad_huyendo = 5f;
    public float distanciaMinima = 1.5f;

    [Header("Tiempos de Reacción (en segundos)")]
    public float tiempoReaccion = 0.8f; // Cuánto tiempo se queda congelado con el frame especial

    private float timerEstado = 0;
    private float timerReaccion = 0; // Temporizador para el frame estático
    private Vector3 direction = Vector3.zero;
    private float distancia;
    private float distancia_desfasada; 

    //Esto sirve para que tengan direcciones un poquito diferentes al seguir al player. 
    public float desfasex = 0; 
    public float desfasey = 0;

    private GameObject centroGatoso;
    public float max_distance_centro_gatoso = 40; 


    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        float range = 2; 
        desfasex = Random.Range(-range, range); 
        desfasey = Random.Range(-range, range);

        centroGatoso = GameObject.FindWithTag("CentroGatoso");

    }

    void Update()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        distancia_desfasada = Vector3.Distance(transform.position ,player.transform.position + new Vector3(desfasex,desfasey,0));
        bool player_cerca = (distancia <= radioDeteccion);
        int mascara_index = playerScript.mascara_index;

        #region Lógica de Estados

        // 1. SI ESTÁ CERCA EL JABALÍ (Mascara 3)
        if (player_cerca && mascara_index == 3)
        {
            if (estado != FelinoState.Huyendo)
            {
                EntrarEnNuevoEstado(FelinoState.Huyendo);
            }
        }
        // 2. SI ESTÁ CERCA EL PROFETA (Mascara 4)
        else if (player_cerca && mascara_index == 4)
        {
            if (estado != FelinoState.Siguiendo)
            {
                EntrarEnNuevoEstado(FelinoState.Siguiendo);
            }
        }
        // 3. ESTADO NORMAL (Tranquilo)
        else
        {
            // Solo si no estamos ya en un estado de "alerta" o si el player se alejó
            if (estado == FelinoState.Huyendo || estado == FelinoState.Siguiendo)
            {
                estado = FelinoState.Quieto; // Volver a la normalidad
            }

            timerEstado -= Time.deltaTime;
            if (timerEstado <= 0)
            {
                DecidirComportamientoTranquilo();
            }
        }
        #endregion

        EjecutarEstado();
    }

    // Esta función centraliza el cambio de estado para activar el "congelamiento"
    void EntrarEnNuevoEstado(FelinoState nuevo)
    {
        estado = nuevo;
        timerReaccion = tiempoReaccion; // Iniciamos el contador de "susto"
        if (nuevo != FelinoState.Paseando) 
            rb.velocity = Vector3.zero;    // Se detiene en seco

        // Calcular dirección inicial de huida si es necesario
        if (nuevo == FelinoState.Huyendo)
        {
            direction = -(player.transform.position - transform.position).normalized;
            float angle = Random.Range(-30f, 30f);
            direction = Quaternion.Euler(0, 0, angle) * direction;
        }
    }

    void DecidirComportamientoTranquilo() //Decidir si estará quieto o paseando
    {
        int mascara_index = playerScript.mascara_index;

        if (Random.Range(0,10) < 6)
        {
            estado = FelinoState.Quieto;
            timerEstado = Random.Range(2f,4f);
        }
        else
        {
            estado = FelinoState.Paseando;
            timerEstado = Random.Range(2f,4f);
            
            if (Vector3.Distance(transform.position, centroGatoso.transform.position) > max_distance_centro_gatoso && mascara_index!=4)
            {
                direction = (centroGatoso.transform.position - transform.position).normalized; //Volver al centro
            }
            else
            {
                direction = new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f)).normalized;
            }
            
        }
    }

    void EjecutarEstado()
    {
        // Reducir el timer de reacción (el tiempo que se queda quieto asustado)
        if (timerReaccion > 0)
        {
            timerReaccion -= Time.deltaTime;
            // Mientras reacciona, forzamos animación especial y velocidad 0
            rb.velocity = Vector3.zero;
            ActualizarAnimaciones(true); // true significa "está en reacción"
            return;
        }

        ActualizarAnimaciones(false);

        switch (estado)
        {
            case FelinoState.Quieto:
                rb.velocity = Vector3.zero;
                break;

            case FelinoState.Paseando:
                rb.velocity = direction * velocidad_normal;
                FlipSprite(rb.velocity.x);
                animator.SetBool("IsMoving", true); 
                break;

            case FelinoState.Huyendo:
                
                FlipSprite(rb.velocity.x);

                if (timerReaccion > 0)
                {
                    animator.SetBool("IsMoving",false);
                    animator.SetBool("asustado", true);
                    rb.velocity = Vector3.zero; 
                }
                   
                else
                {
                    timerReaccion = 0;
                    animator.SetBool("IsMoving",true);
                    rb.velocity = direction * velocidad_huyendo;
                }

                break;

            case FelinoState.Siguiendo:
                
                direction = (player.transform.position  + new Vector3(desfasex,desfasey,0) - transform.position).normalized;
                if (distancia_desfasada > distanciaMinima)
                {
                    FlipSprite(rb.velocity.x);

                    if (timerReaccion > 0)
                    {
                        animator.SetBool("IsMoving",false);
                        animator.SetBool("asombrado",true);
                        rb.velocity = Vector3.zero;
                    }

                    else
                    {
                        timerReaccion = 0;
                        animator.SetBool("IsMoving",true);
                        rb.velocity = direction * velocidad_normal;
                    }

                }
                else
                {
                    rb.velocity = Vector3.zero;
                }
                break;
        }
    }

    void ActualizarAnimaciones(bool reaccionando)
    {
        // Control de Bools del Animator
        animator.SetBool("asustado",(estado == FelinoState.Huyendo && reaccionando));
        animator.SetBool("asombrado",(estado == FelinoState.Siguiendo && reaccionando));

        // Solo camina si tiene velocidad y NO está en el frame de reacción
        bool moviendose = rb.velocity.magnitude > 0.1f && !reaccionando;
        animator.SetBool("IsMoving",moviendose);
    }

    void FlipSprite(float xInput)
    {
        if (Mathf.Abs(xInput) > 0.05f)
        {
            spriteRenderer.flipX = (xInput < 0);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,radioDeteccion);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,distanciaMinima);
    }
}