using System.Xml.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private List<List<GameObject>> listOfAllLists = new List<List<GameObject>>();
    [SerializeField] private List<GameObject> all2HSwords = new List<GameObject>();
    [SerializeField] private List<GameObject> allLongSwords = new List<GameObject>();
    [SerializeField] private List<GameObject> allCurvedSwords = new List<GameObject>();
    [SerializeField] private List<GameObject> allDaggerSwords = new List<GameObject>();
    [SerializeField] private List<GameObject> all2Shortwords = new List<GameObject>();
    [SerializeField] private List<GameObject> all2HAxes = new List<GameObject>();
    [SerializeField] private List<GameObject> allVikingAxes = new List<GameObject>();
    [SerializeField] private List<GameObject> allFolkAxes = new List<GameObject>();
    [SerializeField] private List<GameObject> allOldAxes = new List<GameObject>();
    [SerializeField] private List<GameObject> allSteelAxes = new List<GameObject>();
    [SerializeField] private List<GameObject> allBattleBows = new List<GameObject>();
    [SerializeField] private List<GameObject> allHunterBows = new List<GameObject>();
    [SerializeField] private List<GameObject> allMarauderBows = new List<GameObject>();
    [SerializeField] private List<GameObject> allRedwoodBows = new List<GameObject>();
    [SerializeField] private List<GameObject> allVikingBows = new List<GameObject>();
    [SerializeField] private List<GameObject> allCursedStaffs = new List<GameObject>();
    [SerializeField] private List<GameObject> allNatureStaffs = new List<GameObject>();
    [SerializeField] private List<GameObject> allFireStaffs = new List<GameObject>();
    [SerializeField] private List<GameObject> allHealingStaffs = new List<GameObject>();
    [SerializeField] private List<GameObject> allWaterStaffs = new List<GameObject>();
    [SerializeField] private List<GameObject> allGladiatorShields = new List<GameObject>();
    [SerializeField] private List<GameObject> allMilitiaShields = new List<GameObject>();
    [SerializeField] private List<GameObject> allSteelShields = new List<GameObject>();
    [SerializeField] private List<GameObject> allWoodenShields = new List<GameObject>();
    [SerializeField] private List<GameObject> allIronShields = new List<GameObject>();
    [SerializeField] private List<GameObject> allGreatHPPotions = new List<GameObject>();
    [SerializeField] private List<GameObject> allSmallHPPotions = new List<GameObject>();
    [SerializeField] private List<GameObject> allGreatMPPotions = new List<GameObject>();
    [SerializeField] private List<GameObject> allSmallMPPotions = new List<GameObject>();
    [SerializeField] private List<GameObject> allMPHPPotions = new List<GameObject>();
    [SerializeField] private List<GameObject> allGuardHelmets = new List<GameObject>();
    [SerializeField] private List<GameObject> allDarkHelmets = new List<GameObject>();
    [SerializeField] private List<GameObject> allHawkHelmets = new List<GameObject>();
    [SerializeField] private List<GameObject> allHighKnightHelmets = new List<GameObject>();
    [SerializeField] private List<GameObject> allKnightHelmets = new List<GameObject>();
    [SerializeField] private List<GameObject> allBanditArmor = new List<GameObject>();
    [SerializeField] private List<GameObject> allGuardArmor = new List<GameObject>();
    [SerializeField] private List<GameObject> allDarkArmor = new List<GameObject>();
    [SerializeField] private List<GameObject> allManticoreArmor = new List<GameObject>();
    [SerializeField] private List<GameObject> allPlatArmor = new List<GameObject>();
    [SerializeField] private List<GameObject> allBronzeRings = new List<GameObject>();
    [SerializeField] private List<GameObject> allGoldRings = new List<GameObject>();
    [SerializeField] private List<GameObject> allMagicGoldRings = new List<GameObject>();
    [SerializeField] private List<GameObject> allMagicBronzeRings = new List<GameObject>();
    [SerializeField] private List<GameObject> allMagicSilverRings = new List<GameObject>();
    [SerializeField] private List<GameObject> allAppleFood = new List<GameObject>();
    [SerializeField] private List<GameObject> allCheeseFood = new List<GameObject>();
    [SerializeField] private List<GameObject> allGrogFood = new List<GameObject>();
    [SerializeField] private List<GameObject> allMeatFood = new List<GameObject>();
    [SerializeField] private List<GameObject> allChickenFood = new List<GameObject>();

    [SerializeField] private List<int> consumableCounts = new List<int>();

    [SerializeField] private GameObject ListPanel;
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject InventoryPanel;

    [SerializeField] private GameObject[] subLists;

    public List<GameObject> slots = new List<GameObject>();
    public List<bool> used = new List<bool>();
    private bool BOOL;
    //public GameObject[] slots;

    [SerializeField] private GameObject[] swords;
    [SerializeField] private GameObject[] Axes;
    [SerializeField] private GameObject[] Bows;
    [SerializeField] private GameObject[] Staffs;
    [SerializeField] private GameObject[] Shields;
    public GameObject[] Potions;
    [SerializeField] private GameObject[] Helmets;
    [SerializeField] private GameObject[] Armor;
    [SerializeField] private GameObject[] Rings;
    public GameObject[] Food;

    [SerializeField] private GameObject scrollView;
    public float yAXIS;


    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private Transform rowsParent;


    [SerializeField] private GameObject slotBox;
    [SerializeField] private List<GameObject> slotRow = new List<GameObject>();
    private int slotCount = 0;

    // optimal

    private GameObject newItem;
    public List<ItemSlot> itemSlots = new List<ItemSlot>();
    public List<Image> slotImage = new List<Image>();
    [SerializeField] private List<Transform> slotTransform = new List<Transform>();

    //optimal

    public int position;
    public string name;

    private int lastTwoSelectedItemsCount = 0;
    private GameObject[] lastTwoSelectedItems;
    private GameObject lastSelectedItemBTN;
    private int lasSelectedItemIndex;
    private GameObject automaticSelectGameObject;

    public Canvas canvas;

    private GameManager GMInstance;

    private bool noStackables = false;

    public static ButtonManager Instance;
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        GMInstance = GameManager.Instance;

        listOfAllLists.Add(all2HSwords); //0
        listOfAllLists.Add(allLongSwords); //1
        listOfAllLists.Add(allCurvedSwords); //2
        listOfAllLists.Add(allDaggerSwords); //3
        listOfAllLists.Add(all2Shortwords); //4

        listOfAllLists.Add(all2HAxes); //5
        listOfAllLists.Add(allVikingAxes); //6
        listOfAllLists.Add(allFolkAxes); //7
        listOfAllLists.Add(allOldAxes); //8
        listOfAllLists.Add(allSteelAxes); //9

        listOfAllLists.Add(allBattleBows); //10
        listOfAllLists.Add(allHunterBows); //11
        listOfAllLists.Add(allMarauderBows); //12
        listOfAllLists.Add(allRedwoodBows); //13
        listOfAllLists.Add(allVikingBows); //14

        listOfAllLists.Add(allCursedStaffs); //15
        listOfAllLists.Add(allNatureStaffs); //16
        listOfAllLists.Add(allFireStaffs); //17
        listOfAllLists.Add(allHealingStaffs); //18
        listOfAllLists.Add(allWaterStaffs); //19

        listOfAllLists.Add(allGladiatorShields); //20
        listOfAllLists.Add(allMilitiaShields); //21
        listOfAllLists.Add(allSteelShields); //22
        listOfAllLists.Add(allWoodenShields); //23
        listOfAllLists.Add(allIronShields); //24

        listOfAllLists.Add(allGreatHPPotions); //25
        listOfAllLists.Add(allGreatMPPotions); //26
        listOfAllLists.Add(allSmallMPPotions); //27
        listOfAllLists.Add(allSmallHPPotions); //28
        listOfAllLists.Add(allMPHPPotions); //29

        listOfAllLists.Add(allGuardHelmets); //30
        listOfAllLists.Add(allDarkHelmets); //31
        listOfAllLists.Add(allHawkHelmets); //32
        listOfAllLists.Add(allHighKnightHelmets); //33
        listOfAllLists.Add(allKnightHelmets); //34

        listOfAllLists.Add(allBanditArmor); //35
        listOfAllLists.Add(allGuardArmor); //36
        listOfAllLists.Add(allDarkArmor); //37
        listOfAllLists.Add(allPlatArmor); //38
        listOfAllLists.Add(allManticoreArmor); //39

        listOfAllLists.Add(allBronzeRings); //40
        listOfAllLists.Add(allGoldRings); //41
        listOfAllLists.Add(allMagicBronzeRings); //42
        listOfAllLists.Add(allMagicGoldRings); //43
        listOfAllLists.Add(allMagicSilverRings); //44

        listOfAllLists.Add(allAppleFood); //45
        listOfAllLists.Add(allCheeseFood); //46
        listOfAllLists.Add(allChickenFood); //47
        listOfAllLists.Add(allGrogFood); //48
        listOfAllLists.Add(allMeatFood); //49

        for (int i = 0; i < slots.Count; i++)
        {
            itemSlots.Add(slots[i].GetComponent<ItemSlot>());
            slotImage.Add(slots[i].GetComponent<Image>());
            used.Add(BOOL);
        }



        slots.Capacity = slots.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenArmorPanel(GameObject armorPanel)
    {
        armorPanel.SetActive(true);
    }

    public void CloseArmorPanel(GameObject armorPanel)
    {
        armorPanel.SetActive(false);
    }

    public void OpenStatsPanel(GameObject statsPanel)
    {
        statsPanel.SetActive(true);
    }

    public void CloseStatsPanel(GameObject statsPanel)
    {
        statsPanel.SetActive(false);
    }

    public void spawnedItemPosition(int position, string name)
    {
        this.position = position;
        this.name = name;

        if (name.Contains("(Clone)"))
        {
            name = name.Replace("(Clone)", "");
        }
        
    }
    public void CheckLastSelectedItem(GameObject lastSelectedItem, int i) {
        lastSelectedItemBTN = lastSelectedItem;
        lasSelectedItemIndex = i;
        

        if (i > -1)
        {
            slotImage[i].color = Color.black;
        }
        
        for (int j = 0; j < slots.Count; j++)
        {
            if(j != i)
            {
                slotImage[j].color = Color.white;
            }
        }

        if (lastSelectedItemBTN != null)
        {
            GMInstance.ShowSelectedItem(lastSelectedItemBTN.GetComponent<Image>().sprite);
            for (int j = 0; j < lastSelectedItemBTN.transform.childCount; j++)
            {
                if (lastSelectedItemBTN.transform.GetChild(j).gameObject.GetComponent<Text>() != null)
                {
                    GMInstance.ShowSelectedItemDescription(lastSelectedItemBTN.transform.GetChild(j).GetComponent<Text>());
                }
            }
        }
    }

    // [sword] [shield]

    public void ItemUse() {


        if (lastSelectedItemBTN != null) {
            if (lastSelectedItemBTN.CompareTag("MeleeBow")){
                GMInstance.UseItemMeleeBow(lastSelectedItemBTN);
            }else if (lastSelectedItemBTN.CompareTag("Armor")){
                GMInstance.EquipArmor(lastSelectedItemBTN);
            }else if (lastSelectedItemBTN.CompareTag("Staff")) {
                GMInstance.UseStaff(lastSelectedItemBTN);
            }else if (lastSelectedItemBTN.CompareTag("Consumable")) {
                GMInstance.Consume(lastSelectedItemBTN);
                Debug.Log("lastitem: " + lastSelectedItemBTN.transform.parent.gameObject);
                Debug.Log("lastitem index in slots: " + lastSelectedItemBTN.transform.parent.gameObject);
                if (itemSlots[slots.IndexOf(lastSelectedItemBTN.transform.parent.gameObject)].consumableCount <= 1)
                {
                    Destroy(lastSelectedItemBTN);
                }else
                {
                    itemSlots[slots.IndexOf(lastSelectedItemBTN.transform.parent.gameObject)].consumableCount -= 1;
                }
            }else {
                Debug.Log("raga darcha? :D");
            }
        }else {
            Debug.Log("Fixed Error");
        }
        
    
    }

    public void DeleteSelectedItem() {

        if (lastSelectedItemBTN != null && lasSelectedItemIndex > -1)
        {
            var pos = slots.IndexOf(lastSelectedItemBTN.transform.parent.gameObject);

            if (itemSlots[pos].consumableCount <= 1)
            {
                Destroy(lastSelectedItemBTN);
                DeleteFromList(lastSelectedItemBTN);
                for (int i = 1; i < slots.Count; i++)
                {
                    if (pos + i > (slots.Count-1))
                    {
                        CheckLastSelectedItem(null, -1);
                        return;
                    }
                    else if (slots[pos + i].transform.childCount > 1)
                    {
                        CheckLastSelectedItem(slots[pos + i].transform.GetChild(1).gameObject, pos + i);
                        return;
                    }
                }
                
                
            }else
            {
                itemSlots[pos].consumableCount -= 1;
                CheckLastSelectedItem(slots[pos].transform.GetChild(1).gameObject, pos);
            }
            
            
        }else
        {
            CheckLastSelectedItem(null, -1);
            Debug.Log(lastSelectedItemBTN);
        }
    }

    private void DeleteFromList(GameObject lastSelectedItemBTN) {

        Debug.Log("from list delete section = " + lastSelectedItemBTN.name);
        for (int i = 0; i < listOfAllLists.Count; i++) {
            
            for (int j = 0; j < listOfAllLists[i].Count; j++) {
                if (lastSelectedItemBTN == listOfAllLists[i][j]) {
                    Debug.Log("the item was found on " + i + " list and it was " + j + " element of the said list");
                    listOfAllLists[i].Remove(listOfAllLists[i][j]);
                }
            }
            
        }
    }

    public void MoreHeight() {

        if (slotCount > 1) {
            scrollView.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 89);
        }
        slotCount += 1;

        GameObject newGo = Instantiate(rowPrefab, rowsParent);

        slotRow.Add(newGo);

        for (int i = 0; i < newGo.transform.childCount; i++)
        {
            slots.Add(newGo.transform.GetChild(i).gameObject);
            used.Add(BOOL);
        }

        var itemSlot = itemSlots[0];

        itemSlot.takeArray();

        for (int i = 0; i < scrollView.gameObject.transform.childCount; i++) {
            scrollView.gameObject.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition += new Vector2(0, yAXIS);
        }

      
        var Cap = itemSlots.Count;
        for (int i = Cap; i < slots.Count; i++)
        {
            itemSlots.Add(slots[i].GetComponent<ItemSlot>());
            slotImage.Add(slots[i].GetComponent<Image>());
        }

    }

    public void InventoryButton()
    {
        MainPanel.SetActive(false);
        ListPanel.SetActive(true);
        InventoryPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        MainPanel.SetActive(true);
        ListPanel.SetActive(false);
        InventoryPanel.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void Sort() {


        var nextSlot = 0;
        Debug.Log("must be sorting DUNNO :/");
        for (int i = 0; i < listOfAllLists.Count; i++) {
            
            if (listOfAllLists[i].Count != 0) {
                for (int j = 0; j < listOfAllLists[i].Count; j++) {
                    if (j < slots.Count && nextSlot < slots.Count) {
                        // Debug.Log("numeration of this list in main list[i] = " + i + " element number in this list[j] = " + j);
                        // Debug.Log("count of the list = " + listOfAllLists[i].Count);
                        // Debug.Log("element name of this list = " + listOfAllLists[i][j].name);
                        // Debug.Log("number of nextSlot var = " + nextSlot);
                        // Debug.Log("slots count = " + slots.Count);
                        if (listOfAllLists[i][j].CompareTag("Consumable")) {

                            // Debug.Log("the parent of this item = " + listOfAllLists[i][j].transform.parent.gameObject.name);
                            // Debug.Log("the slot we are moving to = " + slots[nextSlot].name);
                            // Debug.Log("THE THIS = " + listOfAllLists[i][j].GetComponent<DragDrop>().consumableCount);

                            itemSlots[nextSlot].consumableCount = listOfAllLists[i][j].GetComponent<DragDrop>().consumableCount;

                            listOfAllLists[i][j].transform.SetParent(slots[nextSlot].transform);
                            listOfAllLists[i][j].GetComponent<DragDrop>().startingParent = slots[nextSlot].transform.gameObject;
                            listOfAllLists[i][j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

                        }else {
                            listOfAllLists[i][j].transform.SetParent(slots[nextSlot].transform);
                            listOfAllLists[i][j].GetComponent<DragDrop>().startingParent = slots[nextSlot].transform.gameObject;
                            listOfAllLists[i][j].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                        }
                        nextSlot += 1;
                    }
                }
            }else {
                continue;
            }
        }
    }

    public void SwordsButton()
    {
        for(int i = 0; i < subLists.Length; i++)
        {
            if (i != 0)
            {
                subLists[i].SetActive(false);
            }
        }
        subLists[0].SetActive(true);
    }

    // Sword spawn Code

    public void Spawn2HSword()
    {

        for (int i = 0; i < slots.Count; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }

                var newSword = Instantiate(swords[0], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                all2HSwords.Add(newSword);
                return;
            } 
        }

    }

    public void SpawnLongsword()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(swords[1], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allLongSwords.Add(newSword);
                return;
            }
        }

    }

    public void wirexa () {
        Debug.Log("wirexa");
    }

    public void SpawnCurved()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(swords[2], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allCurvedSwords.Add(newSword);
                return;
            }
        }

    }

    public void SpawnDagger()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(swords[3], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allDaggerSwords.Add(newSword);
                return;
            }
        }

    }

    public void SpawnShort()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(swords[4], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                all2Shortwords.Add(newSword);
                return;
            }
        }

    }

    // Sword spawn code 

    public void AxesButton()
    {
        for (int i = 0; i < subLists.Length; i++)
        {
            if (i != 1)
            {
                subLists[i].SetActive(false);
            }
        }
        subLists[1].SetActive(true);
    }

    // Axes spawn code

    public void Spawn2HAxe()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Axes[0], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                all2HAxes.Add(newSword);
                return;
            } 
        }

    }

    public void VikingAxe()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Axes[1], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allVikingAxes.Add(newSword);
                return;
            } 
        }

    }

    public void FolkAxe()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Axes[2], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allFolkAxes.Add(newSword);
                return;
            } 
        }

    }

    public void OldAxe()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Axes[3], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allOldAxes.Add(newSword);
                return;
            } 
        }

    }

    public void SteelAxe()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Axes[4], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allSteelAxes.Add(newSword);
                return;
            } 
        }

    }

    // Axes spawn code

    public void BowsButton()
    {
        for (int i = 0; i < subLists.Length; i++)
        {
            if (i != 2)
            {
                subLists[i].SetActive(false);
            }
        }
        subLists[2].SetActive(true);
    }

    // Bows spawn code

    public void BattleBow()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Bows[0], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allBattleBows.Add(newSword);
                return;
            } 
        }

    }

    public void HunterBow()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Bows[1], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allHunterBows.Add(newSword);
                return;
            } 
        }

    }

    public void MarauderBow()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Bows[2], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allMarauderBows.Add(newSword);
                return;
            } 
        }

    }

    public void RedWoodBow()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Bows[3], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allRedwoodBows.Add(newSword);
                return;
            } 
        }

    }

    public void VikingBow()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Bows[4], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allVikingBows.Add(newSword);
                return;
            } 
        }

    }

    // Bows spawn code

    public void StaffsButton()
    {
        for (int i = 0; i < subLists.Length; i++)
        {
            if (i != 3)
            {
                subLists[i].SetActive(false);
            }
        }
        subLists[3].SetActive(true);
    }
    
    // Staff spawn code

    public void CursedStaff()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Staffs[0], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allCursedStaffs.Add(newSword);
                return;
            } 
        }

    }

    public void NatureStaff()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Staffs[1], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allNatureStaffs.Add(newSword);
                return;
            } 
        }

    }

    public void FireStaff()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Staffs[2], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allFireStaffs.Add(newSword);
                return;
            } 
        }

    }

    public void HealingStaff()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Staffs[3], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allHealingStaffs.Add(newSword);
                return;
            } 
        }

    }

    public void WaterStaff()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Staffs[4], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allWaterStaffs.Add(newSword);
                return;
            } 
        }

    }

    // Staff spawn cpde

    public void ShieldsButton()
    {
        for (int i = 0; i < subLists.Length; i++)
        {
            if (i != 4)
            {
                subLists[i].SetActive(false);
            }
        }
        subLists[4].SetActive(true);
    }

    // Shield spawn code

    public void GladiatorShield()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (slots[i].transform.childCount > 1) {
                    continue;
                }
            if (itemSlots[i].used[i] == false)
            {
                var newSword = Instantiate(Shields[0], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allGladiatorShields.Add(newSword);
                return;
            } 
        }

    }

    public void MilitiaShield()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Shields[1], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allMilitiaShields.Add(newSword);
                return;
            } 
        }

    }

    public void SteelShield()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Shields[2], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allSteelShields.Add(newSword);
                return;
            } 
        }

    }

    public void WoodenShield()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Shields[3], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allWoodenShields.Add(newSword);
                return;
            } 
        }

    }

    public void IronShield()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Shields[4], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allIronShields.Add(newSword);
                return;
            } 
        }

    }

    // Shield spawn code

    public void PotionsButton()
    {
        for (int i = 0; i < subLists.Length; i++)
        {
            if (i != 5)
            {
                subLists[i].SetActive(false);
            }
        }
        subLists[5].SetActive(true);
    }

    // Potion spawn code

    public void GreatHPPotion()
    {

        for (int i = 0; i < slots.Count; i++)
        {
            
            if (itemSlots[i].used[i] == false && itemSlots[i].consumableCount > 0)
            {
                
                if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Potions[0].name)) {
                    Debug.Log("spawn name: " + Potions[0].name + "(Clone)");
                    Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                    Debug.Log("not here");
                    noStackables = true;
                    continue;
                }

                

                if (slots[i].gameObject.transform.childCount > 1) {
                    itemSlots[i].consumableCount += 1;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                }else
                {
                    Debug.Log("Strange");
                    itemSlots[i].consumableCount += 1;
                    var newSword = Instantiate(Potions[0], slots[i].transform.position, Quaternion.identity);
                    newSword.transform.parent = slots[i].transform;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                    allGreatHPPotions.Add(newSword);
                    noStackables = false;
                    return;
                }
                
                //slots[i].GetComponent<ItemSlot>().used[i] = true;
                return;
            }else {
                noStackables = true;
            }
            
            
        }

        if (noStackables = true)
        {
            for (int i = 0; i < slots.Capacity; i++)
            {
                if (itemSlots[i].used[i] == false)
                {
                    

                    if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Potions[0].name))
                    {
                        Debug.Log("spawn name: " + Potions[0].name + "(Clone)");
                        Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                        Debug.Log("not here");
                        continue;
                    }

                    if (slots[i].gameObject.transform.childCount > 1)
                    {
                        itemSlots[i].consumableCount += 1;
                    }
                    else
                    {
                        itemSlots[i].consumableCount += 1;
                        var newSword = Instantiate(Potions[0], slots[i].transform.position, Quaternion.identity);
                        newSword.transform.parent = slots[i].transform;
                        allGreatHPPotions.Add(newSword);
                        return;
                    }

                    //slots[i].GetComponent<ItemSlot>().used[i] = true;
                    return;
                }
            }
            noStackables = false;
        }
        

    }

    public void GreatMPPotion()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (itemSlots[i].used[i] == false && itemSlots[i].consumableCount > 0)
            {

                if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Potions[1].name)) {
                    Debug.Log("spawn name: " + Potions[1].name + "(Clone)");
                    Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                    Debug.Log("not here");
                    noStackables = true;
                    continue;
                }

                if (slots[i].gameObject.transform.childCount > 1)
                {
                    itemSlots[i].consumableCount += 1;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                }
                else
                {
                    itemSlots[i].consumableCount += 1;
                    var newSword = Instantiate(Potions[1], slots[i].transform.position, Quaternion.identity);
                    newSword.transform.parent = slots[i].transform;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                    allGreatMPPotions.Add(newSword);
                    noStackables = false;
                }
                return;
            } 
        }

        if (noStackables = true)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (itemSlots[i].used[i] == false)
                {

                    if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Potions[1].name))
                    {
                        Debug.Log("spawn name: " + Potions[1].name + "(Clone)");
                        Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                        Debug.Log("not here");
                        continue;
                    }

                    if (slots[i].gameObject.transform.childCount > 1)
                    {
                        itemSlots[i].consumableCount += 1;
                    }
                    else
                    {
                        itemSlots[i].consumableCount += 1;
                        var newSword = Instantiate(Potions[1], slots[i].transform.position, Quaternion.identity);
                        newSword.transform.parent = slots[i].transform;
                        allGreatMPPotions.Add(newSword);
                        return;
                    }

                    //slots[i].GetComponent<ItemSlot>().used[i] = true;
                    return;
                }
            }
            noStackables = false;
        }

    }

    public void SmallMPPotion()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (itemSlots[i].used[i] == false && itemSlots[i].consumableCount > 0)
            {
                if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Potions[2].name)) {
                    Debug.Log("spawn name: " + Potions[2].name + "(Clone)");
                    Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                    Debug.Log("not here");
                    noStackables = true;
                    continue;
                }

                if (slots[i].gameObject.transform.childCount > 1)
                {
                    itemSlots[i].consumableCount += 1;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                }
                else
                {
                    itemSlots[i].consumableCount += 1;
                    var newSword = Instantiate(Potions[2], slots[i].transform.position, Quaternion.identity);
                    newSword.transform.parent = slots[i].transform;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                    allSmallMPPotions.Add(newSword);
                    noStackables = false;
                }
                return;
            } 
        }

        if (noStackables = true)
        {
            for (int i = 0; i < slots.Capacity; i++)
            {
                if (itemSlots[i].used[i] == false)
                {

                    if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Potions[2].name))
                    {
                        Debug.Log("spawn name: " + Potions[2].name + "(Clone)");
                        Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                        Debug.Log("not here");
                        continue;
                    }

                    if (slots[i].gameObject.transform.childCount > 1)
                    {
                        itemSlots[i].consumableCount += 1;
                    }
                    else
                    {
                        itemSlots[i].consumableCount += 1;
                        var newSword = Instantiate(Potions[2], slots[i].transform.position, Quaternion.identity);
                        newSword.transform.parent = slots[i].transform;
                        allSmallMPPotions.Add(newSword);
                        return;
                    }

                    //slots[i].GetComponent<ItemSlot>().used[i] = true;
                    return;
                }
            }
            noStackables = false;
        }

    }

    public void SmallHPPotion()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (itemSlots[i].used[i] == false && itemSlots[i].consumableCount > 0)
            {
                if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Potions[3].name)) {
                    Debug.Log("spawn name: " + Potions[3].name + "(Clone)");
                    Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                    Debug.Log("not here");
                    noStackables = true;
                    continue;
                }

                if (slots[i].gameObject.transform.childCount > 1)
                {
                    itemSlots[i].consumableCount += 1;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                }
                else
                {
                    itemSlots[i].consumableCount += 1;
                    var newSword = Instantiate(Potions[3], slots[i].transform.position, Quaternion.identity);
                    newSword.transform.parent = slots[i].transform;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                    allSmallHPPotions.Add(newSword);
                    noStackables = true;
                }
                return;
            } 
        }

        if (noStackables = true)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (itemSlots[i].used[i] == false)
                {

                    if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Potions[3].name))
                    {
                        Debug.Log("spawn name: " + Potions[3].name + "(Clone)");
                        Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                        Debug.Log("not here");
                        continue;
                    }

                    if (slots[i].gameObject.transform.childCount > 1)
                    {
                        itemSlots[i].consumableCount += 1;
                    }
                    else
                    {
                        itemSlots[i].consumableCount += 1;
                        var newSword = Instantiate(Potions[3], slots[i].transform.position, Quaternion.identity);
                        newSword.transform.parent = slots[i].transform;
                        allSmallHPPotions.Add(newSword);

                        return;
                    }

                    //slots[i].GetComponent<ItemSlot>().used[i] = true;
                    return;
                }
            }
            noStackables = false;
        }

    }

    public void HP_MPPotion()
    {
        for (int i = 0; i < slots.Count; i++)
        {

            if (itemSlots[i].used[i] == false && itemSlots[i].consumableCount > 0)
            {

                if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Potions[4].name))
                {
                    Debug.Log("spawn name: " + Potions[4].name + "(Clone)");
                    Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                    Debug.Log("not here");
                    noStackables = true;
                    continue;
                }

                if (slots[i].gameObject.transform.childCount > 1)
                {
                    itemSlots[i].consumableCount += 1;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                }
                else
                {
                    itemSlots[i].consumableCount += 1;
                    var newSword = Instantiate(Potions[4], slots[i].transform.position, Quaternion.identity);
                    newSword.transform.parent = slots[i].transform;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                    allMPHPPotions.Add(newSword);
                    noStackables = false;
                }
                return;

            }

        }

        if (noStackables = true)
        {
            for (int i = 0; i < slots.Capacity; i++)
            {
                if (itemSlots[i].used[i] == false)
                {

                    if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Potions[4].name))
                    {
                        Debug.Log("spawn name: " + Potions[4].name + "(Clone)");
                        Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                        Debug.Log("not here");
                        continue;
                    }

                    if (slots[i].gameObject.transform.childCount > 1)
                    {
                        itemSlots[i].consumableCount += 1;
                    }
                    else
                    {
                        itemSlots[i].consumableCount += 1;
                        var newSword = Instantiate(Potions[4], slots[i].transform.position, Quaternion.identity);
                        newSword.transform.parent = slots[i].transform;
                        allMPHPPotions.Add(newSword);
                        return;
                    }

                    //slots[i].GetComponent<ItemSlot>().used[i] = true;
                    return;
                }
            }
            noStackables = false;
        }

    }

    // Potion spawn code

    public void HelmentsButton()
    {
        for (int i = 0; i < subLists.Length; i++)
        {
            if (i != 6)
            {
                subLists[i].SetActive(false);
            }
        }
        subLists[6].SetActive(true);
    }

    // Helmet spawn code

    public void GuardHelmet()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (slots[i].transform.childCount > 1) {
                    continue;
                }
            if (itemSlots[i].used[i] == false)
            {
                var newSword = Instantiate(Helmets[0], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allGuardHelmets.Add(newSword);
                return;
            } 
        }

    }

    public void DarkHelmet()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Helmets[1], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allDarkHelmets.Add(newSword);
                return;
            } 
        }

    }

    public void HawkHelmet()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Helmets[2], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allHawkHelmets.Add(newSword);
                return;
            } 
        }

    }

    public void HighKnightHelmet()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Helmets[3], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allHighKnightHelmets.Add(newSword);
                return;
            } 
        }

    }

    public void KnightHelmet()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Helmets[4], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allKnightHelmets.Add(newSword);
                return;
            } 
        }

    }

    // Helmet spawn code

    public void ArmorButton()
    {
        for (int i = 0; i < subLists.Length; i++)
        {
            if (i != 7)
            {
                subLists[i].SetActive(false);
            }
        }
        subLists[7].SetActive(true);
    }

    // Armor spawn code

    public void BanditArmor()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Armor[0], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allBanditArmor.Add(newSword);
                return;
            } 
        }

    }

    public void GuardArmor()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Armor[1], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allGuardArmor.Add(newSword);
                return;
            } 
        }

    }

    public void DarkArmor()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Armor[2], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allDarkArmor.Add(newSword);
                return;
            } 
        }

    }

    public void PlatArmor()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Armor[3], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allPlatArmor.Add(newSword);
                return;
            } 
        }

    }

    public void ManticoreArmor()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Armor[4], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allManticoreArmor.Add(newSword);
                return;
            } 
        }

    }

    // Armor spawn code

    public void RingsButton()
    {
        for (int i = 0; i < subLists.Length; i++)
        {
            if (i != 8)
            {
                subLists[i].SetActive(false);
            }
        }
        subLists[8].SetActive(true);
    }

    // Rings spawn code

    public void BronzeRing()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Rings[0], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allBronzeRings.Add(newSword);
                return;
            } 
        }

    }

    public void GoldRing()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Rings[1], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allGoldRings.Add(newSword);
                return;
            } 
        }

    }

    public void MagicBronzeRing()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Rings[2], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allMagicBronzeRings.Add(newSword);
                return;
            } 
        }

    }

    public void MagicGoldRing()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Rings[3], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allMagicGoldRings.Add(newSword);
                return;
            } 
        }

    }

    public void MagicSilverRing()
    {
        for (int i = 0; i < slots.Capacity; i++)
        {
            if (itemSlots[i].used[i] == false)
            {
                if (slots[i].transform.childCount > 1) {
                    continue;
                }
                var newSword = Instantiate(Rings[4], slots[i].transform.position, Quaternion.identity);
                newSword.transform.parent = slots[i].transform;
                itemSlots[i].used[i] = true;
                allMagicSilverRings.Add(newSword);
                return;
            } 
        }

    }

    // Rings spawn code
    
    public void FoodButton()
    {
        for (int i = 0; i < subLists.Length; i++)
        {
            if (i != 9)
            {
                subLists[i].SetActive(false);
            }
        }
        subLists[9].SetActive(true);
    }

    // Food spawn code

    public void AppleFood()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (itemSlots[i].used[i] == false && itemSlots[i].consumableCount > 0)
            {

                if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Food[0].name)) {
                    Debug.Log("spawn name: " + Food[0].name + "(Clone)");
                    Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                    Debug.Log("not here");
                    noStackables = true;
                    continue;
                }

                if (slots[i].gameObject.transform.childCount > 1)
                {
                    itemSlots[i].consumableCount += 1;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                }
                else
                {
                    itemSlots[i].consumableCount += 1;
                    var newSword = Instantiate(Food[0], slots[i].transform.position, Quaternion.identity);
                    newSword.transform.parent = slots[i].transform;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                    allAppleFood.Add(newSword);
                    noStackables = false;
                }
                return;
            } 
        }

        if (noStackables = true)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (itemSlots[i].used[i] == false)
                {

                    if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Food[0].name))
                    {
                        Debug.Log("spawn name: " + Food[0].name + "(Clone)");
                        Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                        Debug.Log("not here");
                        continue;
                    }

                    if (slots[i].gameObject.transform.childCount > 1)
                    {
                        itemSlots[i].consumableCount += 1;
                    }
                    else
                    {
                        itemSlots[i].consumableCount += 1;
                        var newSword = Instantiate(Food[0], slots[i].transform.position, Quaternion.identity);
                        newSword.transform.parent = slots[i].transform;
                        allAppleFood.Add(newSword);

                        return;
                    }

                    //slots[i].GetComponent<ItemSlot>().used[i] = true;
                    return;
                }
            }
            noStackables = false;
        }

    }

    public void CheeseFood()
    {
        for (int i = 0; i < slots.Count; i++)
        {

            if (itemSlots[i].used[i] == false && itemSlots[i].consumableCount > 0)
            {

                if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Food[1].name))
                {
                    Debug.Log("spawn name: " + Food[1].name + "(Clone)");
                    Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                    Debug.Log("not here");
                    noStackables = true;
                    continue;
                }

                if (slots[i].gameObject.transform.childCount > 1)
                {
                    itemSlots[i].consumableCount += 1;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                }
                else
                {
                    itemSlots[i].consumableCount += 1;
                    var newSword = Instantiate(Food[1], slots[i].transform.position, Quaternion.identity);
                    newSword.transform.parent = slots[i].transform;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                    allCheeseFood.Add(newSword);
                    noStackables = false;
                }
                return;

            }

        }

        if (noStackables = true)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (itemSlots[i].used[i] == false)
                {

                    if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Food[1].name))
                    {
                        Debug.Log("spawn name: " + Food[1].name + "(Clone)");
                        Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                        Debug.Log("not here");
                        continue;
                    }

                    if (slots[i].gameObject.transform.childCount > 1)
                    {
                        itemSlots[i].consumableCount += 1;
                    }
                    else
                    {
                        itemSlots[i].consumableCount += 1;
                        var newSword = Instantiate(Food[1], slots[i].transform.position, Quaternion.identity);
                        newSword.transform.parent = slots[i].transform;
                        allCheeseFood.Add(newSword);
                        return;
                    }

                    //slots[i].GetComponent<ItemSlot>().used[i] = true;
                    return;
                }
            }
            noStackables = false;
        }

    }

    public void ChickenFood()
    {
        for (int i = 0; i < slots.Count; i++)
        {

            if (itemSlots[i].used[i] == false && itemSlots[i].consumableCount > 0)
            {

                if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Food[2].name))
                {
                    Debug.Log("spawn name: " + Food[2].name + "(Clone)");
                    Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                    Debug.Log("not here");
                    noStackables = true;
                    continue;
                }

                if (slots[i].gameObject.transform.childCount > 1)
                {
                    itemSlots[i].consumableCount += 1;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                }
                else
                {
                    itemSlots[i].consumableCount += 1;
                    var newSword = Instantiate(Food[2], slots[i].transform.position, Quaternion.identity);
                    newSword.transform.parent = slots[i].transform;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                    allChickenFood.Add(newSword);
                    noStackables = false;
                }
                return;

            }
        }

        if (noStackables = true)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (itemSlots[i].used[i] == false)
                {

                    if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Food[2].name))
                    {
                        Debug.Log("spawn name: " + Food[2].name + "(Clone)");
                        Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                        Debug.Log("not here");
                        continue;
                    }

                    if (slots[i].gameObject.transform.childCount > 1)
                    {
                        itemSlots[i].consumableCount += 1;
                    }
                    else
                    {
                        itemSlots[i].consumableCount += 1;
                        var newSword = Instantiate(Food[2], slots[i].transform.position, Quaternion.identity);
                        newSword.transform.parent = slots[i].transform;
                        allChickenFood.Add(newSword);

                        return;
                    }

                    //slots[i].GetComponent<ItemSlot>().used[i] = true;
                    return;
                }
            }
            noStackables = false;
        }

    }

    public void GrogFood()
    {
        for (int i = 0; i < slots.Count; i++)
        {

            if (itemSlots[i].used[i] == false && itemSlots[i].consumableCount > 0)
            {

                if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Food[3].name))
                {
                    Debug.Log("spawn name: " + Food[3].name + "(Clone)");
                    Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                    Debug.Log("not here");
                    noStackables = true;
                    continue;
                }

                if (slots[i].gameObject.transform.childCount > 1)
                {
                    itemSlots[i].consumableCount += 1;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                }
                else
                {
                    itemSlots[i].consumableCount += 1;
                    var newSword = Instantiate(Food[3], slots[i].transform.position, Quaternion.identity);
                    newSword.transform.parent = slots[i].transform;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                    allGrogFood.Add(newSword);
                    noStackables = false;
                }
                return;


            }


        }

        if (noStackables = true)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (itemSlots[i].used[i] == false)
                {

                    if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Food[3].name))
                    {
                        Debug.Log("spawn name: " + Food[3].name + "(Clone)");
                        Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                        Debug.Log("not here");
                        continue;
                    }

                    if (slots[i].gameObject.transform.childCount > 1)
                    {
                        itemSlots[i].consumableCount += 1;
                    }
                    else
                    {
                        itemSlots[i].consumableCount += 1;
                        var newSword = Instantiate(Food[3], slots[i].transform.position, Quaternion.identity);
                        newSword.transform.parent = slots[i].transform;
                        allGrogFood.Add(newSword);

                        return;
                    }

                    //slots[i].GetComponent<ItemSlot>().used[i] = true;
                    return;
                }
            }
            noStackables = false;
        }

    }

    public void MeatFood()
    {
        for (int i = 0; i < slots.Count; i++)
        {

            if (itemSlots[i].used[i] == false && itemSlots[i].consumableCount > 0)
            {

                if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Food[4].name))
                {
                    Debug.Log("spawn name: " + Food[4].name + "(Clone)");
                    Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                    Debug.Log("not here");
                    noStackables = true;
                    continue;
                }

                if (slots[i].gameObject.transform.childCount > 1)
                {
                    itemSlots[i].consumableCount += 1;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                }
                else
                {
                    itemSlots[i].consumableCount += 1;
                    var newSword = Instantiate(Food[4], slots[i].transform.position, Quaternion.identity);
                    newSword.transform.parent = slots[i].transform;
                    slots[i].transform.GetChild(1).GetComponent<DragDrop>().CheckConsumableCount();
                    allMeatFood.Add(newSword);
                    noStackables = false;
                }
                return;

            }

        }

        if (noStackables = true)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (itemSlots[i].used[i] == false)
                {

                    if (slots[i].transform.childCount > 1 && !slots[i].transform.GetChild(1).gameObject.name.Contains(Food[4].name))
                    {
                        Debug.Log("spawn name: " + Food[4].name + "(Clone)");
                        Debug.Log("child name: " + slots[i].transform.GetChild(1).gameObject.name);
                        Debug.Log("not here");
                        continue;
                    }

                    if (slots[i].gameObject.transform.childCount > 1)
                    {
                        itemSlots[i].consumableCount += 1;
                    }
                    else
                    {
                        itemSlots[i].consumableCount += 1;
                        var newSword = Instantiate(Food[4], slots[i].transform.position, Quaternion.identity);
                        newSword.transform.parent = slots[i].transform;
                        allMeatFood.Add(newSword);

                        return;
                    }

                    //slots[i].GetComponent<ItemSlot>().used[i] = true;
                    return;
                }
            }
            noStackables = false;
        }

    }

    // Food spawn code

    public void BackToLists()
    {
        for (int i = 0; i < subLists.Length; i++)
        {
            subLists[i].SetActive(false);
        }
        ListPanel.SetActive(true);
    }

}

