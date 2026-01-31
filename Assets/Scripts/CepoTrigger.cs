
using UnityEngine;

public class CepoTrigger : MonoBehaviour
{
    public string nameNpc;
    private AtraerObjeto atraerObjeto;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == nameNpc)
        {
            atraerObjeto = other.GetComponent<AtraerObjeto>();
            atraerObjeto.velocidad = 0;
            atraerObjeto.puedeMoverse = false;
          
        }
    }
}
