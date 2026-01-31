using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nave : MonoBehaviour
{

    public Animator anim;
    private int counter; 
    public int anim_speed; 

    // Start is called before the first frame update
    void Start()
    {
        counter = 0; 
    }

    // Update is called once per frame
    void Update()
    {

        if (counter>=anim_speed)
        {
            counter = 0; 
            float x;

            if (Random.Range(0,10) < 6)
            {
                x = 0.75f;
            }
            else
            {
                x = Random.Range(0.0f,1.0f);
            }

            anim.SetFloat("frame",x);
        }
        

        

        counter ++;
    }
}
