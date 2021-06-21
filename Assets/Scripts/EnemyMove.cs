using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    protected GameManager gameManager = null;
    private SpriteRenderer spriteRenderer=null;
    private Collider2D col = null;
    protected virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        if(CompareTag("candy"))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        CheckLimit();
    }

    private void CheckLimit()
    {
        
        if (transform.position.y < gameManager.MinPosition.y - 2f)
        {
            Despawn();
        }

        if(transform.position.x < gameManager.MinPosition.x - 2f)
        {
            Despawn();
        }
    }
        private void Despawn()
        {
            gameObject.SetActive(false);
            transform.SetParent(gameManager.objectManager.transform, false);
        }
}
