using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeSencillo : MonoBehaviour
{
    public Image fadeImage; // Arrastra tu imagen aquí en el inspector
    public float velocidad = 1.5f;

    void Start()
    {
        // Iniciamos el fade directamente al comenzar
        StartCoroutine(AparecerImagen());
    }

    IEnumerator AparecerImagen()
    {
        // 1. Aseguramos que empiece invisible (Alpha 0)
        Color colorActual = fadeImage.color;
        colorActual.a = 0;
        fadeImage.color = colorActual;

        // 2. Mientras el alpha sea menor que 1, seguimos aumentando
        while (fadeImage.color.a < 1)
        {
            // Aumentamos el alpha gradualmente
            colorActual = fadeImage.color;
            colorActual.a += velocidad * Time.deltaTime;
            fadeImage.color = colorActual;

            // Esperamos un frame antes de seguir
            yield return null;
        }

        // 3. Forzamos que sea totalmente opaco al final para que quede limpio
        colorActual.a = 1;
        fadeImage.color = colorActual;
    }
}