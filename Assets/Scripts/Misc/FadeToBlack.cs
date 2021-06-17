 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public static FadeToBlack instance;

    CanvasGroup panel;

    Coroutine fadeIn;
    Coroutine fadeOut;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (fadeIn == null && fadeOut == null && panel.alpha > 0)
        {
            Debug.Log("Detected problem.");
            panel.alpha = 1;
        }
    }
    void Start()
    {
        panel = GetComponent<CanvasGroup>();
    }
    public void Fade(float fadeSpeed, float fadeDuration)
    {
        if(fadeIn != null && fadeOut != null)
        {
            StopCoroutine(fadeIn);
            StopCoroutine(fadeOut);
        }
        fadeIn = StartCoroutine(FadeIn(fadeSpeed));
        fadeOut = StartCoroutine(FadeOut(fadeSpeed, fadeDuration));
    }
    IEnumerator FadeIn(float fadeSpeed)
    {
        while (panel.alpha < 1)
        {
            panel.alpha += Time.deltaTime * fadeSpeed;
            yield return null; 
        }
    }
    IEnumerator FadeOut(float fadeSpeed, float fadeDuration)
    {
        yield return new WaitForSeconds(fadeDuration);
        while (panel.alpha > 0)
        {
            panel.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}
