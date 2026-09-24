using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlotScript : MonoBehaviour, IDropHandler
{

    private GameManager GMinstance;
    private string[] Helmets = { "Guard", "Dark", "Hawk", "Knight", "HighKnight" };

    [SerializeField] private CanvasGroup canvasGroup;

    private float allArmor = 0;

    private float helmetArmor = 0;
    private float bodyArmor = 0;
    private float shieldArmor = 0;
    // Start is called before the first frame update
    void Start()
    {
        GMinstance = GameManager.Instance;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.tag == "ArmorSlot" && gameObject.transform.childCount < 2)  
        {
            GMinstance.bodyArmor = 0;
        }else if (gameObject.tag == "HeadgearSlot" && gameObject.transform.childCount < 2) {
            GMinstance.helmetArmor = 0;
        }else if (gameObject.tag == "ShieldSlot" && gameObject.transform.childCount < 2) {
            GMinstance.shieldArmor = 0;
        }
        
        if (gameObject.tag == "LeftRingSlot" && gameObject.transform.childCount < 2) {
            GMinstance.lefRingMP = 0;
        }else if (gameObject.tag == "RightRingSlot" && gameObject.transform.childCount < 2) {
            GMinstance.rightRingMP = 0;
        }
        

    }

    public void OnDrop(PointerEventData eventData)
    {
        
        canvasGroup = eventData.pointerDrag.GetComponent<DragDrop>().canvasGroup;

        if (gameObject.transform.childCount < 2)
        {
            Debug.Log("drop object name: " + eventData.pointerDrag.name);
            for (int i = 0; i < 5; i++)
            {
                if (gameObject.CompareTag("LeftRingSlot") && eventData.pointerDrag.CompareTag("Ring"))
                {
                    eventData.pointerDrag.transform.SetParent(gameObject.transform);
                    eventData.pointerDrag.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    GMinstance.lefRingMP = eventData.pointerDrag.GetComponent<DragDrop>().mp_bonus;
                    Debug.Log("left POWER = " + eventData.pointerDrag.GetComponent<DragDrop>().mp_bonus);

                    canvasGroup.alpha = 1;
                    canvasGroup.blocksRaycasts = true;

                    return;
                }
                else if (gameObject.CompareTag("RightRingSlot") && eventData.pointerDrag.CompareTag("Ring"))
                {
                    eventData.pointerDrag.transform.SetParent(gameObject.transform);
                    eventData.pointerDrag.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    GMinstance.rightRingMP = eventData.pointerDrag.GetComponent<DragDrop>().mp_bonus;
                    Debug.Log("right POWER = " + eventData.pointerDrag.GetComponent<DragDrop>().mp_bonus);

                    canvasGroup.alpha = 1;
                    canvasGroup.blocksRaycasts = true;

                    return;
                }
                else if (gameObject.CompareTag("ArmorSlot") && eventData.pointerDrag.name.Contains("Armor"))
                {
                    eventData.pointerDrag.transform.SetParent(gameObject.transform);
                    eventData.pointerDrag.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    GMinstance.bodyArmor = eventData.pointerDrag.GetComponent<DragDrop>().armor;

                    canvasGroup.alpha = 1;
                    canvasGroup.blocksRaycasts = true;
                    
                    return;
                }
                else if (gameObject.CompareTag("HeadgearSlot") && eventData.pointerDrag.name.Contains(Helmets[i]))
                {
                    eventData.pointerDrag.transform.SetParent(gameObject.transform);
                    eventData.pointerDrag.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    GMinstance.helmetArmor = eventData.pointerDrag.GetComponent<DragDrop>().armor;

                    canvasGroup.alpha = 1;
                    canvasGroup.blocksRaycasts = true;

                    return;
                }
                else if (gameObject.CompareTag("ShieldSlot") && eventData.pointerDrag.name.Contains("Shield"))
                {
                    eventData.pointerDrag.transform.SetParent(gameObject.transform);
                    eventData.pointerDrag.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    GMinstance.shieldArmor = eventData.pointerDrag.GetComponent<DragDrop>().armor;

                    canvasGroup.alpha = 1;
                    canvasGroup.blocksRaycasts = true;

                    return;
                }else {
                    eventData.pointerDrag.transform.SetParent(eventData.pointerDrag.GetComponent<DragDrop>().startingParent.transform);
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

                    canvasGroup.alpha = 1;
                    canvasGroup.blocksRaycasts = true;

                    continue;
                }
            }
            Debug.Log("armor rating = " + GMinstance.armor);
        }
        
        Debug.Log("armor rating = " + GMinstance.armor);
    }

}
