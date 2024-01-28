using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFront1 : MonoBehaviour
{
    public GameObject gameControl;
    SpriteRenderer spriteRenderer; // 카드의 이미지 변경
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex; // 어떤 이미지를 사용할지 결정
    public bool matched = false;

    public GameControl1 control;


    public void OnMouseDown() // 마우스 클릭 메소드
    {
        if (matched == false)
        {
            if (spriteRenderer.sprite == back)
            {
                if (control.TwoCardsUp() == false)
                {
                    spriteRenderer.sprite = faces[faceIndex];
                    control.AddVisibleFace(faceIndex);
                    matched = control.CheckMatch();
                }
            }
            else
            {
                spriteRenderer.sprite = back;
                control.RemoveVisibleFace(faceIndex);
            }
        }
    }

    private void Awake()
    {
        control = gameControl.GetComponent<GameControl1>();

        if (control == null)
        {
            Debug.LogError(">?????");
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 이미지를 랜덤으로 선택하고 표시하는 메서드
}
