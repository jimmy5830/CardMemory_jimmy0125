using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameControl1 : MonoBehaviour
{
    public ScoreControl scoreControl;

    GameObject token;
    List<int> faceIndexes = new List<int> { 0, 1, 0, 1};
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = { -1, -2 };

    public float gameTime = 60.0f; // 초기 시간 설정
    bool gameFailed = false;

    public int totalMatches = 2;
    private int currentMatches = 0;
    public Text resetCountText; // 카운트 점수 표시 Text

    private int resetCount = 0; // 카운트 세기

    
    
    // 이미지들을 담을 배열



    void Start()
    {       

        // faceIndexes 리스트의 초기 길이를 저장
        int originalLength = faceIndexes.Count;

        // 토큰의 초기 y 위치
        float yPosition = 2.3f;

        // 토큰의 초기 x 위치
        float xPosition = -2.2f;

        // 3번 반복하여 토큰을 생성하고 배치
        for (int i = 0; i < 3; i++)
        {
            // faceIndexes 리스트에서 랜덤한 인덱스를 얻기 위한 난수 생성
            shuffleNum = rnd.Next(0, (faceIndexes.Count));

            // 새로운 토큰을 생성하고 위치를 설정
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);

            // MainFront1 스크립트의 faceIndex 속성을 설정
            temp.GetComponent<MainFront1>().faceIndex = faceIndexes[shuffleNum];

            // 이미 사용된 faceIndex를 제거하여 중복 사용을 방지
            faceIndexes.Remove(faceIndexes[shuffleNum]);

            // xPosition 값을 증가하여 토큰을 가로로 이동
            xPosition = xPosition + 4;

            // originalLength의 절반까지 반복하면 y 위치를 변경하여 세로로 이동
            if (i == (originalLength / 2 - 2))
            {
                yPosition = -2.3f;
                xPosition = -6.2f;
            }
        }

        // 마지막 토큰에 남은 faceIndex를 할당
        token.GetComponent<MainFront1>().faceIndex = faceIndexes[0];

        
    }
        
    public bool TwoCardsUp()
    {
        // 현재 두 장의 카드가 앞면을 향하고 있는지 확인
        bool cardsUp = false;
        if (visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            cardsUp = true;
        }
        return cardsUp;
    }

    public void AddVisibleFace(int index)
    {
        // 현재 보이는 앞면 목록에 카드의 인덱스를 추가
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
        // 현재 보이는 앞면 목록에서 카드의 인덱스를 제거
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
            scoreControl.IncrementResetCount(); // scroeControl 코드에 점수를 추가
        }
    }

    public bool CheckMatch() // 조합이 일치하는 체크하는 메소드
    {
        bool success = false;
        if (visibleFaces[0] == visibleFaces[1])
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
            currentMatches++;

            // 모든 조합이 일치하였는지 확인
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

    private void Awake()
    {
        token = GameObject.Find("Token");
    }

}