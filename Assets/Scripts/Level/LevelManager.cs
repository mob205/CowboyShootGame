using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] float sceneChangeDelay = 1f;
    
    [HideInInspector] public float healthMod;
    [HideInInspector] public float damageMod;
    [HideInInspector] public float maxEnemySpawnMod;
    [HideInInspector] public float enemyPerLevelMod;

    [SerializeField] private float healthIncrease = 0.2f;
    [SerializeField] private float damageIncrease = 0.15f;
    [SerializeField] private float maxEnemySpawnIncrease = 0.25f;
    [SerializeField] private int enemyPerLevelIncrease = 1;

    int level = 1;
    Coroutine loadLevelCorout;

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
    }
    public void StartLevel()
    {
        if (loadLevelCorout != null) { return; }
        CalculateValues();
        loadLevelCorout = instance.StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        FadeToBlack.instance.Fade(1f, 1f);
        yield return new WaitForSeconds(sceneChangeDelay);
        SceneManager.LoadScene("Level");
        loadLevelCorout = null;
        yield return 0;
        if (UpgradeManager.instance)
        {
            UpgradeManager.instance.ApplyUpgrades();
        }
    }
    void CalculateValues()
    {
        instance.damageMod = damageIncrease * (instance.level - 1) + 1;
        instance.healthMod = healthIncrease * (instance.level - 1) + 1;
        instance.maxEnemySpawnMod = maxEnemySpawnIncrease * (instance.level - 1) + 1;
        instance.enemyPerLevelMod = enemyPerLevelIncrease * (instance.level - 1);
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
