using UnityEngine;
using UnityEngine.UI;

public class MascaraCambio : MonoBehaviour
{
    public GameObject[] mascaras;

    public bool heCogidoLaMascara1, heCogidoLaMascara2, heCogidoLaMascara3, heCogidoLaMascara4;
    private PlayerController playerController;  
  
    public GameObject imagenMascara1Seleccionada, imagenMascara1Activa, imagenMascara1Desactivada, imagenMascara2Seleccionada, imagenMascara2Activa, imagenMascara2Desactivada, imagenMascara3Seleccionada, imagenMascara3Activa, imagenMascara3Desactivada, imagenMascara4Seleccionada, imagenMascara4Activa, imagenMascara4Desactivada;

    public Color colorSeleccionado;
    public Color colorDefault;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        ActivarMascara();
    }

    public void MascaraRecogida1()
    {
        Debug.Log("Mascara recogida 1");
        playerController.mascara_index = 1;
        heCogidoLaMascara1 = true;
        ActivaMascaraGUI(1);
    }
    public void MascaraRecogida2()
    {
        Debug.Log("Mascara recogida 2");
        playerController.mascara_index = 2;
        heCogidoLaMascara2 = true;
        ActivaMascaraGUI(2);

    }
    public void MascaraRecogida3()
    {
        Debug.Log("Mascara recogida 3");
        playerController.mascara_index = 3;
        heCogidoLaMascara3 = true;
        ActivaMascaraGUI(3);
    }
    public void MascaraRecogida4()
    {
        Debug.Log("Mascara recogida 4");
        playerController.mascara_index = 4;
        heCogidoLaMascara4 = true;
        ActivaMascaraGUI(4);
    }
    void ActivarMascara()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            mascaras[0].SetActive(true);
            mascaras[1].SetActive(false);
            mascaras[2].SetActive(false);
            mascaras[3].SetActive(false);

            playerController.mascara_index = 1;
            ActivaMascaraGUI(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && heCogidoLaMascara2)
        {
            mascaras[0].SetActive(false);
            mascaras[1].SetActive(true);
            mascaras[2].SetActive(false);
            mascaras[3].SetActive(false);

            playerController.mascara_index = 2;
            ActivaMascaraGUI(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && heCogidoLaMascara3)
        {
            mascaras[0].SetActive(false);
            mascaras[1].SetActive(false);
            mascaras[2].SetActive(true);
            mascaras[3].SetActive(false);

            playerController.mascara_index = 3;
            ActivaMascaraGUI(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && heCogidoLaMascara4)
        {
            mascaras[0].SetActive(false);
            mascaras[1].SetActive(false);
            mascaras[2].SetActive(false);
            mascaras[3].SetActive(true);

            playerController.mascara_index = 4;
            ActivaMascaraGUI(4);
        }
    }

    public void ActivaMascaraGUI(int numero)
    {
        if (numero == 1) 
        {
            imagenMascara1Seleccionada.GetComponent<Image>().color = colorSeleccionado;
            imagenMascara1Activa.SetActive(true);
            imagenMascara1Desactivada.SetActive(false);

            imagenMascara2Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara2Activa.SetActive(false);
            imagenMascara2Desactivada.SetActive(true);

            imagenMascara3Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara3Activa.SetActive(false);
            imagenMascara3Desactivada.SetActive(true);

            imagenMascara4Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara4Activa.SetActive(false);
            imagenMascara4Desactivada.SetActive(true);
        }
        if (numero == 2) 
        {
            imagenMascara1Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara1Activa.SetActive(false);
            imagenMascara1Desactivada.SetActive(true);

            imagenMascara2Seleccionada.GetComponent<Image>().color = colorSeleccionado;
            imagenMascara2Activa.SetActive(true);
            imagenMascara2Desactivada.SetActive(false);

            imagenMascara3Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara3Activa.SetActive(false);
            imagenMascara3Desactivada.SetActive(true);

            imagenMascara4Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara4Activa.SetActive(false);
            imagenMascara4Desactivada.SetActive(true);
        }
        if (numero == 3) 
        {
            imagenMascara1Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara1Activa.SetActive(false);
            imagenMascara1Desactivada.SetActive(true);

            imagenMascara2Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara2Activa.SetActive(false);
            imagenMascara2Desactivada.SetActive(true);

            imagenMascara3Seleccionada.GetComponent<Image>().color = colorSeleccionado;
            imagenMascara3Activa.SetActive(true);
            imagenMascara3Desactivada.SetActive(false);

            imagenMascara4Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara4Activa.SetActive(false);
            imagenMascara4Desactivada.SetActive(true);
        }
        if (numero == 4) 
        {
            imagenMascara1Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara1Activa.SetActive(false);
            imagenMascara1Desactivada.SetActive(true);

            imagenMascara2Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara2Activa.SetActive(false);
            imagenMascara2Desactivada.SetActive(true);

            imagenMascara3Seleccionada.GetComponent<Image>().color = colorDefault;
            imagenMascara3Activa.SetActive(false);
            imagenMascara3Desactivada.SetActive(true);

            imagenMascara4Seleccionada.GetComponent<Image>().color = colorSeleccionado;
            imagenMascara4Activa.SetActive(true);
            imagenMascara4Desactivada.SetActive(false);
        }
    }
}
