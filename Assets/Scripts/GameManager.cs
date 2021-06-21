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

    [Header("생명")]
    [SerializeField]
    private GameObject Life1, Life2;
    [Header("적")]
    [SerializeField]
    private GameObject Ebread, Ecandy, Ecake;
    [Header("재료")]
    [SerializeField]
    private GameObject Idanmuzi, Iham, Isigum, Iegg;

    public PoolingManager poolManager { get; private set; }
    public ObjectManager objectManager { get; private set; }
    protected virtual void Awake()
    {
        highscore = PlayerPrefs.GetInt("HIGHSCORE");
        MinPosition = new Vector2(-2.3f, -4.3f);
        MaxPosition = new Vector2(2.06f, 2.31f);
        UpdateUI();
        poolManager = FindObjectOfType<PoolingManager>();
        objectManager = FindObjectOfType<ObjectManager>();
        StartCoroutine(EnemySpawn());
    }

    private IEnumerator EnemySpawn()
    {
        float randomDelay = Random.Range(0.2f, 10f);
        while (true)
        {
            InstanEnemy();
            yield return new WaitForSeconds(randomDelay);
        }
    }
    private GameObject InstanEnemy()
    {
        GameObject enemy = null;
        int randomE = Random.Range(1, 4);
        float randomx = Random.Range(-2f, 2f);
        float randomy = Random.Range(-2f, 2f);
        if (objectManager.transform.childCount > 0)
        {
            enemy = objectManager.transform.GetChild(0).gameObject;
            enemy.transform.position = new Vector2(randomx, 2f);
            enemy.transform.SetParent(null);
            enemy.SetActive(true);
        }
        else
        {
                switch(randomE)
                {
                    case 1:
                        GameObject enemyB = Instantiate(Ebread, new Vector2(randomx, 2f), Quaternion.identity);
                        enemyB.transform.SetParent(null);
                        enemy = enemyB;
                        break;
                    case 2:
                        GameObject enemyCan = Instantiate(Ecandy, new Vector2(2f, randomy), Quaternion.identity);
                        enemyCan.transform.SetParent(null);
                        enemy = enemyCan;
                        break;
                    case 3:
                        GameObject enemyCake = Instantiate(Ecake, new Vector2(randomx, 2f), Quaternion.identity);
                        enemyCake.transform.SetParent(null);
                        enemy = enemyCake;
                        break;
            }
        }
        return enemy;
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
        textScore.text = string.Format("가격  {0}", score);
        textSscore.text = string.Format("{0}", Sigumchi);
        textHscore.text = string.Format("{0}", Ham);
        textDscore.text = string.Format("{0}", Danmuzi);
        textEscore.text = string.Format("{0}", Egg);
    }
    public void LifeDead()
    {
        life--;
        if (life==2)
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
