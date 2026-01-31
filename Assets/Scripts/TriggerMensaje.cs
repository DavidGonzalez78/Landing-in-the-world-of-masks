
using UnityEngine;

public class TriggerMensaje : MonoBehaviour
{
    private ActivarTexto texto_;
    public string texto;
    void Start()
    {
        texto_ = FindAnyObjectByType<ActivarTexto>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            texto_.CambiarTexto(texto);
        }
    }
}
