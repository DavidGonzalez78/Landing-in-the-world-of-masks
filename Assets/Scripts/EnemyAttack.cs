using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private ActivarTexto activar_texto;
    public AtraerObjeto atraer_objeto;
    public SpriteRenderer sr; 
    public Animator anim; 
    public int anim_state; 
    public float tiempoParaVolverAAtacar; 

    private void Start()
    {
        activar_texto = FindAnyObjectByType<ActivarTexto>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().StunPlayer();
            atraer_objeto.repel = true;
            StartCoroutine(VolverAAtacar(tiempoParaVolverAAtacar));
            activar_texto.CambiarTexto("Me han tirado al suelo! ");
        }
    }

    private void Update()
    {
        if (!atraer_objeto.puedeMoverse)
            anim_state = 2; 
        else if (atraer_objeto.moviendose)
            anim_state = 0; 
        else
            anim_state = 1;

        FlipSprite( - atraer_objeto.rb.velocity.x ); 

        anim.SetInteger("anim_state",anim_state);


    }


    void FlipSprite(float xInput)
    {
        if (Mathf.Abs(xInput) > 0.05f)
        {
            sr.flipX = (xInput < 0);
        }
    }


    private IEnumerator VolverAAtacar(float time)
    {
        yield return new WaitForSeconds(time);
        atraer_objeto.repel = false; 
    }
}
