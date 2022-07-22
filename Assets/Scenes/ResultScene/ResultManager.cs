using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI blinkText;

    int time;
    int regen;
    bool clicked;
    // Start is called before the first frame update
    void Start()
    {
        titleText.text = "";
        goldText.text = "";
        pointText.text = "";
        blinkText.text = "";
        time = 0;
        regen = 20;
        clicked = false;
        MainData.gold += MainData.earnedGold;
        MainData.totalPoint += MainData.point;
        MainData.earnedGold = 0;
        MainData.point = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (time / regen)
        {
            case 0:
                break;
            case 1:
                titleText.text = "RESULT";
                break;
            case 2:
                goldText.text = "GOLD ";
                break;
            case 3:
                goldText.text = "GOLD + " + MainData.earnedGold;
                break;
            case 4:
                pointText.text = "POINT ";
                break;
            case 5:
                pointText.text = "POINT + " + MainData.point;
                break;
            default:
                if(clicked)
                {
                    SceneManager.LoadScene("MainPlayScene");
                }
                if(time/regen % 2 == 0)
                {
                    blinkText.text = "Touch to return";
                }
                else
                {
                    blinkText.text = "";
                }
                break;
        }
        time++;
        clicked = false;
    }

    public void OnClicked()
    {
        clicked = true;
    }
}
