using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_center : MonoBehaviour
{
    public GameObject c_instance;
    // Update is called once per frame
    void Update()
    {
        if (!Physics2D.Raycast(transform.position, transform.right, 100))
        {
            c_instance.GetComponent<card_instantiate>().Next_Scene();
        }
    }
}
