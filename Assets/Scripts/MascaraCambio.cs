using UnityEngine;

public class MascaraCambio : MonoBehaviour
{
    public GameObject[] mascaras;

    void Update()
    {
        ActivarMascara();
    }

    void ActivarMascara()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            mascaras[0].SetActive(true);
            mascaras[1].SetActive(false);
            mascaras[2].SetActive(false);
            mascaras[3].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mascaras[0].SetActive(false);
            mascaras[1].SetActive(true);
            mascaras[2].SetActive(false);
            mascaras[3].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mascaras[0].SetActive(false);
            mascaras[1].SetActive(false);
            mascaras[2].SetActive(true);
            mascaras[3].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mascaras[0].SetActive(false);
            mascaras[1].SetActive(false);
            mascaras[2].SetActive(false);
            mascaras[3].SetActive(true);
        }
    }
}
