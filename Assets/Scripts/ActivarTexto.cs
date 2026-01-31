using System.Collections;
using TMPro;
using UnityEngine;

public class ActivarTexto : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public GameObject uIDialogo;

    public float tiempoActivo = 5f;
    public string textoDialogo;

    public bool activarPanelTexto = false;

    private bool estadoActualActivo = false;
    private void Update()
    {
        if (activarPanelTexto == true)
        {
            AparecerTexto();

        }
        if (activarPanelTexto == false)
        {
            OcultarTexto();
        }
    }
    public void AparecerTexto()
    {
        if (activarPanelTexto && estadoActualActivo == false)
        {
            uIDialogo.SetActive(true);
            texto.text = textoDialogo;
            StartCoroutine(TiempoActivo(tiempoActivo));
        }
    }
    private IEnumerator TiempoActivo(float tiempoActivo)
    {
        estadoActualActivo = true;
        yield return new WaitForSeconds(tiempoActivo);
        OcultarTexto();
    }
    public void OcultarTexto()
    {
        if (!activarPanelTexto)
            uIDialogo.SetActive(false);
        activarPanelTexto = false;
        estadoActualActivo = false;
    }
    public void CambiarTexto(string textoNuevo)
    {
        activarPanelTexto = true;

        if (activarPanelTexto && estadoActualActivo == false)
        {
            uIDialogo.SetActive(true);
            texto.text = textoNuevo;
            StartCoroutine(TiempoActivo(tiempoActivo));
        }
    }
}
