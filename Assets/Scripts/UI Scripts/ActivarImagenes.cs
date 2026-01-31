
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActivarImagenes : MonoBehaviour
{
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;
    void Start()
    {
        StartCoroutine(PrimeraImagen(5));
    }
    private IEnumerator PrimeraImagen(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        imagen1.gameObject.SetActive(true);

        StartCoroutine(SegundaImagen(tiempo));
    }

    private IEnumerator SegundaImagen(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        imagen1.gameObject.SetActive(false);
        imagen2.gameObject.SetActive(true);
        StartCoroutine(TerceraImagen(tiempo));
    }

    private IEnumerator TerceraImagen(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        imagen2.gameObject.SetActive(false);
        imagen3.gameObject.SetActive(true);
    }
}
