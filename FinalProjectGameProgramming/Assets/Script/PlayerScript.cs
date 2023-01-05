using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable] 
public enum TypePlayer{
    DRAGON, 
    GREENDRAGON 
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
        yield return new WaitForSeconds(0);

        SceneManager.LoadScene("GameOverScene");
    }

    IEnumerator FinishGame() {
        yield return new WaitForSeconds(0);

        SceneManager.LoadScene("GameCompleteScene");
    }

    private void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        isRight = !isRight;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Ground")) {
            canJump = true;
        }

        if (other.gameObject.tag.Equals("Water")) {
            if (typePlayer == TypePlayer.DRAGON) {
                StartCoroutine(FailGame());
            }

            if (typePlayer == TypePlayer.GREENDRAGON) {
                canJump = true;
            }
        }

        if (other.gameObject.tag.Equals("Lava")) {
            if (typePlayer == TypePlayer.GREENDRAGON) {
                StartCoroutine(FailGame());
            }

            if (typePlayer == TypePlayer.DRAGON) {
                canJump = true;
            }
        }

        if (other.gameObject.tag.Equals("enemy")) {
            if (typePlayer == TypePlayer.GREENDRAGON) {
                Debug.Log("Chet vi cham quai!");
                StartCoroutine(FailGame());
            }
        }

        if (other.gameObject.tag.Equals("enemy")) {
            if (typePlayer == TypePlayer.DRAGON) {
                StartCoroutine(FailGame());
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

        if (other.gameObject.tag.Equals("Final")) {
            StartCoroutine(FinishGame());
        }

        if (other.gameObject.tag.Equals("AttackZone1") ) {
            StartCoroutine(FailGame());
        }

        if (other.gameObject.tag.Equals("AttackZone2") ) {
            StartCoroutine(FailGame());
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
        animator.SetBool("Shoot", false);
        if (horizontalVal != 0) {
            rb.velocity = new Vector2(horizontalVal * speed, rb.velocity.y);
            animator.SetBool("Speed", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            animator.SetBool("Jump", true);
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);

        }

        if (Input.GetKeyDown(KeyCode.F)) {
            animator.SetBool("Shoot", true);
            GameManager.Instance.playSoundShoot();
        }
    }

    private void OnDestroy(){}    

    private void FixedUpdate() {
        
    }
}
