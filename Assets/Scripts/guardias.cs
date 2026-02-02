using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardias : MonoBehaviour
{
    public GameObject bloqueador; 
    public GameObject player; 
    public PlayerController playerController;
    public Animator animator;
    private ActivarTexto activar_texto; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        activar_texto = FindAnyObjectByType<ActivarTexto>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerController.mascara_index == 2 || playerController.mascara_index == 4) //Máscara zorroneja
        {
            //Bajar las armas
            bloqueador.gameObject.SetActive(false); 
            animator.SetBool("Bloqueando", false); 
        }
        else
        {
            //Subir las armas
            bloqueador.gameObject.SetActive(true);
            animator.SetBool("Bloqueando", true);

            float distancia = Vector3.Distance(transform.position, player.transform.position);

            if (distancia < 2.5)
            {
                activar_texto.CambiarTexto("No me dejan pasar, no soy de los suyos. ");
            }

            
        }

    }
}
