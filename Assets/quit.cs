using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void onquit()
    {
        Debug.Log("activate");
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
