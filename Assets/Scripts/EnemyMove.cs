using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private int hp = 2;
    [SerializeField]
    private float speed = 5f;
    private bool isDead = false;
    private bool isDamaged = false;

    private GameManager gameManager = null;
    private Collider2D col = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        col = GetComponent<Collider2D>();
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
}
