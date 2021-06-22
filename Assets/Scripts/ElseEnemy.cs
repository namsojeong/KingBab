using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElseEnemy : EnemyMove
{
    [SerializeField]
    float speed = 3f;
    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        CheckLimit();
    }
    private void CheckLimit()
    {
        if (transform.position.y < gameManager.MinPosition.y - 2f)
        {
            Despawn();
        }
    }
}
