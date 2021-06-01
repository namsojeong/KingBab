using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [Header("�̵� �ӵ�")]
    [SerializeField]
    private float speed = 10f;
    private GameManager gameManager = null;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.up*speed * Time.deltaTime);
        if(transform.position.y>gameManager.MaxPosition.y)
        {
            Destroy(gameObject);
        }
    }
}
