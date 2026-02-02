using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placa_presion_altar : MonoBehaviour
{

    public GameObject activar1;
    public GameObject activar2;
    private bool done = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Solo se activa si entra el jugador. Solo se puede hacer una vez. 
        if (!other.gameObject.CompareTag("Player")) return;
        if (done) return;
        done = true;

        print("Activada la cinemática del altar");

        ActivarTexto activar_texto = FindAnyObjectByType<ActivarTexto>();
        activar_texto.CambiarTexto("Los habitantes intentan ayudar a su profeta para volver a los cielos");

        //Entrar en la cinematica sagrada y activar la máscara

        activar2.SetActive(true);
        StartCoroutine(ActivarMascara(3));



    }

    private IEnumerator ActivarMascara(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        activar1.SetActive(true);
    }
}
