using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceManager : MonoBehaviour
{
    public void textCanvasClicked()
    {
        EventManager.button = 1;
    }

    public void choicedOne()
    {
        EventManager.choice = 1;
    }

    public void choicedTwo()
    {
        EventManager.choice = 2;
    }

    public void choicedThree()
    {
        EventManager.choice = 3;
    }

    public void goToPlay()
    {
        SceneManager.LoadScene("PlayScene1");
    }
}
