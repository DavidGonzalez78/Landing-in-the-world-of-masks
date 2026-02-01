using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyAttack : MonoBehaviour
{

    private ActivarTexto activar_texto;
    public AtraerObjeto atraer_objeto;
    public SpriteRenderer sr; 
    public Animator anim; 
    public int anim_state; 

    private void Start()
    {
        activar_texto = FindAnyObjectByType<ActivarTexto>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().StunPlayer();

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
}
