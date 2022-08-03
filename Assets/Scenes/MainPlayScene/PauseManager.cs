using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    public AudioMixer masterMixer;
    public float BGMsound;
    public float SFXsound;
    public GameObject BGMmute;
    public GameObject BGMmuted;
    public GameObject SFXmute;
    public GameObject SFXmuted;
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.activeSelf == true)
            this.gameObject.SetActive(false);

        Scene scene = SceneManager.GetActiveScene();
        masterMixer.SetFloat("BGM", BGMsound);
        masterMixer.SetFloat("SFX", BGMsound);
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

    public void ToggleBGMVolume()
    {
        float tmp;
        masterMixer.GetFloat("BGM", out tmp);
        if(tmp == BGMsound)
        {
            masterMixer.SetFloat("BGM", -80f);
        }
        else
        {
            masterMixer.SetFloat("BGM", BGMsound);
        }
    }

    public void ToggleSFXVolume()
    {
        float tmp;
        masterMixer.GetFloat("SFX", out tmp);
        if (tmp == SFXsound)
        {
            masterMixer.SetFloat("SFX", -80f);
        }
        else
        {
            masterMixer.SetFloat("SFX", SFXsound);
        }
    }

    public void SetVolumeToggle()
    {
        float tmp;
        masterMixer.GetFloat("BGM", out tmp);
        if(tmp == BGMsound)
        {
            if(!BGMmute.activeSelf)
                BGMmute.SetActive(true);
            if(BGMmuted.activeSelf)
                BGMmuted.SetActive(false);
        }
        else
        {
            if (BGMmute.activeSelf)
                BGMmute.SetActive(false);
            if (!BGMmuted.activeSelf)
                BGMmuted.SetActive(true);
        }
        masterMixer.GetFloat("SFX", out tmp);
        if(tmp == SFXsound)
        {
            if (!SFXmute.activeSelf)
                SFXmute.SetActive(true);
            if (SFXmuted.activeSelf)
                SFXmuted.SetActive(false);
        }
        else
        {
            if (SFXmute.activeSelf)
                SFXmute.SetActive(false);
            if (!SFXmuted.activeSelf)
                SFXmuted.SetActive(true);
        }
    }
}
