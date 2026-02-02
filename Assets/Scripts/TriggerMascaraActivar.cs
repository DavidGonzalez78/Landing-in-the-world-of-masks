
using UnityEngine;

public class TriggerMascaraActivar : MonoBehaviour
{
    private MascaraCambio mascaraPlayer;
    public int mascaraIndice;
    private ActivarTexto texto;

    public AudioSource audioSource;
    private void Start()
    {
        
        mascaraPlayer = GameObject.Find("Player").GetComponent<MascaraCambio>();
        texto = FindAnyObjectByType<ActivarTexto>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Mascara01") || other.CompareTag("Mascara02") || other.CompareTag("Mascara03") || other.CompareTag("Mascara04"))
        {
            if(mascaraIndice == 1)
            {
                mascaraPlayer.MascaraRecogida1();
                //texto.CambiarTexto("Has adquirido la Máscara! Con esta Máscara podrás ocultar tu identidad alienígena");
                audioSource.Play();
            }
            if (mascaraIndice == 2)
            {
                mascaraPlayer.MascaraRecogida2();
                mascaraPlayer.mascaras[0].gameObject.SetActive(false);
                mascaraPlayer.mascaras[1].gameObject.SetActive(true);
                mascaraPlayer.mascaras[2].gameObject.SetActive(false);
                mascaraPlayer.mascaras[3].gameObject.SetActive(false);
                //texto.CambiarTexto("Has adquirido la Máscara del Zorronejo! Con esta Máscara podrás infiltrarte en su tribu!");
                audioSource.Play();
            }
            if (mascaraIndice == 3)
            {
                mascaraPlayer.MascaraRecogida3();
                mascaraPlayer.mascaras[0].gameObject.SetActive(false);
                mascaraPlayer.mascaras[1].gameObject.SetActive(false);
                mascaraPlayer.mascaras[2].gameObject.SetActive(true);
                mascaraPlayer.mascaras[3].gameObject.SetActive(false);
                //texto.CambiarTexto("Has adquirido la Máscara del Jabalí! Con esta Máscara podrás asustar al Guardia!");
                audioSource.Play();
            }
            if (mascaraIndice == 4)
            {
                mascaraPlayer.MascaraRecogida4();
                mascaraPlayer.mascaras[0].gameObject.SetActive(false);
                mascaraPlayer.mascaras[1].gameObject.SetActive(false);
                mascaraPlayer.mascaras[2].gameObject.SetActive(false);
                mascaraPlayer.mascaras[3].gameObject.SetActive(true);
                texto.CambiarTexto("Ahora los habitantes me adoran. Creen que soy su profeta. ");
            }
             gameObject.SetActive(false );
            audioSource.Play();
        }
    }

}
