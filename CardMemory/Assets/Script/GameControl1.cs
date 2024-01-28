using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl1 : MonoBehaviour
{
    public ScoreControl scoreControl;

    GameObject token;
    List<int> faceIndexes = new List<int> { 0, 1, 0, 1 };
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = { -1, -2 };

    public float gameTime = 60.0f; // �ʱ� �ð� ����
    bool gameFailed = false;

    public int totalMatches = 2;
    private int currentMatches = 0;
    public Text resetCountText; // ī��Ʈ ���� ǥ�� Text
    public Text finalCountText; // ���� ���� ǥ�� TExt

    private int resetCount = 0; // ī��Ʈ ����



    // �̹������� ���� �迭



    void Start()
    {

        // faceIndexes ����Ʈ�� �ʱ� ���̸� ����
        int originalLength = faceIndexes.Count;

        // ��ū�� �ʱ� y ��ġ
        float yPosition = 2.3f;

        // ��ū�� �ʱ� x ��ġ
        float xPosition = -2.2f;

        // 3�� �ݺ��Ͽ� ��ū�� �����ϰ� ��ġ
        for (int i = 0; i < 3; i++)
        {
            // faceIndexes ����Ʈ���� ������ �ε����� ��� ���� ���� ����
            shuffleNum = rnd.Next(0, (faceIndexes.Count));

            // ���ο� ��ū�� �����ϰ� ��ġ�� ����
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);

            // MainFront1 ��ũ��Ʈ�� faceIndex �Ӽ��� ����
            temp.GetComponent<MainFront1>().faceIndex = faceIndexes[shuffleNum];

            // �̹� ���� faceIndex�� �����Ͽ� �ߺ� ����� ����
            faceIndexes.Remove(faceIndexes[shuffleNum]);

            // xPosition ���� �����Ͽ� ��ū�� ���η� �̵�
            xPosition = xPosition + 4;

            // originalLength�� ���ݱ��� �ݺ��ϸ� y ��ġ�� �����Ͽ� ���η� �̵�
            if (i == (originalLength / 2 - 2))
            {
                yPosition = -2.3f;
                xPosition = -6.2f;
            }
        }

        

        // ������ ��ū�� ���� faceIndex�� �Ҵ�
        token.GetComponent<MainFront1>().faceIndex = faceIndexes[0];


    }

    public bool TwoCardsUp()
    {
        // ���� �� ���� ī�尡 �ո��� ���ϰ� �ִ��� Ȯ��
        bool cardsUp = false;
        if (visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            cardsUp = true;
        }
        return cardsUp;
    }

    public void AddVisibleFace(int index)
    {
        // ���� ���̴� �ո� ��Ͽ� ī���� �ε����� �߰�
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
        // ���� ���̴� �ո� ��Ͽ��� ī���� �ε����� ����
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

    public bool CheckMatch() // ������ ��ġ�ϴ� üũ�ϴ� �޼ҵ�
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
                MoveToNextStage();
            }
        }
        return success;
    }

    private void MoveToNextStage()
    {
        SceneManager.LoadScene("Stage2");
    }

    /*public void GameEnded()
    {
        Debug.Log("Game Ended");
    }*/

    private void Awake()
    {
        token = GameObject.Find("Token");
    }

    
}
