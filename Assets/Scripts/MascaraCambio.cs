using UnityEngine;

public class MascaraCambio : MonoBehaviour
{
    public GameObject[] mascaras;

    public bool heCogidoLaMascara1, heCogidoLaMascara2, heCogidoLaMascara3, heCogidoLaMascara4;

    void Update()
    {
        ActivarMascara();
    }

    public void MascaraRecogida1()
    {
        heCogidoLaMascara1 = true;
    }
    public void MascaraRecogida2()
    {
        heCogidoLaMascara2 = true;
    }
    public void MascaraRecogida3()
    {
        heCogidoLaMascara3 = true;
    }
    public void MascaraRecogida4()
    {
        heCogidoLaMascara4 = true;
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
        if (Input.GetKeyDown(KeyCode.Alpha2) && heCogidoLaMascara2)
        {
            mascaras[0].SetActive(false);
            mascaras[1].SetActive(true);
            mascaras[2].SetActive(false);
            mascaras[3].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && heCogidoLaMascara3)
        {
            mascaras[0].SetActive(false);
            mascaras[1].SetActive(false);
            mascaras[2].SetActive(true);
            mascaras[3].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && heCogidoLaMascara4)
        {
            mascaras[0].SetActive(false);
            mascaras[1].SetActive(false);
            mascaras[2].SetActive(false);
            mascaras[3].SetActive(true);
        }
    }
}
