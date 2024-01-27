using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreControl : MonoBehaviour
{
    private int resetCount = 0; // Counter for the number of times visibleFaces are reset

    public TMP_Text resetCountText;  // Reference to the Text component for displaying resetCount

    public int ResetCount
    {
        get { return resetCount; }
    }

    void Start()
    {
        // Ensure the Text component is assigned in the Unity Editor
        if (resetCountText == null)
        {
            Debug.LogError("Text component not assigned to ScoreControl. Please assign it in the Unity Editor.");
        }
    }

    public void IncrementResetCount()
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

    public void DisplayScoreOnTimeEnd()
    {
        Debug.Log("Score: " + resetCount);
    }
}
