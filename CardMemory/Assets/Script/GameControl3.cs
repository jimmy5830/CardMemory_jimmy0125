using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameControl3 : MonoBehaviour
{
    public ScoreControl scoreControl;

    GameObject token;
    List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 4, 5, 0, 1, 2, 3, 4, 5, 6, 6, 7, 7, 8, 8 };
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = { -1, -2 };

    public float gameTime = 60.0f; // �ʱ� �ð� ����
    bool gameFailed = false;
    public int totalMatches = 9;
    private int currentMatches = 0;
    public Text resetCountText;
    public TMP_Text ClearText;
    private int resetCount = 0;

    void Start()
    {
        // faceIndexes ����Ʈ�� �ʱ� ���̸� ����
        int originalLength = faceIndexes.Count;

        // ��ū�� �ʱ� y ��ġ
        float yPosition = 2.3f;

        // ��ū�� �ʱ� x ��ġ
        float xPosition = -6.2f;

        // 3�� �ݺ��Ͽ� ��ū�� �����ϰ� ��ġ
        for (int i = 0; i < 18; i++)
        {
            // faceIndexes ����Ʈ���� ������ �ε����� ��� ���� ���� ����
            shuffleNum = rnd.Next(0, (faceIndexes.Count));

            // ���ο� ��ū�� �����ϰ� ��ġ�� ����
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);

            // MainFront3 ��ũ��Ʈ�� faceIndex �Ӽ��� ����
            temp.GetComponent<MainFront3>().faceIndex = faceIndexes[shuffleNum];

            // �̹� ���� faceIndex�� �����Ͽ� �ߺ� ����� ����
            faceIndexes.Remove(faceIndexes[shuffleNum]);

            // xPosition ���� �����Ͽ� ��ū�� ���η� �̵�
            xPosition = xPosition + 2.5f;

            // originalLength�� ���ݱ��� �ݺ��ϸ� y ��ġ�� �����Ͽ� ���η� �̵�
            if (i == 5)
            {
                yPosition = 0f;
                xPosition = -6.2f;
            }

            else if (i == 11)
            {
                yPosition = -2.3f;
                xPosition = -6.2f;
            }

            
        }

        if (faceIndexes.Count < 2 * 9)
        {
            Debug.LogError("Not enough unique values in faceIndexes. Add more values. ");
            Debug.LogError("Initial Count of faceIndexes: " + faceIndexes.Count);
            return;
        }

        else if (faceIndexes.Count > 2 * 9)
        {
            Debug.LogError("Too much unique values in faceIndexes. Add more values. ");
            Debug.LogError("Initial Count of faceIndexes: " + faceIndexes.Count);
            return;
        }

        token.GetComponent<MainFront3>().faceIndex = faceIndexes[0];


        ClearText.gameObject.SetActive(false); // �ʱ� gameOverText�� ��µ��� �ʵ��� ����

    }


    public bool TwoCardsUp()
    {
        bool cardsUp = false;
        if (visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            cardsUp = true;
        }
        return cardsUp;
    }

    public void AddVisibleFace(int index)
    {
        if (visibleFaces[0] == -1)
        {
            visibleFaces[0] = index;
        }
        else if (visibleFaces[1] == -2)
        {
            visibleFaces[1] = index;
        }
    }

    public void RemoveVisibleFace(int index)
    {
        if (visibleFaces[0] == index)
        {
            visibleFaces[0] = -1;
        }
        else if (visibleFaces[1] == index)
        {
            visibleFaces[1] = -2;
        }

        if (scoreControl != null)
        {
            scoreControl.IncrementResetCount(); // scoreControl �ڵ忡 ������ �߰�
            scoreControl.IncrementFinalCount(); // final ������ �߰�
        }
    }

    public bool CheckMatch()
    {
        bool success = false;
        if (visibleFaces[0] == visibleFaces[1])
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
            currentMatches++;

            // ��� ������ ��ġ�Ͽ����� Ȯ��
            if (currentMatches == totalMatches)
            {
                ShowClearText();
            }

        }
        return success;
    }

    private void ShowClearText() // ���� �Ϸ�� Ŭ���� ���� ���
    {
        ClearText.gameObject.SetActive(true); // ���� ���� �ؽ�Ʈ�� ���

        Debug.Log("Game Ended");
    }


    private void Awake()
    {
        token = GameObject.Find("Token3");
    }
}
