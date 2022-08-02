using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public GameObject nextSceneLoader;
    public GameObject pauseWindow;
    float time = 10;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseWindow.activeSelf != true)
        {
            time -= Time.deltaTime;
        }
        gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:N1}", time);
        if (time <= 0)
        {
            nextSceneLoader.GetComponent<garbageInstance>().loadnextscene();
        }
    }
}
