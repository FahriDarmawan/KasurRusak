using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform button;

    void Start()
    {
        button.GetComponent<Animator>().Play("Normal");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("Hover");
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("Normal");
    }
}
