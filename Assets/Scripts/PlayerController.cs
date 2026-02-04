
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    private CharacterController controller;
    private PlayerInput playerInput; // Esto maneja el input del player WASD y ahora el touch
    public int mascara_index = 0;
    public GameObject particulasStun;
    [SerializeField] private float playerSpeed = 5.0f;

    public float stunTime; 
    private bool isStun;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.actions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement antiguo
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        // declaración del input para coger el move del player
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();

        // movimiento nuevo a través del new input system
        Vector3 move = new Vector3(input.x, 0, input.y);

        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
        // Final movement

        if(!isStun)
        {
            Vector3 finalMove = move * playerSpeed;
            controller.Move(finalMove * Time.deltaTime);
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
