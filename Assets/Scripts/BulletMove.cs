using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [Header("이동 속도")]
    [SerializeField]
    private float speed = 10f;
    private GameManager gameManager = null;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.up*speed * Time.deltaTime);
        CheckLimit();
    }
    private void CheckLimit()
    {
        if (transform.position.y > gameManager.MaxPosition.y + 2f)
        {
            Despawn();
        }
        if (transform.position.y < gameManager.MinPosition.y - 2f)
        {
            Despawn();
        }
        if (transform.position.x > gameManager.MaxPosition.y + 2f)
        {
            Despawn();
        }
        if (transform.position.x < gameManager.MinPosition.y - 2f)
        {
            Despawn();
        }
    }
    private void Despawn()
    {
        gameObject.SetActive(false);
        transform.SetParent(gameManager.poolManager.transform, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Danmuzi"))
        {
            gameManager.Danmuzi += 1;
        }
        if (collision.CompareTag("Egg"))
        {
            gameManager.Egg += 1;
        }
        if (collision.CompareTag("Ham"))
        {
            gameManager.Ham += 1;
        }
        if (collision.CompareTag("Sigumchi"))
        {
            gameManager.Sigumchi += 1;
        }
        gameManager.AddScore();
    }
}
