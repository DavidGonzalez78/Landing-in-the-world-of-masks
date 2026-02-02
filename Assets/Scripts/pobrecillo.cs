using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pobrecillo : MonoBehaviour
{

    private ActivarTexto activarTexto;
    private GameObject player; 


    // Start is called before the first frame update
    void Start()
    {
        activarTexto = FindAnyObjectByType<ActivarTexto>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position); 

        if (distance < 1)
        {
            activarTexto.CambiarTexto("Parece que necesita ayuda. Es posible que también tenga un error crítico en su sistema de propulsión"); 
        }
    }
}
