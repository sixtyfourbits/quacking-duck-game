using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController sc = new SceneController();

    public bool isGameStarted;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void GameStart()
    {
        isGameStarted = true;
    }
}
