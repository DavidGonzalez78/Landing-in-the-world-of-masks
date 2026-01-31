using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFelino : MonoBehaviour
{

    public enum FelinoState {Quieto, Paseando, Huyendo, Siguiendo}
    public FelinoState estado = FelinoState.Quieto;

    private Animator animator;
    private GameObject player; 
    private PlayerController playerScript; 
    private Rigidbody rb;
    private SpriteRenderer spriteRenderer; 

    public float radioDeteccion;
    public float velocidad_normal;
    public float velocidad_huyendo;
    public float distanciaMinima;

    public int counter_estado = 0; 
    public Vector3 direction = new Vector3(); 

    public int min_random_pasear = 50;
    public int max_random_pasear = 100;
    public int min_random_quieto = 50;
    public int max_random_quieto = 100;





    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
    }



    void Update()
    {

        float distancia = Vector3.Distance(transform.position, player.transform.position);
        bool player_cerca = (distancia <= radioDeteccion);
        int mascara_index = playerScript.mascara_index;

        #region //Establecer el estado correcto
        if (!player_cerca || mascara_index==1 || mascara_index==0) //Tranquilito -> Quieto o caminando
        {
            if (counter_estado<=0)
            {
                //Estado quieto
                if (Random.Range(1, 10) <=6)
                {
                    estado = FelinoState.Quieto;
                    counter_estado = Random.Range(min_random_quieto, max_random_quieto);
                }
                
                //Estado paseando
                else
                {
                    estado = FelinoState.Paseando;
                    counter_estado = Random.Range(min_random_pasear, max_random_pasear);
                    direction = new Vector3(Random.Range(-1f,1f),0f,Random.Range(-1f,1f)).normalized;
                }
            }
        }

        if (player_cerca && mascara_index==2 && estado!=FelinoState.Huyendo) //Eres un jabalí -> Huyen
        {
            estado = FelinoState.Huyendo;
            counter_estado = 200;
        }

        if (player_cerca && mascara_index==3 && estado!=FelinoState.Siguiendo) //Eres un profeta -> Huyen
        {
            estado = FelinoState.Siguiendo;
            counter_estado = 200;
        }

        counter_estado -= 1; 


        #endregion



        switch (estado)
        {
            case FelinoState.Quieto:
                UpdateQuieto(); break;

            case FelinoState.Paseando:
                UpdatePaseando(); break;

            case FelinoState.Huyendo:
                UpdateHuyendo(); break;

            case FelinoState.Siguiendo:
                UpdateSiguiendo(); break;

        }


    }

    void UpdateQuieto()
    {
        animator.SetBool("IsMoving", false);
        rb.velocity = new Vector3 (0, 0, 0);
    }

    void UpdatePaseando()
    {
        SetMoving();
        rb.velocity = direction * velocidad_normal;
    }

    void UpdateSiguiendo()
    {
        SetMoving();
        direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * velocidad_normal;
    }

    void UpdateHuyendo()
    {
        SetMoving();
        direction = - (player.transform.position - transform.position).normalized;

        // Girar un poquillo
        float angle = Random.Range(-50f,50f);
        direction = Quaternion.Euler(0f,0f,angle) * direction;

        rb.velocity = direction * velocidad_huyendo;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,radioDeteccion);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,distanciaMinima);
    }


    private void SetMoving()
    {
        animator.SetBool("IsMoving",true);

        if (rb.velocity.x > 0.01f)
            spriteRenderer.flipX = false;
        else if (rb.velocity.x < -0.01f)
            spriteRenderer.flipX = true;
    }

}
