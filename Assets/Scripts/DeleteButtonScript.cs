using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteButtonScript : MonoBehaviour
{

    public bool longClick = false;
    private bool longEnough = false;
    private ButtonManager BMinstance;

    private int checkInt = 0;

    // Start is called before the first frame update
    void Start()
    {
        BMinstance = ButtonManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && longClick && longEnough)
        {
            StartCoroutine(LongClick());
            longEnough = false;
        }
    }


    public void EventTriggerEventDown()
    {
        var i = 0;
        if (Input.GetMouseButtonDown(0))
        {
            i += 1;
            
            longClick = true;
            longEnough = true;
        }

        
    }

    public void EventTriggerEventUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            longEnough = false;
            longClick = false;
            Debug.Log("lonClickUP: " + longClick);
            StopCoroutine(LongClick());
        }

    }

    public IEnumerator LongClick()
    {
        yield return new WaitForSeconds(1f);

        if (!longClick)
        {
            longEnough = false;
            StopCoroutine(LongClick());
        }

        while (longClick)
        {
            checkInt += 1;
            Debug.Log("longClick = " + longClick);
            Debug.Log("checkInt = " +  checkInt);
            yield return new WaitForSeconds(0.2f);
            BMinstance.DeleteSelectedItem();
            
        }

        if (!longClick)
        {
            longEnough = false;
            StopCoroutine(LongClick());
        }
    }
}
