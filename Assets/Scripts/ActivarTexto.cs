using TMPro;
using UnityEngine;

public class ActivarTexto : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public GameObject uIDialogo;

    string textoDialogo;

    public bool activarPanelTexto = false;

    private void Update()
    {
        AparecerTexto();
    }
    public void AparecerTexto()
    {
        if(activarPanelTexto)
        {
            uIDialogo.SetActive(true);
            texto.text = textoDialogo;
        }
    }
    public void OcultarTexto()
    {
        if(!activarPanelTexto)
        uIDialogo.SetActive(false);
    }
    public void CambiarTexto(string textoNuevo)
    {
        texto.text = textoNuevo;
    }
}
