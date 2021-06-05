using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }

    private int score = 0;
    private int life = 3;
    private int highscore = 500;
    public int Danmuzi = 0;
    public int Egg = 0;
    public int Ham = 0;
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

    public PoolManager poolManager { get; private set; }

    void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
        MinPosition = new Vector2(-3f, -4f);
        MaxPosition = new Vector2(3f, 4f);
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnIng());
        AddScore();
    }
    private IEnumerator SpawnEnemy()
    {
        float randomX = 0f;
        float randomDelay = 0f;
        int randomEnemy;
        while(true)
        {
            randomEnemy = Random.Range(1, 4);
            randomX = Random.Range(-1.5f, 1.5f);
            randomDelay = Random.Range(1f, 10f);
            switch(randomEnemy)
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
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(randomDelay);
    }
    private IEnumerator SpawnIng()
    {
        float randomX = 0f;
        float randomDelay = 0f;
        int randomIng;
        while(true)
        {
            randomIng = Random.Range(1, 4);
            randomX = Random.Range(-1.5f, 1.5f);
            randomDelay = Random.Range(1f, 10f);
            switch(randomIng)
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
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(randomDelay);
    }
    private void AddScore()
    {
        while(true)
        {
        if (Danmuzi >= 1 && Egg >= 1 && Ham >= 1 && Sigumchi >= 1)
        {
            score += 10;
            Danmuzi--;
            Egg--;
            Ham--;
            Sigumchi--;
        }
        else
            continue;

        }
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
}
