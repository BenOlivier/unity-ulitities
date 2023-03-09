using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RectTransformAnimator : TransformAnimator
{
    private RectTransform rectTransform;

    public override void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        switch (transformToAnimate)
        {
            case transformComponent.position:
                if (!startOpen) rectTransform.anchoredPosition = closedTarget;
                break;
            case transformComponent.rotation:
                if (!startOpen) rectTransform.localRotation = Quaternion.Euler(closedTarget);
                break;
            case transformComponent.scale:
                if (!startOpen) rectTransform.localScale = closedTarget;
                break;
        }
    }

    public override void Update()
    {
        if (IsAnimating)
        {
            switch (transformToAnimate)
            {
                case transformComponent.position:
                    rectTransform.anchoredPosition = animationValue();
                    break;
                case transformComponent.rotation:
                    rectTransform.localRotation = Quaternion.Euler(animationValue());
                    break;
                case transformComponent.scale:
                    rectTransform.localScale = animationValue();
                    break;
            }
        }
    }

    public override void Open()
    {
        switch (transformToAnimate)
        {
            case transformComponent.position:
                startValue = rectTransform.anchoredPosition;
                break;
            case transformComponent.rotation:
                startValue = rectTransform.localRotation.eulerAngles;
                break;
            case transformComponent.scale:
                startValue = rectTransform.localScale;
                break;
        }
        targetValue = openTarget;
        SetOpenAnimation();
    }

    public override void Close()
    {
        switch (transformToAnimate)
        {
            case transformComponent.position:
                startValue = rectTransform.anchoredPosition;
                break;
            case transformComponent.rotation:
                startValue = rectTransform.localRotation.eulerAngles;
                break;
            case transformComponent.scale:
                startValue = rectTransform.localScale;
                break;
        }
        targetValue = closedTarget;
        SetCloseAnimation();
    }
}
