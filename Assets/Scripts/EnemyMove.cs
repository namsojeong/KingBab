using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    protected GameManager gameManager = null;
    private SpriteRenderer spriteRenderer = null;
    private Collider2D col = null;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    //스폰 코드
    protected void Despawn()
    {
        gameObject.SetActive(false);
        transform.SetParent(gameManager.poolEnemyManager.transform, false);
    }
}
