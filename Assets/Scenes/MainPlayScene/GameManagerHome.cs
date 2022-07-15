using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerHome : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI dayText;

    public List<GameObject> backGrounds;

    public int gold;
    public int day;
    public int currentPlaceNum;

    void Awake()
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
        setBackGround(currentPlaceNum);
    }

    void Update()
    {

    }

    void variableInitalization()
    {
        gold = MainData.gold;
        day = MainData.day;
        currentPlaceNum = MainData.currentPlaceNum;
    }

    void setBackGround(int placeNum) // show only one intended background
    {
        for (int i = 0; i < 4; i++)
            if(backGrounds[i].activeSelf == true)
                backGrounds[i].SetActive(false);
        backGrounds[placeNum].SetActive(true);
    }
}
