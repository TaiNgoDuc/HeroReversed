using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable] 
public enum TypePlayer{
    DRAGON, 
    WIZARD 
}

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    float speed = 10f;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    private bool isRight = true;
    float force = 15f ;
    Animator animator;
    bool canJump;

    public TypePlayer typePlayer;


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        
    }

    IEnumerator LoadLevel2() {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level2");
    }

    IEnumerator LoadLevel3() {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Level3");
    }

    IEnumerator FailGame() {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("GameOverScene");
    }

    


    private void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        isRight = !isRight;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision with " + other.gameObject.name);
        if (other.gameObject.tag.Equals("Ground")) {
            canJump = true;
        }

        if (other.gameObject.tag.Equals("Water")) {
            if (typePlayer == TypePlayer.DRAGON) {
                Destroy(gameObject, 2f);
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Ground")) {
            canJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag.Equals("Entrance")) {
            StartCoroutine(LoadLevel2());
        }

        if (other.gameObject.tag.Equals("Entrance2")) {
            StartCoroutine(LoadLevel3());
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xVal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        if ( xVal > 0 && !isRight) {
            Flip();
        }
        if ( xVal < 0 && isRight) {
            Flip();
        }

        var horizontalVal = Input.GetAxis("Horizontal");
        animator.SetBool("Jump", false);
        animator.SetBool("Speed", false);
        if (horizontalVal != 0) {
            rb.velocity = new Vector2(horizontalVal * speed, rb.velocity.y);
            animator.SetBool("Speed", true);
            Debug.Log("player can run");
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            animator.SetBool("Jump", true);
            Debug.Log("Player can jump");
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);

        }
    }

    private void OnDestroy(){}    

    private void FixedUpdate() {
        
    }
}
