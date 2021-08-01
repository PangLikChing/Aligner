using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdJumppad : MonoBehaviour
{
    [SerializeField] Bird bird;
    [SerializeField] Canvas canvas;

    void Awake()
    {
        //Initialize

        //Make sure that the Jumppad is the same size as the canvas
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(canvas.GetComponent<RectTransform>().sizeDelta.x, canvas.GetComponent<RectTransform>().sizeDelta.y);

    }

    public void Clicked()
    {
        bird.Jump();
    }
}
