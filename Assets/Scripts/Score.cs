using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;

    int scorePoint;
    float countScore;

    void Start()
    {

    }

    void Update()
    {
        countScore += 0.01f;

        if (countScore >= 1.0f)
        {
            scorePoint += 1;
            countScore = 0.0f;

            scoreText.text = scorePoint.ToString();
        }
    }
}
