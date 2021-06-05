using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private int hp = 2;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private int score = 100;
    private bool isDead = false;
    private bool isDamaged = false;

    private SpriteRenderer spriteRenderer = null;
    private GameManager gameManager = null;
    private Collider2D col = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isDead) return;
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if(transform.position.y<gameManager.MinPosition.y-2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Destroy(collision);
            Damaged();
        }
    }
    void Damaged()
    {
        if (isDamaged) return;
        hp--;
        if (hp <= 0)
        {
            Destroy(gameObject);
            isDead = false;
        }
    }

}
