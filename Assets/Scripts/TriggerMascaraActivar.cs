
using UnityEngine;

public class TriggerMascaraActivar : MonoBehaviour
{
    private MascaraCambio mascaraPlayer;
    public int mascaraIndice;
   
    private void Start()
    {
        mascaraPlayer = GameObject.Find("Player").GetComponent<MascaraCambio>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Mascara01") || other.CompareTag("Mascara02") || other.CompareTag("Mascara03") || other.CompareTag("Mascara04"))
        {
            if(mascaraIndice == 1)
            {
                mascaraPlayer.MascaraRecogida1();
            }
            if (mascaraIndice == 2)
            {
                mascaraPlayer.MascaraRecogida2();
                mascaraPlayer.mascaras[0].gameObject.SetActive(false);
                mascaraPlayer.mascaras[1].gameObject.SetActive(true);
                mascaraPlayer.mascaras[2].gameObject.SetActive(false);
                mascaraPlayer.mascaras[3].gameObject.SetActive(false);
            }
            if (mascaraIndice == 3)
            {
                mascaraPlayer.MascaraRecogida3();
                mascaraPlayer.mascaras[0].gameObject.SetActive(false);
                mascaraPlayer.mascaras[1].gameObject.SetActive(false);
                mascaraPlayer.mascaras[2].gameObject.SetActive(true);
                mascaraPlayer.mascaras[3].gameObject.SetActive(false);
            }
            if (mascaraIndice == 4)
            {
                mascaraPlayer.MascaraRecogida4();
                mascaraPlayer.mascaras[0].gameObject.SetActive(false);
                mascaraPlayer.mascaras[1].gameObject.SetActive(false);
                mascaraPlayer.mascaras[2].gameObject.SetActive(false);
                mascaraPlayer.mascaras[3].gameObject.SetActive(true);
            }
             gameObject.SetActive(false );
        }
    }

}
