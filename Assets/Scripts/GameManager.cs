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

    //프리펩
    [Header("생명")]
    [SerializeField]
    private GameObject Life1, Life2;
    [Header("적 프리펩")]
    [SerializeField]
    private GameObject Ebread, Ecandy, Ecake;
    [Header("재료 프리펩")]
    [SerializeField]
    private GameObject Idanmuzi, Iham, Isigum, Iegg;

    //풀링매니저
    public PoolingManager poolManager { get; private set; }
    public ObjectManager poolEnemyManager { get; private set; }
    public IngPooling poolIngManager { get; private set; }

    private void Awake()
    {
        highscore = PlayerPrefs.GetInt("HIGHSCORE");
        MinPosition = new Vector2(-2.3f, -4.3f);
        MaxPosition = new Vector2(2.06f, 2.31f);
        UpdateUI();
        poolManager = FindObjectOfType<PoolingManager>();
        poolEnemyManager = FindObjectOfType<ObjectManager>();
        poolIngManager = FindObjectOfType<IngPooling>();
        StartSpawn();
        StartCoroutine(EnemySpawn());
        StartCoroutine(IngSpawn());
    }

    //시작 자식 스폰
    private void StartSpawn()
    {
        GameObject obj;
        obj = Instantiate(Ebread, new Vector2(2f, 4f), Quaternion.identity);
        obj.transform.SetParent(poolEnemyManager.transform, false);
        obj.SetActive(false);
        obj = Instantiate(Ecandy, new Vector2(2f, 4f), Quaternion.identity);
        obj.SetActive(false);
        obj.transform.SetParent(poolEnemyManager.transform, false);
        obj = Instantiate(Ecake, new Vector2(2f, 4f), Quaternion.identity);
        obj.SetActive(false);
        obj.transform.SetParent(poolEnemyManager.transform, false);

        obj = Instantiate(Idanmuzi, new Vector2(2f, 4f), Quaternion.identity);
        obj.SetActive(false);
        obj.transform.SetParent(poolIngManager.transform, false);
        obj = Instantiate(Isigum, new Vector2(2f, 4f), Quaternion.identity);
        obj.SetActive(false);
        obj.transform.SetParent(poolIngManager.transform, false);
        obj = Instantiate(Iham, new Vector2(2f, 4f), Quaternion.identity);
        obj.SetActive(false);
        obj.transform.SetParent(poolIngManager.transform, false);
        obj = Instantiate(Iegg, new Vector2(2f, 4f), Quaternion.identity);
        obj.SetActive(false);
        obj.transform.SetParent(poolIngManager.transform, false);
    }

    //적 풀링 실행
    private IEnumerator EnemySpawn()
    {
        float randomDelay = Random.Range(0.2f, 5f);
        while (true)
        {
            InstanEnemy();
            yield return new WaitForSeconds(randomDelay);
        }
    }

    //재료 풀링 실행
    private IEnumerator IngSpawn()
    {
        float randomDelay = Random.Range(0.2f, 4f);
        while (true)
        {
            InstanIng();
            yield return new WaitForSeconds(randomDelay);
        }
    }

    //재료 풀링
    private GameObject InstanIng()
    {
        GameObject ing = null;
        int randomI = Random.Range(1, 5);
        float randomx = Random.Range(-2f, 2f);
        if (poolIngManager.transform.childCount > 0)
        {
            ing = poolIngManager.transform.GetChild(0).gameObject;
            ing.transform.position = new Vector2(randomx, 4f);
            ing.transform.SetParent(null);
            ing.SetActive(true);
        }
        else
        {
            switch (randomI)
            {
                case 1:
                    ing = Idanmuzi;
                    break;
                case 2:
                    ing = Isigum;
                    break;
                case 3:
                    ing = Iegg;
                    break;
                case 4:
                    ing = Iham;
                    break;
            }
            GameObject newIng = Instantiate(ing, new Vector2(randomx, 4f), Quaternion.identity);
            ing = newIng;
            newIng.SetActive(true);
        }
        return ing;
    }

    //적 풀링
    private GameObject InstanEnemy()
    {
        GameObject enemy = null;
        int randomE = Random.Range(1, 4);
        float randomx = Random.Range(-2f, 2.2f);
        float randomy = Random.Range(-4f, 2.2f);
        if (poolEnemyManager.transform.childCount > 0)
        {
            enemy = poolEnemyManager.transform.GetChild(0).gameObject;
            if (enemy.CompareTag("Cake"))
                enemy.transform.position = new Vector2(2.3f, randomy);
            else
                enemy.transform.position = new Vector2(randomx, 4f);
            enemy.transform.SetParent(null);
            enemy.SetActive(true);
        }
        else
        {
            switch (randomE)
            {
                case 1:
                    enemy = Ebread;
                    break;
                case 2:
                    enemy = Ecake;
                    break;
                case 3:
                    enemy = Ecandy;
                    break;
            }
            GameObject newEnemy = null;
            if (enemy.CompareTag("Cake"))
            {
                newEnemy = Instantiate(Ecandy, new Vector2(2.2f, randomy), Quaternion.identity);
            }
            else
                newEnemy = Instantiate(enemy, new Vector2(randomx, 4f), Quaternion.identity);
            enemy = newEnemy;
            enemy.SetActive(true);
        }
        return enemy;
    }
    //점수
    public void AddScore()
    {
        if (Danmuzi >= 1 && Egg >= 1 && Ham >= 1 && Sigumchi >= 1)
        {
            Danmuzi--;
            Egg--;
            Ham--;
            Sigumchi--;
            score += 10;
            if (score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt("HIGHSCORE", highscore);
            }
            UpdateUI();
        }
        else
            UpdateUI();
    }

    //UI 새로고침
    public void UpdateUI()
    {
        textScore.text = string.Format("가격 {0}", score);
        textSscore.text = string.Format("{0}", Sigumchi);
        textHscore.text = string.Format("{0}", Ham);
        textDscore.text = string.Format("{0}", Danmuzi);
        textEscore.text = string.Format("{0}", Egg);
    }

    //데미지
    public void LifeDead()
    {
        life--;
        if (life == 2)
        {
            Life1.SetActive(false);
        }
        else if (life == 1)
        {
            Life2.SetActive(false);
        }
        if (life <= 0)
        {
            PlayerPrefs.SetInt("SCORE", score);
            PlayerPrefs.SetInt("HIGHSCORE", highscore);
            SceneManager.LoadScene("GameOver");
        }
    }
}
