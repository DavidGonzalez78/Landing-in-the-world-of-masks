using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeactiveThisObject : MonoBehaviour
{
    public float tiempoParaDestruir = 3f;
    private PlayerInput playerInput;
    // 1. Definimos el evento estático para que otros scripts puedan escucharlo.
    // Usamos 'Action' que es más sencillo que crear un delegate personalizado.
    public static event Action OnObjectDeactivate;

    private void Start()
    {
        playerInput = FindAnyObjectByType<PlayerInput>();
        StartCoroutine(Desactivacion(tiempoParaDestruir));
    }

    private void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Space))
        if (playerInput.actions["Skip"].WasPressedThisFrame())
        {
            TriggerDeactivation();
        }
    }

    // Método separado para poder llamarlo tanto desde Update como desde el Coroutine
    private void TriggerDeactivation()
    {
        // 2. INVOCAR EL EVENTO: Esto avisará a todos los que estén escuchando.
        // El '?' verifica si hay alguien suscrito antes de invocar para evitar errores.
        OnObjectDeactivate.Invoke();

        // 3. Desactivamos el objeto
        gameObject.SetActive(false);
    }

    IEnumerator Desactivacion(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        TriggerDeactivation(); // Llamamos a la lógica que contiene el evento
    }
}