using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartButton()
    {
        Player.playerScript.anim.SetBool("isGameStarted", true);
        Player.playerScript.isGameStarted = true;
        startButton.SetActive(false);
        Player.playerScript.scoreText.SetActive(true);
    }
}
