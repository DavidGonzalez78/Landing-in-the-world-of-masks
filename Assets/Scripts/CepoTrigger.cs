
using UnityEngine;

public class CepoTrigger : MonoBehaviour
{
    public string tagNpc;
    private AtraerObjeto atraerObjeto;
    private AudioSource audioSource;
    
    public Sprite cepoCerrado;

    private Animator animator;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagNpc))
        {
            atraerObjeto = other.GetComponent<AtraerObjeto>();
            atraerObjeto.velocidad = 0;
            atraerObjeto.puedeMoverse = false;
            atraerObjeto.transform.position = transform.position + new Vector3(0, 1, 0);
            GetComponent<SpriteRenderer>().sprite = cepoCerrado;
            if(audioSource != null) audioSource.Play();
            if (animator != null) animator.SetBool("Atrapado", true);
        }
    }
}
