using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeControl : MonoBehaviour
{
    public float timeRemaining = 60f; // 초기 시간 60초로 선언
    public bool timeIsRunning = true;
    public TMP_Text timeText;
    public TMP_Text gameOverText;
    public TMP_Text finalScoreText;
    public ScoreControl scoreControl;
    

    // 첫 프레임이 업데이트 되기 전에
    // Start 선언

    void Start()
    {
        timeIsRunning = true;
        gameOverText.gameObject.SetActive(false); // 초기 gameOverText가 출력되지 않도록 설정
        finalScoreText.gameObject.SetActive(false); // 초기 finalScoreText가 출력되지 않도록 설정
    }

    // 프레임당 업데이트 불러옴
    void Update()
    {
        if (timeIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                timeRemaining = 0;
                timeIsRunning = false;
                DisplayTime(timeRemaining);
                ShowGameOverText();
                ShowFinalScore();
                Application.Quit();
                
                // You can add any actions you want to perform when the timer reaches 0 here

                
            }

        }
    }

    void DisplayTime(float timeToDisplay)
    {

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    void ShowGameOverText()
    {
        gameOverText.gameObject.SetActive(true); // 게임 오버 텍스트를 출력
        
        Debug.Log("Game Ended");
        

    }

    void ShowFinalScore()
    {
        finalScoreText.gameObject.SetActive(true); // 최종 스코어를 출력
        Debug.Log("Score:  ");
    }
}
