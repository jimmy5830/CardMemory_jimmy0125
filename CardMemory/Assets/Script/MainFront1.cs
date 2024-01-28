using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFront1 : MonoBehaviour
{
    public GameObject gameControl;
    SpriteRenderer spriteRenderer; // ī���� �̹��� ����
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex; // � �̹����� ������� ����
    public bool matched = false;

    public GameControl1 control;


    public void OnMouseDown() // ���콺 Ŭ�� �޼ҵ�
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

    // �̹����� �������� �����ϰ� ǥ���ϴ� �޼���
}
