using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [SerializeField] int speed;
    [SerializeField] int jumpPower;

    bool isJumping;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        MovePlayer();

        if (!isJumping && Input.GetMouseButtonDown(0))
        {
            isJumping = true;
            anim.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void MovePlayer()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground" && isJumping)
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }
    }
}
