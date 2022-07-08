using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerHome : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI eventList;

    /*
    public const string[] NPC_LIST = {
        "부랑자 아이"
    };
    public const string[] ITEM_LIST = {
        "장치1"
    };

    public static readonly string[] EVENT_LIST = {
        "wanderer kid coming",
        "loan shark coming",
        "eating"
    };

    
    public static readonly string[] EVENT_LIST = {
        "wanderer kid coming",
        "loan shark coming",
        "eating"
    }

    */

    
    public int gold;
    public int day;
    public int currentPlaceNum; // 0:쓰레기장, 1:시위, 2:잿빛, 3:달빛
    public int progress; // 쓰레기가 얼마나 치워졌는지, 0~100 사이의 값을 가짐

    /*
    public static readonly EventInfo[4, 10] EVENT_LIST =
    {
        {
            EventInfo("loan shark", 0.5, 0),
            EventInfo("wanderer kid", 0.2, 0),
            EventInfo("drunk", 0.2, 0) 
        }
    };
    */

    public List<EventInfo> upComingEventList;
    public List<string> ownedNPC;
    public List<string> ownedItem;

    public List<GameObject> backGrounds;

    void Start()
    {
        // variable initalization
        variableInitalization();

        // find backgrounds
        backGrounds.Add(GameObject.Find("Dump"));
        backGrounds.Add(GameObject.Find("Demo"));
        backGrounds.Add(GameObject.Find("Gray"));
        backGrounds.Add(GameObject.Find("Moon"));

        // flow on screen
        goldText.text = gold.ToString() + " GOLD";
        dayText.text = "DAY " + day.ToString();
        eventList.text = "";
        setBackGround(currentPlaceNum);
    }

    void Update()
    {

    }

    void variableInitalization()
    {
        // declaring eventinfo
        /*
        events.Add(new EventInfo("loan shark", 0.5, 0));
        events.Add(new EventInfo("wanderer kid", 0.2, 0));
        events.Add(new EventInfo("drunk", 0.2, 0));
        
        switch(currentPlaceNum)
        {
            case 0:

                break;
            case 1:

                break;
            case 2:

                break;
            case 3:
               
                break;
        }
        */
         
        gold = 5555;
        day = 23;
        //upComingEventList.Add("");
        currentPlaceNum = 2;
    }

    void setBackGround(int placeNum) // show only one intended background
    {
        for (int i = 0; i < 4; i++)
            if(backGrounds[i].activeSelf == true)
                backGrounds[i].SetActive(false);
        backGrounds[placeNum].SetActive(true);
    }
}
