using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreControl : MonoBehaviour
{
    private int resetCount = 0; // Counter for the number of times visibleFaces are reset
    private int finalCount = 0; // ���� ���� �ʱⰪ ����
    private int clearCount = 0; // ���� ���� �ʱⰪ ����
    public TMP_Text resetCountText;  // Reference to the Text component for displaying resetCount
    public TMP_Text finalCountText; // ���� ����
    public TMP_Text clearCountText; // ���� ����

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
        // �ؽ�Ʈ ������Ʈ�� ����Ƽ�� �Ҵ�ǵ��� ����
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

    public void IncrementResetCount() // ȭ�� ���� ���� �޼ҵ�
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

    public void IncrementFinalCount() // ���� ���� ���� �޼ҵ�
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

    public void IncrementClearCount() // ���� ���� ���� �޼ҵ�
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
