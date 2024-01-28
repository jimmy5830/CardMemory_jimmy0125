using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeControl : MonoBehaviour
{
    public float timeRemaining = 60f; // �ʱ� �ð� 60�ʷ� ����
    public bool timeIsRunning = true;
    public TMP_Text timeText;
    public TMP_Text gameOverText;
    public TMP_Text finalScoreText;
    public ScoreControl scoreControl;
    

    // ù �������� ������Ʈ �Ǳ� ����
    // Start ����

    void Start()
    {
        timeIsRunning = true;
        gameOverText.gameObject.SetActive(false); // �ʱ� gameOverText�� ��µ��� �ʵ��� ����
        finalScoreText.gameObject.SetActive(false); // �ʱ� finalScoreText�� ��µ��� �ʵ��� ����
    }

    // �����Ӵ� ������Ʈ �ҷ���
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
        gameOverText.gameObject.SetActive(true); // ���� ���� �ؽ�Ʈ�� ���
        
        Debug.Log("Game Ended");
        

    }

    void ShowFinalScore()
    {
        finalScoreText.gameObject.SetActive(true); // ���� ���ھ ���
        Debug.Log("Score:  ");
    }
}
