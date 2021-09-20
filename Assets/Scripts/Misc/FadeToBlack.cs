 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public static FadeToBlack instance;

    CanvasGroup panel;

    Coroutine fadeCorout;

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
    void Start()
    {
        panel = GetComponent<CanvasGroup>();
    }
    public void StartFade(float fadeSpeed, float fadeDuration)
    {
        if(fadeCorout != null)
        {
            StopCoroutine(fadeCorout);
        }
        fadeCorout = StartCoroutine(Fade(fadeSpeed, fadeDuration));
    }
    IEnumerator Fade(float fadeSpeed, float fadeDuration)
    {
        // Fade to black
        while (panel.alpha < 1)
        {
            panel.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
        // Wait full duration
        yield return new WaitForSeconds(fadeDuration);
        // Fade to transparent
        while (panel.alpha > 0)
        {
            panel.alpha -= Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
}
