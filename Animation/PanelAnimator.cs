using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelAnimator : Animator
{
    [SerializeField] private float openTarget, closeTarget;
    [SerializeField] private bool startOpen;
    private float startValue, targetValue;
    private PanelScaler panelScaler;
    public bool isOpen = true;

    private void Start()
    {
        panelScaler = GetComponent<PanelScaler>();

        if (startOpen) return;
        panelScaler.ScaleX = closeTarget;
        panelScaler.ScaleX = closeTarget;
        isOpen = false;
    }

    private void Update()
    {
        if (IsAnimating)
        {
            panelScaler.ScaleX = Mathf.Lerp(startValue, targetValue, AnimationTime());
        }
    }

    public void Open()
    {
        startValue = panelScaler.ScaleX;
        targetValue = openTarget;
        SetOpenAnimation();
        isOpen = true;
    }

    public void Close()
    {
        startValue = panelScaler.ScaleX;
        targetValue = closeTarget;
        SetCloseAnimation();
        isOpen = false;
    }
}
