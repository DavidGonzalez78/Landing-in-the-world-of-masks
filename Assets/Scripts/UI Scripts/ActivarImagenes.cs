
using System.Collections;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class ActivarImagenes : MonoBehaviour
{
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;

    public string identificar; 
    private ActivarTexto text_script; 

    public float tiempo = 8;


    void Start()
    {

        if (identificar=="final")
            StartCoroutine(PrimeraImagen(2));
        else
            StartCoroutine(PrimeraImagen(tiempo));

        text_script = FindAnyObjectByType<ActivarTexto>();

        if (identificar == "altar")
            text_script.CambiarTexto("Los habitantes intentan ayudar a su profeta para volver a los cielos");

    }
    private IEnumerator PrimeraImagen(float tiempo_aqui)
    {
        yield return new WaitForSeconds(tiempo_aqui);
        imagen1.gameObject.SetActive(true);
        StartCoroutine(SegundaImagen(tiempo));

        if (identificar == "inicial")
            text_script.CambiarTexto("Error crítico en el sistema de propulsión principal");

        if (identificar == "final")
            text_script.CambiarTexto("Los habitantes ayudan a su profeta.");

        if (identificar == "altar")
            gameObject.SetActive(false);
    }

    private IEnumerator SegundaImagen(float tiempo_aqui)
    {

        yield return new WaitForSeconds(tiempo_aqui);

        imagen1.gameObject.SetActive(false);

        if (identificar == "inicial")
            text_script.CambiarTexto("Aterrizaje forzoso. Fuera de control");

        if (identificar == "final")
            text_script.CambiarTexto("Sistema de propulsión reparado. Vehículo operativo. Hell yeah!");


        if (identificar != "altar")
        {
            imagen2.gameObject.SetActive(true);
            StartCoroutine(TerceraImagen(tiempo));
        }
            
    }

    private IEnumerator TerceraImagen(float tiempo_aqui)
    {
        yield return new WaitForSeconds(tiempo_aqui);
        imagen2.gameObject.SetActive(false);
        imagen3.gameObject.SetActive(true);

        if (identificar == "inicial")
            text_script.CambiarTexto("Planeta desconocido. Demasiada radiación solar. No es seguro que me identifiquen, debo ponerme una máscara");

        if (identificar == "final")
            text_script.CambiarTexto("Usuario, muchas gracias por jugar! ");

        StartCoroutine(Terminar(tiempo));
    }

    private IEnumerator Terminar(float tiempo_aqui)
    {
        yield return new WaitForSeconds(tiempo_aqui);
        imagen3.gameObject.SetActive(false);
        gameObject.SetActive(false); 
    }
}
