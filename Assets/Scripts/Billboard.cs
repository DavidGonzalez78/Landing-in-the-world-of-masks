using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform camTransform;

    private void Start()
    {
        // Encuentra la cámara del jugador (suponiendo que la cámara principal es la del jugador)
        camTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        if(camTransform != null)
        {
            // Orienta la UI para que siempre mire hacia la cámara del jugador
            Vector3 direction = camTransform.position - transform.position;
            direction.y = 0; // Opcional: mantener la UI en posición vertical
            transform.rotation = Quaternion.LookRotation(-direction);
        }
    }
} 
