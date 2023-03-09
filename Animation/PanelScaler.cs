using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PanelScaler : MonoBehaviour
{
    [Range(0f, 10f)]
    public float ScaleX = 0f;
    [Range(0f, 10f)]
    public float ScaleY = 0f;
    public float scaleFactor = 5f;

    private Transform centre;
    private Transform leftSide;
    private Transform leftTop;
    private Transform leftMiddle;
    private Transform leftBottom;
    private Transform rightSide;
    private Transform rightTop;
    private Transform rightMiddle;
    private Transform rightBottom;

    void Start()
    {
        centre = transform.GetChild(0);
        leftSide = transform.GetChild(1);
        rightSide = transform.GetChild(2);
        leftBottom = leftSide.GetChild(0);
        leftMiddle = leftSide.GetChild(1);
        leftTop = leftSide.GetChild(2);
        rightBottom = rightSide.GetChild(0);
        rightMiddle = rightSide.GetChild(1);
        rightTop = rightSide.GetChild(2);

    }

    void Update()
    {
        Scale();
    }

    public void Scale()
    {
        centre.localScale = new Vector3(ScaleX * scaleFactor, (ScaleY * scaleFactor * 0.5f) + 0.5f, 1f);
        leftSide.localPosition = new Vector3(ScaleX * scaleFactor * 0.01f, 0f, 0f);
        rightSide.localPosition = new Vector3(-ScaleX * scaleFactor * 0.01f, 0f, 0f);

        leftTop.localPosition = new Vector3(0f, ScaleY * scaleFactor * 0.01f, 0f);
        leftBottom.localPosition = new Vector3(0f, -ScaleY * scaleFactor * 0.01f, 0f);
        rightTop.localPosition = new Vector3(0f, ScaleY * scaleFactor * 0.01f, 0f);
        rightBottom.localPosition = new Vector3(0f, -ScaleY * scaleFactor * 0.01f, 0f);

        leftMiddle.localScale = new Vector3(1f, ScaleY * scaleFactor, 1f);
        rightMiddle.localScale = new Vector3(1f, ScaleY * scaleFactor, 1f);
    }
}
