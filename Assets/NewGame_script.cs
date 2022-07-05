using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame_script : MonoBehaviour
{
    public NewGame_Panel_script panel_script;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Active");
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void NewGameActive()
    {
        panel_script.setNewgameActive();
    }
}
