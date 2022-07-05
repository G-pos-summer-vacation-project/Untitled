using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame_Panel_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.SetActive(false);
    }
    public void setNewgameActive()
    {
        transform.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
