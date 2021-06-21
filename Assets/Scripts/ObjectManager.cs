using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    //[SerializeField]
    //private GameObject enemyBread;
    //[SerializeField]
    //private GameObject enemyCandy;
    //[SerializeField]
    //private GameObject enemyCake;

    //[SerializeField]
    //private GameObject ingHam;
    //[SerializeField]
    //private GameObject ingDanmuzi;
    //[SerializeField]
    //private GameObject ingEgg;
    //[SerializeField]
    //private GameObject ingSigum;

    //private GameManager gameManager = null;
    //void Start()
    //{
    //    gameManager = FindObjectOfType<GameManager>();
    //    StartCoroutine(SpawnEnemy());
    //    for (int i = 0; i < 5; i++)
    //    {
    //        Instantiate(enemyBread, new Vector2(10f, 10f), Quaternion.identity);
    //    }
    //}
    //private IEnumerator SpawnEnemy()
    //{
    //    float randomDelay = Random.Range(0.1f, 5f);
    //    while (true)
    //    {
    //        PoolEnemy();
    //        yield return new WaitForSeconds(randomDelay);
    //    }
    //}
    //private GameObject PoolEnemy()
    //{
    //    int randomEnemy = Random.Range(1, 3);
    //    float randomx = Random.Range(-2f, 2f);
    //    float randomy = Random.Range(-2f, 2f);
    //    GameObject Enemy = null;

    //    if (gameManager.poolManager.transform.FindChild("bread"))
    //    {
    //        Enemy = gameManager.poolManager.transform.Find("bread").gameObject;
    //        gameObject.SetActive(true);
    //    }

    //    return Enemy;
    //}
}
