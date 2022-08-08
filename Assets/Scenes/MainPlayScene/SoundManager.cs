using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer masterMixer;
    public float BGMsound;
    public float SFXsound;
    public GameObject BGMmute;
    public GameObject BGMmuted;
    public GameObject SFXmute;
    public GameObject SFXmuted;
    public AudioSource audioSource;
    public bool isBGMmuted;
    public bool isSFXmuted;
    public bool isPausing;
    public bool isChanged;

    bool[] fadeOut = new bool[4];
    public float nowSound;
    float fadeOutSpeed;

    public float nowB;
    public float nowS;
    public float nowP;

    // Start is called before the first frame update
    void Start()
    {
        isPausing = false;
        isChanged = false;
        fadeOut[0] = false;
        fadeOut[1] = false;
        fadeOut[2] = false;
        fadeOut[3] = false;

        fadeOutSpeed = 240f;

        float tmp;

        masterMixer.GetFloat("BGM", out tmp);
        if (tmp == BGMsound)
        {
            isBGMmuted = false;
        }
        else
        {
            isBGMmuted = true;
        }

        masterMixer.GetFloat("SFX", out tmp);
        if (tmp == SFXsound)
        {
            isSFXmuted = false;
        }
        else
        {
            isSFXmuted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        masterMixer.GetFloat("BGM", out nowB);
        masterMixer.GetFloat("SFX", out nowS);
        masterMixer.GetFloat("PAUSE", out nowP);
        if (fadeOut[0])
        {
            if (nowSound < -80f)
            {
                fadeOut[0] = false;
                masterMixer.SetFloat("BGM", -80f);
                masterMixer.SetFloat("PAUSE", BGMsound);
            }
            else
            {
                nowSound -= Time.deltaTime * fadeOutSpeed;
                masterMixer.SetFloat("BGM", nowSound);
                masterMixer.SetFloat("PAUSE", -80 - nowSound);
            }
        }

        if (fadeOut[2])
        {
            if (nowSound < -80f)
            {
                fadeOut[2] = false;
                masterMixer.SetFloat("PAUSE", -80f);
                masterMixer.SetFloat("BGM", BGMsound);
            }
            else
            {
                nowSound -= Time.deltaTime * fadeOutSpeed;
                masterMixer.SetFloat("PAUSE", nowSound);
                masterMixer.SetFloat("BGM", -80 - nowSound);
            }
        }
    }


    public void ToggleBGMVolume()
    {
        if (!isBGMmuted)
        {
            //masterMixer.SetFloat("BGM", -80f);
            masterMixer.SetFloat("PAUSE", -80f);
            isBGMmuted = true;
        }
        else
        {
            //masterMixer.SetFloat("BGM", BGMsound);
            masterMixer.SetFloat("PAUSE", BGMsound);
            isBGMmuted = false;
        }
    }


    public void ToggleSFXVolume()
    {
        if (!isSFXmuted)
        {
            masterMixer.SetFloat("SFX", -80f);
            isSFXmuted = true;
        }
        else
        {
            masterMixer.SetFloat("SFX", SFXsound);
            isSFXmuted = false;
        }
    }

    public void SetVolumeToggle()
    {
        if (!isBGMmuted)
        {
            if (!BGMmute.activeSelf)
                BGMmute.SetActive(true);
            if (BGMmuted.activeSelf)
                BGMmuted.SetActive(false);
        }
        else
        {
            if (BGMmute.activeSelf)
                BGMmute.SetActive(false);
            if (!BGMmuted.activeSelf)
                BGMmuted.SetActive(true);
        }
        if (!isSFXmuted)
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

    public void pausing()
    {
        masterMixer.SetFloat("PAUSE", -80f);
        audioSource.Play();
        if (!isBGMmuted)
        {
            nowSound = BGMsound;
            fadeOut[0] = true;
        }
        isPausing = true;
    }

    public void pauseCanceling()
    {
        isPausing = false;
        if (!isBGMmuted)
        {
            nowSound = BGMsound;
            fadeOut[2] = true;
        }
        else
        {
            audioSource.Stop();
        }
    }
}
