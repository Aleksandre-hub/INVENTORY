using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArmorPanelScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector2 startPosition;
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }


}
