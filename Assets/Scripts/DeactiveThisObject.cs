using System.Collections;
using UnityEngine;

public class DeactiveThisObject : MonoBehaviour
{
    public float tiempoParaDestruir = 3f;


    private void Start()
    {
        StartCoroutine(Desactivacion(tiempoParaDestruir));
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator Desactivacion(float tiempoParaDestruir)
    {
        yield return new WaitForSeconds(tiempoParaDestruir);
        gameObject.SetActive(false);
    }
}
