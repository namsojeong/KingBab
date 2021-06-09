using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }

    public int score = 0;
    private int life = 3;
    private int highscore = 0;
    public int Danmuzi = 0;
    public int Egg = 0;
    public int Ham = 0;
    [SerializeField]
    public int Sigumchi = 0;

    [Header("점수")]
    [SerializeField]
    private Text textScore = null;
    [SerializeField]
    private Text textSscore = null;
    [SerializeField]
    private Text textHscore = null;
    [SerializeField]
    private Text textEscore = null;
    [SerializeField]
    private Text textDscore = null;

    [Header("적 프리펩")]

    [SerializeField]
    private GameObject enemy1, enemy2, enemy3;
    [Header("재료 프리팹")]

    [SerializeField]
    private GameObject ingredient1, ingredient2, ingredient3, ingredient4;
    [Header("생명")]
    [SerializeField]
    private GameObject Life1, Life2;

    public PoolManager poolManager { get; private set; }
    public PoolManagerIng poolManagerIng { get; private set; }
    public PoolmanagerEnemy poolManagerEnemy { get; private set; }

    void Awake()
    {
        highscore = PlayerPrefs.GetInt("HIGHSCORE");
        poolManager = FindObjectOfType<PoolManager>();
        poolManagerEnemy = FindObjectOfType<PoolmanagerEnemy>();
        poolManagerIng = FindObjectOfType<PoolManagerIng>();
        MinPosition = new Vector2(-3f, -4f);
        MaxPosition = new Vector2(3f, 4f);
        UpdateUI();
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnIng());
    }

    private IEnumerator SpawnEnemy()
    {
        float randomX = 0f;
        int randomEnemy;
        float randomDelay = Random.Range(0.1f, 1.3f);
        while (true)
        {
            InstantiateOrPoolEnemy();
            yield return new WaitForSeconds(randomDelay);
        }
    }
    private IEnumerator SpawnIng()
    {
        float randomX = 0f;
        int randomIng;
        float randomDelay = Random.Range(2f, 20f);

        while (true)
        {
            InstantiateOrPoolIng();
            yield return new WaitForSeconds(randomDelay);
        }
    }
    public GameObject InstantiateOrPoolEnemy()
    {
        float randomX = 0f;
        int randomEnemy;
        GameObject result = null;
        if (poolManagerEnemy.transform.childCount > 0)
        {
            if (poolManagerEnemy.transform.childCount > 0)
            {
                result = poolManagerEnemy.transform.GetChild(0).gameObject;
                result.transform.position = new Vector2(randomX, 3.9f);
                result.transform.SetParent(null);
                result.SetActive(true);
            }
        }
        else
        {
            randomEnemy = Random.Range(1, 5);
            randomX = Random.Range(-1.5f, 1.5f);
            switch (randomEnemy)
            {
                case 1:
                    Instantiate(enemy1, new Vector2(randomX, 3.9f), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(enemy2, new Vector2(randomX, 3.9f), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(enemy3, new Vector2(randomX, 3.9f), Quaternion.identity);
                    break;
            }
        }
        return result;
    }

    public GameObject InstantiateOrPoolIng()
    {
        float randomX = 0f;
        int randomIng;
        GameObject result = null;
        if (poolManagerIng.transform.childCount > 0)
        {
            if (poolManagerIng.transform.childCount > 0)
            {
                result = poolManagerIng.transform.GetChild(0).gameObject;
                result.transform.position = new Vector2(randomX, 3.9f);
                result.transform.SetParent(null);
                result.SetActive(true);
            }
        }
        else
        {
            randomIng = Random.Range(1, 5);
            randomX = Random.Range(-1.5f, 1.5f);
            switch (randomIng)
            {
                case 1:
                    Instantiate(ingredient1, new Vector2(randomX, 3.9f), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(ingredient2, new Vector2(randomX, 3.9f), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(ingredient3, new Vector2(randomX, 3.9f), Quaternion.identity);
                    break;
                case 4:
                    Instantiate(ingredient4, new Vector2(randomX, 3.9f), Quaternion.identity);
                    break;
            }
        }
        return result;
    }
    public void AddScore()
    {
        if (Danmuzi >= 1 && Egg >= 1 && Ham >= 1 && Sigumchi >= 1)
        {
            Danmuzi--;
            Egg--;
            Ham--;
            Sigumchi--;
            score = score + 10;
            if(score>highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt("HIGHSCORE", highscore);
            }
            UpdateUI();
        }
        else
            UpdateUI();
    }
    public void UpdateUI()
    {
        textScore.text = string.Format("가격 {0}", score);
        textSscore.text = string.Format("{0}", Sigumchi);
        textHscore.text = string.Format("{0}", Ham);
        textDscore.text = string.Format("{0}", Danmuzi);
        textEscore.text = string.Format("{0}", Egg);
    }
    public void LifeDead()
    {
        life--;
        if(life==2)
        {
            Life1.SetActive(false);
        }
        else if(life==1)
        {
            Life2.SetActive(false);
        }
        if(life<=0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
