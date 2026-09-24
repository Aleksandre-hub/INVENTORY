using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Text statArmor;
    [SerializeField] private Text statHP;
    [SerializeField] private Text statMP;
    [SerializeField] private Text statStamina;
    [SerializeField] private Text statMP_bonus;

    [SerializeField] private GameObject hedgearSlot;
    [SerializeField] private GameObject armorSlot;
    [SerializeField] private GameObject shieldSlot;
    [SerializeField] private GameObject lefRingSlot;
    [SerializeField] private GameObject rightRingSlot;

    [SerializeField] private GameObject selectedItemPlace;
    [SerializeField] private GameObject selectedItemDescriptionPlace;

    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject manaBar;
    [SerializeField] private GameObject staminaBar;

    [SerializeField] private Image SelectedItemPlaceImage;
    [SerializeField] private Text SelectedItemDescriptionPlaceText;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Image manaBarImage;
    [SerializeField] private Image staminaBarImage;

    private Image lastSelectedGameObjectImage;
    private DragDrop lastSelectedGameObjectScript;

    public int position;
    public string name;

    public float armor = 100;
    public float manaCostReduction = 100;

    private int stopCoroutine = 0;
    private bool CR_running = false;

    public Canvas secondaryCanvas;

    public float bodyArmor = 0;
    public float helmetArmor = 0;
    public float shieldArmor = 0;

    public float lefRingMP = 0;
    public float rightRingMP = 0;

    public List<GameObject> slotExceptionList = new List<GameObject>();

    public static GameManager Instance;
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

    }

    // Update is called once per frame
    void Update()
    {

        armor = 100 + bodyArmor + helmetArmor + shieldArmor;
        manaCostReduction = 100 + lefRingMP + rightRingMP;

        statMP_bonus.text = (manaCostReduction - 100).ToString();
        statArmor.text = (armor - 100).ToString();
        statHP.text = (healthBarImage.fillAmount * 100).ToString();
        statMP.text = (manaBarImage.fillAmount * 100).ToString();
        statStamina.text = (staminaBarImage.fillAmount * 100).ToString();
    }

    

    public void ShowSelectedItem(Sprite selectedItemSprite) {
        selectedItemPlace.SetActive(true);
        SelectedItemPlaceImage.sprite = selectedItemSprite;
    }

    public void ShowSelectedItemDescription(Text selectedItemDescription) {
        SelectedItemDescriptionPlaceText.text = selectedItemDescription.text;
    }

    public void UseItemMeleeBow(GameObject lastSelectedItem) {
        healthBarImage.fillAmount -= lastSelectedItem.gameObject.GetComponent<DragDrop>().damage / armor;

        Debug.Log("Health: " + healthBarImage.fillAmount * 100);
    }

    public void EquipArmor(GameObject lastSelectedItem) {
        //armor = 100 + lastSelectedItem.gameObject.GetComponent<DragDrop>().armor;
        Debug.Log("armor: " + armor);
    }

    public void Consume(GameObject lastSelectedItem) {
        lastSelectedGameObjectScript = lastSelectedItem.gameObject.GetComponent<DragDrop>();

        healthBarImage.fillAmount += lastSelectedGameObjectScript.hp_bonus / 100;
        manaBarImage.fillAmount += lastSelectedGameObjectScript.mp_bonus / 100;
        staminaBarImage.fillAmount += lastSelectedGameObjectScript.stamina_bonus / 100;
    }

    public void UseStaff(GameObject lastSelectedItem) {
        lastSelectedGameObjectScript = lastSelectedItem.gameObject.GetComponent<DragDrop>();
        Debug.Log("MP cost: " + lastSelectedGameObjectScript.mp_cost);
        Debug.Log("manaCostReduction bonus = " + manaCostReduction);
        if (manaBarImage.fillAmount >= lastSelectedGameObjectScript.mp_cost / manaCostReduction && !CR_running) {

            healthBarImage.fillAmount -= lastSelectedGameObjectScript.damage / manaCostReduction;

            manaBarImage.fillAmount -= lastSelectedGameObjectScript.mp_cost / manaCostReduction;

            staminaBarImage.fillAmount -= lastSelectedGameObjectScript.stamina_damage / manaCostReduction;

            healthBarImage.fillAmount += lastSelectedGameObjectScript.hp_bonus / manaCostReduction;

            if (lastSelectedGameObjectScript.damage_time > 0 && CR_running == false) {
                StartCoroutine(DamageTime(lastSelectedGameObjectScript.damage_time, lastSelectedItem));
            }
        }
        
    }

    public IEnumerator DamageTime(float damage_time, GameObject lastSelectedItem) {
        lastSelectedGameObjectScript = lastSelectedItem.gameObject.GetComponent<DragDrop>();

        CR_running = true;
        while (stopCoroutine <= damage_time) {
            yield return new WaitForSeconds(1);

            healthBarImage.fillAmount -= lastSelectedGameObjectScript.damage /100;
            staminaBarImage.fillAmount -= lastSelectedGameObjectScript.stamina_damage / 100;
            stopCoroutine += 1;

            Debug.Log("stopCourutineTime: " + stopCoroutine);
            Debug.Log("damage_time: " + damage_time);

        }

        if (stopCoroutine >= damage_time) {
            Debug.Log("stop coroutine script");
            stopCoroutine = 0;
            CR_running = false;
            StopCoroutine(DamageTime(damage_time, lastSelectedItem));
        }
        
    }

   

}
