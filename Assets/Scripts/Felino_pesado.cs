using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Felino_pesado : MonoBehaviour
{
    public enum FelinoState { Quieto, Huyendo, Siguiendo }
    public FelinoState estado = FelinoState.Quieto;

    private Animator animator;
    private GameObject player;
    private PlayerController playerScript;
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer;

    [Header("Configuración")]
    public float radioDeteccion = 5f;
    public float velocidad_normal = 2f;
    public float velocidad_huyendo = 5f;
    public float distanciaMinima = 1.5f;
    public float tiempoReaccion = 0.8f;

    private float timerReaccion = 0;
    private Vector3 direction = Vector3.zero;
    private float distancia;
    private int facing = 1;

    [Header("Referencias Externas")]
    public GameObject blocker;
    private ActivarTexto activar_texto;

    private float distancia_desfasada;

    //Esto sirve para que tengan direcciones un poquito diferentes al seguir al player. 
    public float desfasex = 0;
    public float desfasey = 0;

    private bool done = false;

    


    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        activar_texto = FindAnyObjectByType<ActivarTexto>();

        if (blocker != null) blocker.SetActive(true);

        float range = 2;
        desfasex = Random.Range(-range,range);
        desfasey = Random.Range(-range,range);

        
    }

    void Update()
    {
        distancia = Vector3.Distance(transform.position,player.transform.position);
        distancia_desfasada = Vector3.Distance(transform.position,player.transform.position + new Vector3(desfasex,desfasey,0));
        bool player_cerca = (distancia <= radioDeteccion);
        int mascara_index = playerScript.mascara_index;

        #region Cambio de Estados
        // 1. SI ESTÁ CERCA EL JABALÍ (Mascara 3) -> Huye
        if (player_cerca && mascara_index == 3)
        {
            if (estado != FelinoState.Huyendo) EntrarEnNuevoEstado(FelinoState.Huyendo);
        }
        // 2. SI ESTÁ CERCA EL PROFETA (Mascara 4) -> Sigue
        else if (player_cerca && mascara_index == 4)
        {
            if (estado != FelinoState.Siguiendo) EntrarEnNuevoEstado(FelinoState.Siguiendo);
        }
        // 3. VOLVER A QUIETO
        else if (estado != FelinoState.Quieto)
        {
            estado = FelinoState.Quieto;
        }
        #endregion

        EjecutarEstado();
    }

    void EntrarEnNuevoEstado(FelinoState nuevo)
    {
        estado = nuevo;
        timerReaccion = tiempoReaccion; // Reset del tiempo de susto/asombro
        rb.velocity = Vector3.zero;

        if (nuevo == FelinoState.Huyendo)
        {
            direction = -(player.transform.position - transform.position).normalized;
            float angle = Random.Range(-30f,30f);
            direction = Quaternion.Euler(0,0,angle) * direction;
        }
    }

    void EjecutarEstado()
    {
        // GESTIÓN DEL BLOCKER: Solo activo si está Quieto
        if (blocker != null)
            blocker.SetActive(estado == FelinoState.Quieto);

        // LÓGICA DE REACCIÓN (CONGELADO)
        if (timerReaccion > 0)
        {
            timerReaccion -= Time.deltaTime;
            rb.velocity = Vector3.zero;
            ActualizarAnimaciones(true);
            return; // Bloqueamos el resto del movimiento mientras dure la reacción
        }

        // LÓGICA DE MOVIMIENTO (ACCIÓN)
        ActualizarAnimaciones(false);

        switch (estado)
        {
            case FelinoState.Quieto:
                rb.velocity = Vector3.zero;
                // Giro aleatorio ocasional para dar vida
                if (Random.Range(0,1000) > 997)
                {
                    facing *= -1;
                    FlipSprite(facing);
                }

                if (distancia < 2 && done==false)
                {
                    activar_texto.CambiarTexto("Hay demasiada gente, no puedo pasar. Están esperando para hacer un ritual.");
                }


                break;

            case FelinoState.Huyendo:
                rb.velocity = direction * velocidad_huyendo;
                FlipSprite(rb.velocity.x);
                break;

            case FelinoState.Siguiendo:
                direction = (player.transform.position + new Vector3(desfasex, desfasey, 0) - transform.position).normalized;

                if (distancia_desfasada > distanciaMinima)
                {
                    rb.velocity = direction * velocidad_normal;
                    FlipSprite(rb.velocity.x);
                    done = true; 
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
        // Forzamos los parámetros del Animator
        animator.SetBool("asustado",(estado == FelinoState.Huyendo && reaccionando));
        animator.SetBool("asombrado",(estado == FelinoState.Siguiendo && reaccionando));

        // Movimiento: Solo si hay velocidad y NO estamos en el frame de reacción
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