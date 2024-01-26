using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFront2 : MonoBehaviour
{
    public GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] faces;
    public Sprite back;
    public int faceIndex;
    public bool matched = false;

    public GameControl2 control;

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
        //gameControl = GameObject.Find("GameControl2");
        control = gameControl.GetComponent<GameControl2>();

        if (control == null)
        {
            Debug.LogError(">?????");
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
