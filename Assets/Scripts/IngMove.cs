using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngMove : MonoBehaviour
{
    [SerializeField]
    private int hp = 2;
    [SerializeField]
    private float speed = 5f;
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Damaged();
            collision.gameObject.SetActive(false);
        }
    }
    void Damaged()
    {
        if (isDamaged) return;
        hp--;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
            gameManager.InstantiateOrPoolIng();
            isDead = false;
        }
    }
    private void CheckLimit()
    {

        if (transform.position.y < gameManager.MinPosition.y - 2f)
        {
            DespawnIng();
        }

    }
    private void DespawnIng()
    {
        gameObject.SetActive(false);
        transform.SetParent(gameManager.poolManagerIng.transform, false);
    }
}
