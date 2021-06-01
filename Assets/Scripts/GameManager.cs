using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }

    [SerializeField]
    private GameObject enemy1, enemy2, enemy3;
    [SerializeField]
    private GameObject ingredient1, iingredient2, ingredient3, ingredient4;


    void Start()
    {
        MinPosition = new Vector2(-3f, -4f);
        MaxPosition = new Vector2(3f, 4f);
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
        
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
}
