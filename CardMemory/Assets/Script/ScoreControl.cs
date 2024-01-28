using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreControl : MonoBehaviour
{
    private int resetCount = 0; // Counter for the number of times visibleFaces are reset
    private int finalCount = 0; // 실패 점수 초기값 설정
    private int clearCount = 0; // 성공 점수 초기값 설정
    public TMP_Text resetCountText;  // Reference to the Text component for displaying resetCount
    public TMP_Text finalCountText; // 최종 점수
    public TMP_Text clearCountText; // 최종 점수

    public int ResetCount
    {
        get { return resetCount; }
    }

    public int FinalCount
    {
        get { return finalCount; }
    }

    public int ClearCount
    {
        get { return clearCount; }
    }

    void Start()
    {
        // 텍스트 컴포넌트가 유니티에 할당되도록 설정
        if (resetCountText == null)
        {
            Debug.LogError("resetCountText component not assigned to ScoreControl. Please assign it in the Unity Editor.");
        }

        else if (finalCountText == null)
        {
            Debug.LogError("finalCountText component not assigned to ScoreControl. Please assign it in the Unity Editor.");
        }

        else if (clearCountText == null)
        {
            Debug.LogError("clearCountText component not assigned to ScoreControl. Please assign it in the Unity Editor.");
        }
    }

    public void IncrementResetCount() // 화면 점수 증가 메소드
    {
        resetCount++;

        // Update the Text component with the current resetCount value
        if (resetCountText != null)
        {
            resetCountText.text = "Score: " + resetCount.ToString();
        }

        // You can display or use the resetCount value as needed
        Debug.Log("Reset Count: " + resetCount);
    }

    public void IncrementFinalCount() // 최종 점수 증가 메소드
    {
        finalCount++;

        // Update the Text component with the current resetCount value
        if (finalCountText != null)
        {
            finalCountText.text = "Score: " + finalCount.ToString();
        }

        // You can display or use the resetCount value as needed
        Debug.Log("Final Count: " + finalCount);
    }

    public void IncrementClearCount() // 최종 점수 증가 메소드
    {
        clearCount++;

        // Update the Text component with the current resetCount value
        if (clearCountText != null)
        {
            clearCountText.text = "Score: " + clearCount.ToString();
        }

        // You can display or use the resetCount value as needed
        Debug.Log("Score: " + clearCount);
    }


    public void DisplayScoreOnTimeEnd()
    {
        Debug.Log("Score: " + resetCount);
    }
}
