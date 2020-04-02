using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Scale Settings")]
    [SerializeField]
    [Range(1,2)]
    float hoveredSize;
    [SerializeField]
    [Range(1,2)]
    float clickedSize;

    [SerializeField]
    float hoverScaleFadeInTime = 0.2f;
    [SerializeField]
    float hoverScaleFadeOutTime = 0.5f;
    [SerializeField]
    float clickScaleFadeOutTime = 0.5f;


    [Header("Color Settings")]
    [SerializeField]
    Color normalColor;
    [SerializeField]
    Color hoveredColor;
    [SerializeField]
    Color clickedColor;

    [SerializeField]
    float hoverColorFadeInTime = 0.2f;
    [SerializeField]
    float hoverColorFadeOutTime = 0.5f;
    [SerializeField]
    float clickColorFadeOutTime = 0.5f;

    [SerializeField]
    float hideFadeOutTime = 0.1f;
    [SerializeField]
    float hideFadeInTime = 0.1f;

    [Header("General Options")]
    [SerializeField]
    bool disableOnClick;

    [Header("Events")]
    public UnityEvent onClickBegin;
    public UnityEvent onClickEnd;
    public UnityEvent onHoverEnter;
    public UnityEvent onHoverExit;

    bool interactable = true;
    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!interactable) return;
        if (disableOnClick) interactable = false;
        onClickBegin.Invoke();

        LeanTween.cancel(rectTransform);
        LeanTween.scale(gameObject, clickedSize * Vector3.one, 0);
        GetComponent<Image>().color = clickedColor;
        LeanTween.color(rectTransform, normalColor, clickColorFadeOutTime);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!interactable) return;
        onHoverEnter.Invoke();

        LeanTween.cancel(rectTransform);
        LeanTween.scale(gameObject, hoveredSize*Vector3.one, hoverScaleFadeInTime);
        LeanTween.color(rectTransform, hoveredColor, hoverColorFadeInTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!interactable) return;
        onHoverExit.Invoke();

        LeanTween.cancel(rectTransform);
        LeanTween.scale(gameObject, Vector3.one, hoverScaleFadeOutTime);
        LeanTween.color(rectTransform, normalColor, hoverColorFadeOutTime);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void Hide()
    {
    }
    public void Show()
    {
    }

    void CompleteClick()
    {
        Debug.Log("Click");
        onClickBegin.Invoke();
    }


    private void OnValidate()
    {
        GetComponent<Image>().color = normalColor;
    }




}
