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

    private Coroutine coroutineActivo = null;

    private void FixedUpdate()
    {
        // Solo manejamos la activación/desactivación según activarPanelTexto
        if (activarPanelTexto && uIDialogo.activeSelf == false)
        {
            AparecerTexto();
        }
        else if (!activarPanelTexto && uIDialogo.activeSelf == true)
        {
            OcultarTexto();
        }
    }

    public void AparecerTexto()
    {
        // Activamos el panel y ponemos el texto predeterminado
        uIDialogo.SetActive(true);
        texto.text = textoDialogo;

        // Si hay una coroutine corriendo, la reiniciamos
        if (coroutineActivo != null)
            StopCoroutine(coroutineActivo);

        coroutineActivo = StartCoroutine(TiempoActivo(tiempoActivo));
    }

    private IEnumerator TiempoActivo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        OcultarTexto();
    }

    public void OcultarTexto()
    {
        uIDialogo.SetActive(false);
        activarPanelTexto = false;
        coroutineActivo = null;
    }

    public void CambiarTexto(string textoNuevo)
    {

        // Activamos el panel
        activarPanelTexto = true;
        uIDialogo.SetActive(true);

        // Ponemos el nuevo texto
        texto.text = textoNuevo;

        // Reiniciamos la coroutine si ya estaba corriendo
        if (coroutineActivo != null)
            StopCoroutine(coroutineActivo);

        coroutineActivo = StartCoroutine(TiempoActivo(tiempoActivo));
    }
}