using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    //public List<GameObject> slots;
    public List<GameObject> slots = new List<GameObject>();
    public List<bool> used = new List<bool>();
    public List<Image> slotImage = new List<Image>();
    public List<ItemSlot> itemSlot = new List<ItemSlot>();

    private bool Bool;

    public int consumableCount = 1;
    private int localChildCount;

    private ButtonManager BMinstance;
    private GameManager GMinstance;

    public GameObject objectsParent;

    private void Start()
    {
        BMinstance = ButtonManager.Instance;
        GMinstance = GameManager.Instance;

        slots = BMinstance.slots;
        slotImage = BMinstance.slotImage;
        itemSlot = BMinstance.itemSlots;

        used = BMinstance.used;
        used.Capacity = BMinstance.used.Capacity;

        consumableCount = gameObject.transform.childCount - 1;
    }

    private void Update()
    {

        if (gameObject.transform.childCount < 2)
        {
            slotImage = BMinstance.slotImage;
            slotImage[slots.IndexOf(gameObject)].color = Color.white;
        }

        if (consumableCount == 1) {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }else if (consumableCount > 1) {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            gameObject.transform.GetChild(0).GetComponent<Text>().text = consumableCount.ToString();

            used = BMinstance.used;
            used.Capacity = BMinstance.used.Capacity;
            for (int i = 0; i < used.Count; i++) {
                if (gameObject == slots[i]) {
                    if (consumableCount == 10) {
                        used[i] = true;
                    }else if (consumableCount < 10) {
                        used[i] = false;
                    }
                }
            }
        }

        if (gameObject.transform.childCount > 1) {
            for (int i = 0; i < used.Count; i++) {
                if (gameObject == slots[i] && !gameObject.transform.GetChild(1).CompareTag("Consumable")) {
                    used[i] = true;
                }else if (gameObject == slots[i] && !gameObject.transform.GetChild(1).CompareTag("Consumable") && itemSlot[i].consumableCount == 10) {
                    used[i] = true;
                }
            }

        }

        if ((gameObject.transform.childCount > 1 && !gameObject.transform.GetChild(1).CompareTag("Consumable")) || gameObject.transform.childCount == 1) {
            consumableCount = 0;
        }

        if (consumableCount > 0) {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetComponent<Text>().text = (consumableCount).ToString();
        }else if (consumableCount == 0) 
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetComponent<Text>().text = (consumableCount).ToString();
        }

        if (gameObject.transform.childCount == 1)
        {

            for (int i = 0; i < used.Count; i++)
            {
                
                if (gameObject == slots[i])
                {
                    used[i] = false;
                }
            }

            consumableCount = 0;
            gameObject.transform.GetChild(0).GetComponent<Text>().text = (consumableCount).ToString();
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (consumableCount < 0)
        {
            consumableCount = 0;
            gameObject.transform.GetChild(0).GetComponent<Text>().text = (consumableCount).ToString();
        }

        if (consumableCount > 1) {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).GetComponent<Text>().text = (consumableCount).ToString();
        }else if (consumableCount <= 1 && consumableCount > 0) {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetComponent<Text>().text = (consumableCount).ToString();
        }
    }

    public void CheckChildCount() {
        localChildCount = gameObject.transform.childCount;
    }

    public void takeArray() {
        slots = BMinstance.slots;
    } 

    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag.gameObject.GetComponent<DragDrop>() == null) {
            return;
        }

        if (gameObject.CompareTag("DeleteItemButton")) {
            Destroy(eventData.pointerDrag.gameObject);
        }

        used = BMinstance.used;
        used.Capacity = BMinstance.used.Capacity;
        for (int i = 0; i < slots.Count; i++) {
            if (gameObject == slots[i]) {
                Debug.Log("CAME IN ONDROP: " + eventData.pointerDrag.name + " || slot name: " + gameObject.name + " || childcount: " + gameObject.transform.childCount + " || consumableCount: " + consumableCount);

                if (BMinstance.name.Contains("(Clone)"))
                {
                    BMinstance.name = BMinstance.name.Replace("(Clone)", "");
                }


                if (eventData.pointerDrag != null && (gameObject.transform.childCount == 1 || gameObject.transform.GetChild(1).gameObject == eventData.pointerDrag)
                && !eventData.pointerDrag.gameObject.CompareTag("Consumable")) {


                    eventData.pointerDrag.transform.parent = gameObject.transform;
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

                }
                else if(eventData.pointerDrag != null && eventData.pointerDrag.gameObject.CompareTag("Consumable") && eventData.pointerDrag.gameObject.transform.parent.gameObject != gameObject
                && (gameObject.transform.childCount < 2 || eventData.pointerDrag.name.Contains(BMinstance.name)) 
                && consumableCount <= 9) {

                    objectsParent = eventData.pointerDrag.gameObject.GetComponent<DragDrop>().startingParent;
                    var childCount = eventData.pointerDrag.transform.parent.childCount;

                    var eventDataName = eventData.pointerDrag.name.Replace("(Clone)", "");
                    Debug.Log(eventDataName);

                    Debug.Log("rightClick bool = " + eventData.pointerDrag.GetComponent<DragDrop>().rightClick);
                    used[i] = true;
                    if (eventData.pointerDrag.GetComponent<DragDrop>().rightClick && (consumableCount + objectsParent.GetComponent<ItemSlot>().consumableCount) <= 10)
                    {
                        if (gameObject.transform.childCount > 1 && gameObject.transform.GetChild(1).name.Contains(eventDataName) || gameObject.transform.childCount == 1) {
                            Debug.Log("trsn");
                            if (gameObject.transform.childCount > 1)
                            {
                                Destroy(eventData.pointerDrag);
                            }

                            consumableCount += eventData.pointerDrag.GetComponent<DragDrop>().consumableCount;
                            transform.GetChild(0).GetComponent<Text>().text = consumableCount.ToString();

                            for (int j = 1; j < childCount; ++j)
                            {
                                
                                Debug.Log("items parent: " + objectsParent + " || childCount: " + childCount);
                                Debug.Log("item : " + eventData.pointerDrag.gameObject.name + " || Iteration: " + j);

                                
                                eventData.pointerDrag.gameObject.transform.parent = gameObject.transform;

                                if (gameObject.transform.childCount > 1)
                                {
                                    gameObject.transform.GetChild(j).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                                }

                            }
                        }else {
                            
                            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                        }
                        
                        //eventData.pointerDrag.GetComponent<DragDrop>().rightClick = false;
                    }
                    else if (!eventData.pointerDrag.GetComponent<DragDrop>().rightClick && ((gameObject.transform.childCount > 1 && gameObject.transform.GetChild(1).name.Contains(eventDataName)) || gameObject.transform.childCount == 1) )
                    {
                        objectsParent.GetComponent<ItemSlot>().consumableCount -= 1;
                        consumableCount += 1;
                        if (consumableCount > 1)
                        {
                            Debug.Log("consumableCount: " + consumableCount);
                            Destroy(eventData.pointerDrag.gameObject);
                        }
                        eventData.pointerDrag.transform.parent = gameObject.transform;
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                        Debug.Log("game object anchored position = " + gameObject.GetComponent<RectTransform>().anchoredPosition);


                    }else {
                        Debug.Log("NICEU");
                    }

                    if (gameObject.transform.childCount > 2) {
                        gameObject.transform.GetChild(0).GetComponent<Text>().text = (gameObject.transform.childCount - 1).ToString();
                    }

                    //gameObject.transform.GetChild(0).GetComponent<Text>().text = consumableCount.ToString();
                    
                    localChildCount = gameObject.transform.childCount;

                    if (consumableCount == 10) {
                        used[i] = true;
                    }else if (consumableCount < 10) {
                        used[i] = false;
                    }

                }
                else {
                    if (eventData.pointerDrag.GetComponent<DragDrop>().rightClick)
                    {
                        var objectsParent = eventData.pointerDrag.transform.parent;
                        var childCount = eventData.pointerDrag.transform.parent.childCount;

                        for (int j = 1; j < childCount; ++j)
                        {

                            Debug.Log("items parent: " + objectsParent + " || childCount: " + childCount);
                            Debug.Log("item : " + objectsParent.GetChild(1) + " || Iteration: " + j);


                            objectsParent.GetChild(j).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

                        }
                    }else
                    {

                        for (int j = 0; j < slots.Count; j++)
                        {
                            if (BMinstance.itemSlots[j].consumableCount < 2)
                            {
                                eventData.pointerDrag.transform.SetParent(slots[j].transform);
                            }
                        }
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                        Debug.Log("NOT RIGHT PLACE!");
                    }
                   
                }
            }
            
        }
        
    }
}
