using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diactivate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.SetActive(true);
    }
    public void onclick()
    {
        transform.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}