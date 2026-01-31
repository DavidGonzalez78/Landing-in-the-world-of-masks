using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardias : MonoBehaviour
{
    public GameObject bloqueador; 
    public GameObject player; 
    public PlayerController playerController;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerController.mascara_index == 2) //Máscara zorroneja
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
        }

    }
}
