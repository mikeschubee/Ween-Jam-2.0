using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text scoreText;
    public float score;
    public float pointIncrease;
    public bool isScoring;

    private void Start()
    {
        isScoring = true;
    }

    private void Update()
    {
        if (isScoring == true)
        {
            score += pointIncrease * Time.deltaTime;
        }

        if (isScoring == false)
        {
            scoreText.text = "Time Survived:" + (int)score;
        }
    }
}
