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
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        MovePlayer();

        if (Input.GetMouseButtonDown(0) && !isJumping)
        {
            rb.velocity = Vector2.up * jumpPower;
        }
    }

    void MovePlayer()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
            transform.Find("Walking Sound").GetComponent<AudioSource>().Play();
        }

        if (collision.transform.tag == "Hurdle")
        {
            Debug.Log("Duck has died :(");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isJumping = true;
            anim.SetBool("isJumping", true);

            GetComponent<AudioSource>().Play();
            transform.Find("Walking Sound").GetComponent<AudioSource>().Pause();
        }
    }
}
