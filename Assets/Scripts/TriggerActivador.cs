
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TriggerActivador : MonoBehaviour
{
    public GameObject objetoActivar;
    public bool desactivar;

    public bool puedeDesactivarYactivar;
    public GameObject objetoDesactivar;
    public GameObject objetoDesactivar2;

    public float numeroDeElementosParaActivar = 1;
    private float nmeroDeElementosActuales = 0;

    public string tagNpcQueTriggerea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>() != null && other.gameObject.CompareTag(tagNpcQueTriggerea) )
        {
            nmeroDeElementosActuales++;
            Debug.Log(nmeroDeElementosActuales + " de " + numeroDeElementosParaActivar);
            if(nmeroDeElementosActuales >= numeroDeElementosParaActivar)
            {
                if(desactivar)
                {
                     objetoActivar.SetActive(false);
                } 
                else if(puedeDesactivarYactivar)
                {
                    objetoDesactivar.SetActive(false);
                    objetoActivar.SetActive(true);
                    objetoDesactivar2.SetActive(false);
                }
                else
                {
                    objetoActivar.SetActive(true);
                }
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        nmeroDeElementosActuales--;
    }
}
