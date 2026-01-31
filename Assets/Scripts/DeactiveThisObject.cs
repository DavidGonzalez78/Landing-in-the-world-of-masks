using System.Collections;
using UnityEngine;

public class DeactiveThisObject : MonoBehaviour
{
    public float tiempoParaDestruir = 3f;

    private void Start()
    {
        StartCoroutine(Desactivacion(tiempoParaDestruir));
    }

    IEnumerator Desactivacion(float tiempoParaDestruir)
    {
        yield return new WaitForSeconds(tiempoParaDestruir);
        gameObject.SetActive(false);
    }
}
