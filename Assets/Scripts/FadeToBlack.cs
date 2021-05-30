using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public static FadeToBlack instance;

    CanvasGroup panel;
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
    public void Fade(float fadeSpeed, float fadeDuration)
    {
        StartCoroutine(FadeIn(fadeSpeed));
        StartCoroutine(FadeOut(fadeSpeed, fadeDuration));
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
    void Update()
    {
        
    }
}
