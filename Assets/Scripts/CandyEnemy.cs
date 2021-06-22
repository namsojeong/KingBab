using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyEnemy : EnemyMove
{
    [SerializeField]
    float speed = 5f;
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        CheckLimit();
    }
    private void CheckLimit()
    {
        if (transform.position.x < gameManager.MinPosition.x - 2f)
        {
            Despawn();
        }
    }
}
