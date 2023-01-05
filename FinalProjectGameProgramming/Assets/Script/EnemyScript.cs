using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    float enemywalk = 3f;
    private Vector2 walkofenemy = Vector2.right;
    Rigidbody2D rb;
    private bool isRight = true;
    bool canRun;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        isRight = !isRight;
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("walltoflip") && walkofenemy==Vector2.right) {
            walkofenemy = Vector2.left;
            Flip();
        } 
        else if (other.gameObject.tag.Equals("walltoflip") && walkofenemy==Vector2.left) {
            walkofenemy = Vector2.right;
            Flip();
        } 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("fireball") ) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(enemywalk * walkofenemy.x, rb.velocity.y );
    }
}
