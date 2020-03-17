using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] float sceneChangeDelay = 1f;
    
    public float healthMod;
    public float damageMod;
    public float enemySpawnMod;

    public const float healthIncrease = 0.2f;
    public const float damageIncrease = 0.15f;
    public const float enemySpawnIncrease = 0.15f;

    int level = 1;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        CalculateValues();
        gameObject.SetActive(true);
    }
    public void StartLevel()
    {
        CalculateValues();
        instance.StartCoroutine(LoadLevel());
    }
    public IEnumerator LoadLevel()
    {
        FadeToBlack.instance.Fade(1f, 1f);
        yield return new WaitForSeconds(sceneChangeDelay);
        SceneManager.LoadScene("Level");
    }
    void CalculateValues()
    {
        damageMod = damageIncrease * (level - 1) + 1;
        healthMod = healthIncrease * (level - 1) + 1;
        enemySpawnMod = enemySpawnIncrease * (level - 1) + 1;
    }
    public IEnumerator EndLevel()
    {
        level += 1;
        FadeToBlack.instance.Fade(1f, 1f);
        yield return new WaitForSeconds(sceneChangeDelay);
        SceneManager.LoadScene("LevelMenu");
    }
    public int GetLevel()
    {
        return level;
    }
    void Update()
    {
        
    }
}
