using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class PauseManager : MonoBehaviour
{
    

    void Start()
    {
        if(this.gameObject.activeSelf == true)
            this.gameObject.SetActive(false);

    }

    private void Update()
    {
        
    }

    public void Save()
    {
        PlayerPrefs.SetInt("GOLD", MainData.gold);
        PlayerPrefs.SetInt("DAY", MainData.day);
        PlayerPrefs.SetInt("PLACE", MainData.currentPlaceNum);
        PlayerPrefs.SetInt("DEMO", MainData.demoProgress);
        PlayerPrefs.SetInt("BED", MainData.bedStatus);
        PlayerPrefs.SetInt("POINT", MainData.totalPoint);
        PlayerPrefs.SetString("NPC", ListToString(MainData.ownedNPC));
        PlayerPrefs.SetString("ITEM", ListToString(MainData.ownedItem));
        PlayerPrefs.Save();
        //Debug.Log("Saved");
    }

    public void SaveAndQuit()
    {
        Save();
        Application.Quit();
    }

    public void Load()
    {
        if (!PlayerPrefs.HasKey("GOLD"))
            return;

        MainData.gold = PlayerPrefs.GetInt("GOLD");
        MainData.day = PlayerPrefs.GetInt("DAY");
        MainData.currentPlaceNum = PlayerPrefs.GetInt("PLACE");
        MainData.demoProgress = PlayerPrefs.GetInt("DEMO");
        MainData.bedStatus = PlayerPrefs.GetInt("BED");
        MainData.totalPoint = PlayerPrefs.GetInt("POINT");
        MainData.ownedNPC = StringToList(PlayerPrefs.GetString("NPC"));
        MainData.ownedItem = StringToList(PlayerPrefs.GetString("ITEM"));
        //Debug.Log("loaded.");
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("MainHomeScene");
    }

    private string ListToString(List<string> vs)
    {
        return String.Join("/", vs.ToArray());
    }

    private List<string> StringToList(string s)
    {
        return s.Split("/").ToList();
    }

    public void Reset()
    {
        MainData.gold = 0;
        MainData.day = 0;
        MainData.currentPlaceNum = 0;
        MainData.demoProgress = 0;
        MainData.bedStatus = 0;
        MainData.totalPoint = 0;
        MainData.ownedNPC = new List<string>();
        MainData.ownedItem = new List<string>();
        Save();
        //Debug.Log("Reset");
    }



    
}
