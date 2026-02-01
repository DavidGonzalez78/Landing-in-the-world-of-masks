
using UnityEngine;

public class CepoTrigger : MonoBehaviour
{
    public string tagNpc;
    private AtraerObjeto atraerObjeto;
    public AudioSource audioJabali;
    
    public Sprite cepoCerrado;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagNpc))
        {
            atraerObjeto = other.GetComponent<AtraerObjeto>();
            atraerObjeto.velocidad = 0;
            atraerObjeto.puedeMoverse = false;
            atraerObjeto.transform.position = transform.position + new Vector3(0, 1, 0);
            GetComponent<SpriteRenderer>().sprite = cepoCerrado;
            audioJabali.Play();
        }
    }
}
