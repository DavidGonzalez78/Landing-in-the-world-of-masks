using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class nave : MonoBehaviour
{

    public Animator anim;
    private int counter; 
    public int anim_speed; 
    public GameObject player; 
    public int distancia_minima_para_hablar; 
    private ActivarTexto text_script; 

    // Start is called before the first frame update
    void Start()
    {
        counter = 0; 
        text_script = FindAnyObjectByType<ActivarTexto>();
    }

    // Update is called once per frame
    void Update()
    {
        //Animaciones
        if (counter>=anim_speed)
        {
            counter = 0; 
            float x;
            if (Random.Range(0,10) < 6)
                x = 0.75f;
            else
                x = Random.Range(0.0f,1.0f);

            anim.SetFloat("frame",x);
        }
        counter ++;


        //Decirle al jugador que se busque peña
        float distancia = Vector3.Distance(transform.position, player.transform.position);
        if (distancia < distancia_minima_para_hablar)
        {
            text_script.CambiarTexto("El protagonista intenta desatascar la nave, pero es demasiado pesada. Quizás necesitará ayuda para conseguirlo...");
        }

        print(distancia);
    }
}
