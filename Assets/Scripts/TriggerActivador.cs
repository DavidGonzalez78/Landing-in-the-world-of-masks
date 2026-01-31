
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TriggerActivador : MonoBehaviour
{

    [Header("Quién activa el trigger")]
    public GameObject objetoActivador;


    [Header("Qué pasa cuando se activa")]
    public GameObject objetoActivar;
    public GameObject objetoDesactivar;
    public GameObject objetoDesactivar2;

    private ActivarTexto texto;


    private void Start()
    {
        texto = FindAnyObjectByType<ActivarTexto>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != objetoActivador) return;

        ActivarTrigger();
    }

    private void ActivarTrigger()
    {
        Debug.Log("Trigger activado por " + objetoActivador.name);

        if (objetoActivar != null)
            objetoActivar.SetActive(true);

        if (objetoDesactivar != null)
            objetoDesactivar.SetActive(false);

        if (objetoDesactivar2 != null)
            objetoDesactivar2.SetActive(false);

        if (texto != null)
            texto.CambiarTexto("Objetivo conseguido: Máscara");
    }
}