using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    Vector2 moveSpeed = new Vector2(5f, 0);

    void Start()
    {
        rb.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("enemy")) {
            Destroy(gameObject);
            Debug.Log("He he ban trung roi");
        }

        if (other.gameObject.tag.Equals("walltoflip")) {
            Destroy(gameObject);
        }

        if (other.gameObject.tag.Equals("Ground")) {
            Destroy(gameObject);
        }

        if (other.gameObject.tag.Equals("Boss")) {
            Destroy(gameObject);
        }
    }

    void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
