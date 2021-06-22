using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private SpriteRenderer spriteRenderer = null;
    private GameManager gameManager = null;
    private SoundManager soundManager = null;
    private Collider2D col = null;
    private Animator anim = null;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        gameManager = FindObjectOfType<GameManager>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        CheckLimit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            soundManager.Dead();
            anim.Play("IngAnim");
            Despawn();
        }
    }
    private void CheckLimit()
    {

        if (transform.position.y < gameManager.MinPosition.y - 2f)
        {
            Despawn();
        }

    }

    private void Despawn()
    {
        gameObject.SetActive(false);
        transform.SetParent(gameManager.poolIngManager.transform, false);
    }

}
