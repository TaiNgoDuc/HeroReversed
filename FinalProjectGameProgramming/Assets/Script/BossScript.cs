using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update

    float enemywalk = 3f;
    private Vector2 walkofenemy = Vector2.right;
    Rigidbody2D rb;
    private bool isRight = true;
    int count = 0;
    bool oneTime = false;
    Animator animator;
    public BossDetectedZoneScript bossDetectZone;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
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
            count++;
            if(count == 10) {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(enemywalk * walkofenemy.x, rb.velocity.y );

        if (bossDetectZone.detected == true) {
            
            if (!oneTime) {
                Debug.Log(bossDetectZone.getDetectZone);
                oneTime = true;
                animator.SetBool("Run", false);

                enemywalk = 0;

                if (bossDetectZone.getDetectZone == 0) {
                    animator.SetBool("Attack1", true);
                }

                if (bossDetectZone.getDetectZone == 1) {
                    animator.SetBool("Attack2", true);
                }
            }   
        } else {
            oneTime = false; 
            animator.SetBool("Run", true);
            animator.SetBool("Attack1", false);
            animator.SetBool("Attack2", false);

            enemywalk = 3f;
        }

        
            
    }

    void FixedUpdate() {
        
    }
}
