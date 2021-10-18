using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject uiCanvas;

    [SerializeField] int speed;
    [SerializeField] int jumpPower;

    bool isJumping;
    bool isGameStarted;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        isGameStarted = false;
    }

    
    void Update()
    {
        MovePlayer();

        if (Input.GetMouseButtonDown(0) && !isJumping && isGameStarted)
        {
            rb.velocity = Vector2.up * jumpPower;
        }
    }

    void MovePlayer()
    {
        if (isGameStarted)
            transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameStarted)
            return;

        if (collision.transform.tag == "Ground")
        {
            isJumping = false;
            anim.SetBool("isJumping", false);
            transform.Find("Walking Sound").GetComponent<AudioSource>().Play();
        }

        if (collision.transform.tag == "Hurdle")
        {
            transform.Find("Die Sound").GetComponent<AudioSource>().Play();
            isGameStarted = false;
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isGameStarted)
            return;

        if (collision.transform.tag == "Ground")
        {
            isJumping = true;
            anim.SetBool("isJumping", true);

            GetComponent<AudioSource>().Play();
            transform.Find("Walking Sound").GetComponent<AudioSource>().Pause();
        }
    }

    public void GameStartButtonTrigger()
    {
        Debug.Log("hello");
        isGameStarted = true;
        scoreText.SetActive(true);
        uiCanvas.transform.GetChild(1).gameObject.SetActive(false);
        uiCanvas.transform.GetChild(2).gameObject.SetActive(false);
        uiCanvas.transform.GetChild(3).gameObject.SetActive(false);

        StartCoroutine("UIBackgroundAlpha");
    }

    IEnumerator UIBackgroundAlpha()
    {
        while(true)
        {
            if (uiCanvas.transform.GetChild(0).GetComponent<Image>().color.a <= 0)
                break;

            uiCanvas.transform.GetChild(0).GetComponent<Image>().color = 
                new Color(0, 0, 0, uiCanvas.transform.GetChild(0).GetComponent<Image>().color.a - 1);

            yield return new WaitForSeconds(0.01f);
        }
    }
}
