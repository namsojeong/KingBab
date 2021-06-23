using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeEnemy : EnemyMove
{
    [SerializeField]
    float speed = 3f;
    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        CheckLimit();
    }
    private void CheckLimit()
    {
        if (transform.position.x > gameManager.MaxPosition.x + 2f || transform.position.x < gameManager.MinPosition.x - 2f || transform.position.y > gameManager.MaxPosition.y + 2f || transform.position.y < gameManager.MinPosition.y - 2f)
        {
            Despawn();
        }
    }
}
