using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorAnimator : Animator
{
    [SerializeField] private Color openTarget, closeTarget;
    [SerializeField] private bool startOpen;
    private Color startValue, targetValue;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        if (!startOpen) image.color = closeTarget;
    }

    private void Update()
    {
        if (IsAnimating) image.color = Color.Lerp(startValue, targetValue, AnimationTime());
    }
    
    public void Open()
    {
        startValue = image.color;
        targetValue = openTarget;
        SetOpenAnimation();
    }

    public void Close()
    {
        startValue = image.color;
        targetValue = closeTarget;
        SetCloseAnimation();
    }
}
