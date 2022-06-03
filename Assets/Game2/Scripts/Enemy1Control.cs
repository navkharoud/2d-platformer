using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Control : EnemyController
{
    void FixedUpdate()
    {
        if (GameObject.Find("Player").GetComponent<PlayerController>().reachedCheckpoint == true) {
            if (_isFacingRight == true)
            {
                _rb.velocity =
                new Vector2(_maxSpeed, _rb.velocity.y);
            }
            else
            {
                _rb.velocity =
                new Vector2(_maxSpeed * -1, _rb.velocity.y);
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            Flip();
        }
    }

}
