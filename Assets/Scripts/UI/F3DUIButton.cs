using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class F3DUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Color defaultColor;
    public Color highlightColor;
    public Color activeColor;

    public float duration;

    private Text text;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
        text.color = defaultColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(FadeTextToFrom(text, defaultColor, highlightColor, duration));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(FadeTextToFrom(text, highlightColor, defaultColor, duration));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(FadeTextToFrom(text, highlightColor, activeColor, duration));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(FadeTextToFrom(text, activeColor, highlightColor, duration));
    }

    IEnumerator FadeTextToFrom(Text text, Color fromC, Color toC, float dur)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < dur)
        {
            elapsedTime += Time.deltaTime;
            text.color = Color.Lerp(fromC, toC, (elapsedTime / dur));
            yield return null;
        }
    }

}