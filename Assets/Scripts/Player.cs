using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player playerScript;


    Rigidbody2D rb;
    public Animator anim;

    public GameObject scoreText;

    [SerializeField] int speed;
    [SerializeField] int jumpPower;

    public bool isGameStarted;
    [SerializeField] bool isJumping;

    AudioSource walkingSound;

    void Start()
    {
        playerScript = this;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        isGameStarted = false;

        walkingSound = transform.Find("Walking Sound").GetComponent<AudioSource>();
    }

    void Update()
    {
        MovePlayer();

        if (Input.GetMouseButtonDown(0) && !isJumping && isGameStarted)
            rb.velocity = Vector2.up * jumpPower;

        if (isGameStarted && !walkingSound.isPlaying)
            walkingSound.Play();
        else if (!isGameStarted && walkingSound.isPlaying)
            walkingSound.Stop();
    }

    void MovePlayer()
    {
        if (isGameStarted)
            transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
            walkingSound.UnPause();
        }

        if (collision.transform.tag == "Hurdle")
        {
            isGameStarted = false;
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isJumping = true;
            anim.SetBool("isJumping", true);
            walkingSound.Pause();
            GetComponent<AudioSource>().Play();
        }
    }
}
