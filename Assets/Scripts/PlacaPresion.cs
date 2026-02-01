using System.Collections;
using UnityEngine;

public class PlacaPresion : MonoBehaviour
{

    [Header("Quién activa el trigger")]
    public string tagObjetoActivador;


    [Header("Qué pasa cuando se activa")]
    public GameObject objetoActivar;

    private ActivarTexto texto;

    public int elementosParaActivar = 3;
    private int elementosActuales;

    public float tiempoParaActivar = 4f;

    private bool triggerActivado = false;

    private void Start()
    {
        texto = FindAnyObjectByType<ActivarTexto>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(tagObjetoActivador)) return;
        StartCoroutine(TiempoParaActivar(tiempoParaActivar));
        triggerActivado = true;

    }
    private void OnTriggerExit(Collider other)
    {
        //elementosActuales--;
    }

    private void ActivarTrigger()
    {
    
        {
            elementosActuales++;
            Debug.Log("Trigger activado por " + tagObjetoActivador + " -> " + elementosActuales);

            if (elementosActuales >= elementosParaActivar)
            {
                objetoActivar.SetActive(true);
                triggerActivado = true;
            }

            if (texto != null)
                texto.CambiarTexto("Objetivo conseguido: Máscara! Nos vemos pronto...");
        }
    }

    private IEnumerator TiempoParaActivar(float time)
    {
        yield return new WaitForSeconds(time);
        ActivarTrigger();
    }
}
