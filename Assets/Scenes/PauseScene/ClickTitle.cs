using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickTitle : MonoBehaviour
{
   public void SceneChange()
    {
        SceneManager.LoadScene("Title_sample");
    }
}
