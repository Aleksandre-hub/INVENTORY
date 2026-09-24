using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonItemScripts : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).CompareTag("Description"))
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).CompareTag("Description"))
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

}
