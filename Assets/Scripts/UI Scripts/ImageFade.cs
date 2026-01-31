using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour
{
    private Image fadeImage;
    public float fadeSpeed = 1.5f;
    public bool sceneStarting = true;
    public bool inversoFade;

    private void Start()
    {
        fadeImage = GetComponent<Image>(); 
    }
    void Update()
    {
        if (sceneStarting && !inversoFade)
        {
            FadeToClear();
        }
        if (sceneStarting && inversoFade)
        {
            FadeToBlack();
        }

    }

    void FadeToClear()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, fadeSpeed * Time.deltaTime);
        if (fadeImage.color.a <= 0.05f)
        {
            fadeImage.color = Color.clear;
            fadeImage.enabled = false;
            sceneStarting = false;
        }
    }

    void FadeToBlack()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }
}
