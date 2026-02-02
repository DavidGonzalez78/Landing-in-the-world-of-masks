
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private CharacterController controller;
    private Vector3 playerVelocity;
    public int mascara_index = 0;
    public GameObject particulasStun;
    [SerializeField] private float playerSpeed = 5.0f;

    public float stunTime; 
    private bool isStun;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        // Horizontal movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
        // Final movement

        if(!isStun)
        {   
            Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
            controller.Move(finalMove * Time.deltaTime);
        }
        if (transform.position.y != 0f)
        {
            // Es mejor crear un Vector3 nuevo para modificarlo
            Vector3 flatPos = transform.position;
            flatPos.y = 0f;
            transform.position = flatPos;
        }
    }

    public void StunPlayer()
    {
        isStun = true;
        controller.Move(Vector3.zero);
        particulasStun.GetComponent<ParticleSystem>().Play();
        StartCoroutine(TiempoStun(stunTime));

    }

    private IEnumerator TiempoStun(float time)
    {
        yield return new WaitForSeconds(time);
        particulasStun.GetComponent<ParticleSystem>().Stop();
        isStun=false;
    }
}
