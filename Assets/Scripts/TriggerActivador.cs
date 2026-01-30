
using UnityEngine;

public class TriggerActivador : MonoBehaviour
{
    public GameObject objetoActivar;
    public bool desactivar;

    public float numeroDeElementosParaActivar = 1;
    private float nmeroDeElementosActuales = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>() != null) 
        {
            nmeroDeElementosActuales++;
            Debug.Log(nmeroDeElementosActuales + " de " + numeroDeElementosParaActivar);
            if(nmeroDeElementosActuales >= numeroDeElementosParaActivar)
            {
                if(desactivar)
                {
                     objetoActivar.SetActive(false);
                } else
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
