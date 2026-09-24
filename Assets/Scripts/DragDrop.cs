using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private List<GameObject> slots = new List<GameObject>();
    //public List<bool> used = new List<bool>();
    public List<bool> used = new List<bool>();
    private bool Bool;

    private ButtonManager BMInstance;
    private GameManager GMinstance;

    public bool rightClick = false;

    private bool senToArmorPanel = false;

    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    [SerializeField] public CanvasGroup canvasGroup;
    private Vector2 startPosition;

    private GameObject lastSelectedObject;

    private Sprite thisSprite;

    private Canvas secondaryCanvas;

    [SerializeField] private GameObject[] PotionConsumables;
    [SerializeField] private GameObject[] FooodConsumables;

    [SerializeField] private List<ItemSlot> itemSlot = new List<ItemSlot>();
    private GameObject parentObject;

    public int consumableCount = 0;

    private int position;
    public GameObject startingParent;

    public MeleeItem_BowItem_Data melee_bow;
    public StaffData staffData;
    public ArmorData armorData;
    public ConsumableData consumableData;
    public float damage;
    public float armor;
    public float hp_bonus;
    public float stamina_bonus;
    public float mp_bonus;
    public float stamina_damage;
    public float mana_damage;
    public float damage_time;
    public float mp_cost;

    private List<GameObject> slotExceptionList = new List<GameObject>();
    private bool slotException = false;

    private void Awake()
    {
        BMInstance = ButtonManager.Instance;
        GMinstance = GameManager.Instance;

        canvas = BMInstance.canvas;

        slots = BMInstance.slots;
        used = BMInstance.used;
        used.Capacity = BMInstance.used.Capacity;
        //used = new bool[slots.Capacity];

    }

    public void Start()
    {

        position = slots.IndexOf(gameObject.transform.parent.gameObject);
        startingParent = gameObject.transform.parent.gameObject;
    
        slotExceptionList = GMinstance.slotExceptionList;

        thisSprite = gameObject.GetComponent<Image>().sprite;

        PotionConsumables = BMInstance.Potions;
        FooodConsumables = BMInstance.Food;

        parentObject = gameObject.transform.parent.gameObject;

        secondaryCanvas = GMinstance.secondaryCanvas;

        for (int i = 0; i < slots.Count; i++)
        {
            itemSlot.Add(slots[i].GetComponent<ItemSlot>());
        }
        


        for (int i = 0; i < gameObject.transform.childCount; i++) {
            if (gameObject.transform.GetChild(i).GetComponent<Text>() != null) {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        if (gameObject.CompareTag("MeleeBow")) {
            damage = melee_bow.Damage;
            Debug.Log("object name: " + gameObject.name + " || damage: " + damage);
        }else if (gameObject.CompareTag("Armor")) {
            armor = armorData.Armor_bonus;
            mp_bonus = armorData.MP_bonus;
        }else if (gameObject.CompareTag("Consumable")) {
            hp_bonus = consumableData.HP_bonus;
            mp_bonus = consumableData.MP_bonus;
            stamina_bonus = consumableData.Stamina_bonus;
        }else if (gameObject.CompareTag("Staff")) {
            damage = staffData.Damage;
            hp_bonus = staffData.hp_bonus;
            stamina_damage = staffData.StaminaDamage;
            mp_cost = staffData.MP_cost;
            damage_time = staffData.DamageTime;
        }else if (gameObject.CompareTag("Ring")) {
            mp_bonus = armorData.MP_bonus;
        }

       
    }

    public void Update()
    {
        //Debug.Log("itemslot COunt = " + itemSlot.Count);
    }

    public void UsedOptimize()
    {
        
        used = BMInstance.used;
        used.Capacity = BMInstance.used.Capacity;
    }

    public void CheckConsumableCount() {
        consumableCount = itemSlot[slots.IndexOf(startingParent)].consumableCount;
        if (!gameObject.CompareTag("Consumable")) {
            consumableCount = 0;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        senToArmorPanel = false;
        gameObject.transform.SetParent(secondaryCanvas.transform);
        UsedOptimize();
        
        if (startingParent == null) {
            startingParent = gameObject.transform.parent.gameObject;
            Debug.Log("starting parent at start = " + startingParent);
        }

        if (gameObject.CompareTag("Consumable")) {
            consumableCount = itemSlot[slots.IndexOf(startingParent)].consumableCount;
        }
        
        Debug.Log("consumable Count: " + consumableCount);
        
        Debug.Log("position of " + startingParent + " object in list: " + position);

        //Debug.Log("itemslot consumable count: " + itemSlot[position].consumableCount);

        

        if (gameObject.CompareTag("Consumable") && Input.GetMouseButton(1) && itemSlot[position].consumableCount > 1)
        {
            rightClick = false;

            Debug.Log("coming in");
            var obj = Instantiate(gameObject, transform.parent.transform.position, Quaternion.identity);

            

            obj.transform.SetParent(startingParent.transform);
            var objRectTransform = obj.GetComponent<RectTransform>();
            objRectTransform.localScale = new Vector2(1.039231f, 1.039231f);
            objRectTransform.anchoredPosition = new Vector2(0, 0);

            BMInstance.spawnedItemPosition(position, gameObject.name);
            
        }
        else if (gameObject.CompareTag("Consumable") && Input.GetMouseButton(1) && itemSlot[position].consumableCount <= 1)
        {
            rightClick = false;
            BMInstance.spawnedItemPosition(position, gameObject.name);
            //itemSlot[0].consumableCount -= 1;
        }


        //Debug.Log("OnBeginDrag");
        for (int i = 0; i < slots.Count; i++) {
            
            if (gameObject.transform.parent.gameObject == slots[i]) {
                used[i] = false;

                slots[i].GetComponent<ItemSlot>().CheckChildCount();


            }
        }

        if (rightClick)
        {
            for (int i = 1; i < gameObject.transform.parent.childCount; i++)
            {
                gameObject.transform.parent.GetChild(i).GetComponent<CanvasGroup>().alpha = 0.6f;
                gameObject.transform.parent.GetChild(i).GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }else
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }

        startPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");



        if (rightClick)
        {
            for (int i = 1; i < gameObject.transform.parent.childCount; i++)
            {
                gameObject.transform.parent.GetChild(i).gameObject.GetComponent<RectTransform>().anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }else
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (gameObject.CompareTag("Consumable") && !eventData.pointerCurrentRaycast.gameObject.CompareTag("Slot") && !rightClick && startingParent.GetComponent<ItemSlot>().consumableCount != 0) {
            Destroy(gameObject);
        }else if (gameObject.CompareTag("Consumable") && !eventData.pointerCurrentRaycast.gameObject.CompareTag("Slot") && !rightClick && startingParent.GetComponent<ItemSlot>().consumableCount == 0) {
            gameObject.transform.SetParent(startingParent.transform);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            Debug.Log("RETURNED 3");
            startingParent = gameObject.transform.parent.gameObject;
            itemSlot[slots.IndexOf(startingParent)].consumableCount = consumableCount;
        }
        
        

        for (int i = 0; i < slotExceptionList.Count; i++) {
            if (eventData.pointerCurrentRaycast.gameObject == slotExceptionList[i]) {
                slotException = true;

                return;
            }else {
                slotException = false;
                startingParent = gameObject.transform.parent.gameObject;
            }
        }

        position = slots.IndexOf(gameObject.transform.parent.gameObject);
        Debug.Log("game object name = " + gameObject.name.Replace("(Clone)", ""));
        Debug.Log("eventdata current raycast name = " + eventData.pointerCurrentRaycast.gameObject.name);

        if (!eventData.pointerCurrentRaycast.gameObject.CompareTag("Slot") && slotException == false && !gameObject.CompareTag("Consumable") && rightClick) 
        {
            for (int i = 0; i < slots.Count; i++) {
                if (!itemSlot[i].used[i] && itemSlot[i].consumableCount == 0) {
                    gameObject.transform.SetParent(slots[i].transform);
                    gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    canvasGroup.alpha = 1;
                    canvasGroup.blocksRaycasts = true;
                    Debug.Log("RETURNED 1");
                    startingParent = gameObject.transform.parent.gameObject;
                    return;
                } 
            }
        }else if ((gameObject.CompareTag("Consumable") && !eventData.pointerCurrentRaycast.gameObject.CompareTag("Slot") && rightClick) || (eventData.pointerCurrentRaycast.gameObject.transform.childCount > 1 && !eventData.pointerCurrentRaycast.gameObject.transform.GetChild(1).name.Contains(gameObject.name.Replace("(Clone)", ""))) ) {                                                                  
            for (int i = 0; i < slots.Count; i++) {
                if (!itemSlot[i].used[i] && itemSlot[i].consumableCount < 10) {
                    if ((slots[i].transform.childCount > 1 && slots[i].transform.GetChild(1).name.Contains(gameObject.name.Replace("(Clone)", ""))) || slots[i].transform.childCount == 1) {
                        gameObject.transform.SetParent(slots[i].transform);
                        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                        canvasGroup.alpha = 1;
                        canvasGroup.blocksRaycasts = true;
                        Debug.Log("RETURNED 2");
                        startingParent = gameObject.transform.parent.gameObject;
                        itemSlot[i].consumableCount = consumableCount;
                        Debug.Log("starting parents first childs name: " + startingParent.transform.GetChild(0).gameObject.name);
                        Debug.Log("current consumableCount: " + consumableCount);
                        Debug.Log("starting parent: " + startingParent.name);
                        return;
                    }
                } 
            }
        }
        
     

        if (gameObject.transform.parent == secondaryCanvas.transform)
        {
            Debug.Log("comes in code");
            for (int j = 0; j < slots.Count; j++)
            {
                if (BMInstance.itemSlots[j].consumableCount < 1)
                {
                    gameObject.transform.SetParent(slots[j].transform);
                    gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    canvasGroup.alpha = 1;
                    canvasGroup.blocksRaycasts = true;

                    return;
                }
            }
            
        }else
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }

        if (gameObject.transform.parent.CompareTag("HeadgearSlot") || gameObject.transform.parent.CompareTag("ArmorSlot") 
            || gameObject.transform.parent.CompareTag("ShieldSlot") || gameObject.transform.parent.CompareTag("RingSlot"))
        {
            senToArmorPanel = true;
        }

        if (rightClick)
        {
            for (int i = 1; i < gameObject.transform.parent.childCount; i++)
            {
                if (eventData.pointerCurrentRaycast.gameObject == null || (eventData.pointerCurrentRaycast.gameObject.GetComponent<ItemSlot>() == null && eventData.pointerCurrentRaycast.gameObject.GetComponent<EquipmentSlotScript>() == null))
                {
                    gameObject.transform.parent.GetChild(i).GetComponent<RectTransform>().anchoredPosition = startPosition;
                }
            }
        }else
        {
            if (eventData.pointerCurrentRaycast.gameObject == null || (eventData.pointerCurrentRaycast.gameObject.GetComponent<ItemSlot>() == null && eventData.pointerCurrentRaycast.gameObject.GetComponent<EquipmentSlotScript>() == null))
            {
                if (itemSlot[position].consumableCount > 1)
                {
                    Debug.Log("Destroing BRUH");
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                }
                
                
            }
        }

        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("DeleteItemButton"))
        {
            Destroy(gameObject);
        }

        if (rightClick)
        {
            for (int i = 1; i < gameObject.transform.parent.childCount; i++)
            {
                gameObject.transform.parent.GetChild(i).GetComponent<CanvasGroup>().alpha = 1f;
                gameObject.transform.parent.GetChild(i).GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
            rightClick = false;
        }
        else
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }

        lastSelectedObject = gameObject;
        if (lastSelectedObject != null && !senToArmorPanel)
        {

            for (int i = 0; i < slots.Capacity; i++)
            {
                if (slots[i].transform.childCount > 1)
                {
                    for (int j = 1; j < slots[i].transform.childCount; j++)
                    {
                        if (slots[i].transform.GetChild(j).gameObject == lastSelectedObject)
                        {
                            BMInstance.CheckLastSelectedItem(lastSelectedObject, i);
                            return;
                        }
                    }
                }

            }

        }

       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        for (int i = itemSlot.Count; i < slots.Count; i++)
        {
            itemSlot.Add(slots[i].GetComponent<ItemSlot>());
        }

        lastSelectedObject = eventData.pointerCurrentRaycast.gameObject;
        if (lastSelectedObject != null) {

            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].transform.childCount > 1)
                {
                    for (int j = 1; j < slots[i].transform.childCount; j++)
                    {
                        if (slots[i].transform.GetChild(j).gameObject == lastSelectedObject)
                        {
                            BMInstance.CheckLastSelectedItem(lastSelectedObject, i);
                            
                        }
                    }
                }
               
            }
           
        }

        

        

        if (Input.GetMouseButton(0))
        {
            rightClick = true;
        }

        if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>() != null)
        {
            GameManager.Instance.ShowSelectedItem(eventData.pointerCurrentRaycast.gameObject.GetComponent<Image>().sprite);
        }
        
        
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            if (gameObject.transform.GetChild(i).GetComponent<Text>() != null) {
                GameManager.Instance.ShowSelectedItemDescription(gameObject.transform.GetChild(i).GetComponent<Text>());
            }
        }
    }

    


    public void OnPointerEnter(PointerEventData eventData) {

        for (int i = 0; i < gameObject.transform.childCount; i++) {
            if (gameObject.transform.GetChild(i).GetComponent<Text>() != null) {
                gameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        
    }

    public void OnPointerExit(PointerEventData eventData) {
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            if (gameObject.transform.GetChild(i).GetComponent<Text>() != null) {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    
}