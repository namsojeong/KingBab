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
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        gameManager = FindObjectOfType<GameManager>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        CheckLimit();
    }

    //총알 충돌시
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            soundManager.Dead();
            Despawn();
        }
    }

    //영역 체크
    private void CheckLimit()
    {

        if (transform.position.y < gameManager.MinPosition.y - 2f)
        {
            Despawn();
        }

    }

    //비활성화
    private void Despawn()
    {
        gameObject.SetActive(false);
        transform.SetParent(gameManager.poolIngManager.transform, false);
    }

}
