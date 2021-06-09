using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private GameManager gameManager = null;
    private Collider2D col = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            DespawnEnemy();
        }
    }
    private void CheckLimit()
    {
        
        if (transform.position.y < gameManager.MinPosition.y - 2f)
        {
            DespawnEnemy();
        }

    }
    private void DespawnEnemy()
    {
        gameObject.SetActive(false);
        transform.SetParent(gameManager.poolManagerEnemy.transform, false);
    }
}
