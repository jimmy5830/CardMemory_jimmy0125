using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFront1 : MonoBehaviour
{
    public GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;

    public GameControl1 control;

    public void OnMouseDown()
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
        //gameControl = GameObject.Find("GameControl1");
        control = gameControl.GetComponent<GameControl1>();

        if (control == null)
        {
            Debug.LogError(">?????");
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
