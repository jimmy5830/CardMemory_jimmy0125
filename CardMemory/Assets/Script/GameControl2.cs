using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl2 : MonoBehaviour
{
    GameObject token;
    List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 0, 1, 2, 3 };
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = { -1, -2 };

    void Start()
    {
        // faceIndexes 리스트의 초기 길이를 저장
        int originalLength = faceIndexes.Count;

        // 토큰의 초기 y 위치
        float yPosition = 2.3f;

        // 토큰의 초기 x 위치
        float xPosition = -2.2f;

        // 3번 반복하여 토큰을 생성하고 배치
        for (int i = 0; i < 7; i++)
        {
            // faceIndexes 리스트에서 랜덤한 인덱스를 얻기 위한 난수 생성
            shuffleNum = rnd.Next(0, (faceIndexes.Count));

            // 새로운 토큰을 생성하고 위치를 설정
            var temp = Instantiate(token, new Vector3(xPosition, yPosition, 0), Quaternion.identity);

            // MainFront2 스크립트의 faceIndex 속성을 설정
            temp.GetComponent<MainFront2>().faceIndex = faceIndexes[shuffleNum];

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
        token.GetComponent<MainFront2>().faceIndex = faceIndexes[0];
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
    }

    public bool CheckMatch()
    {
        bool success = false;
        if (visibleFaces[0] == visibleFaces[1])
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
            // move to next stage

            /*if (Scene.name == "Stage1")
            {
                SceneManager.LoadScene("Stage2");
            }*/
        }
        return success;
    }

    private void Awake()
    {
        token = GameObject.Find("Token2");
    }
}
