using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RC_center : MonoBehaviour
{
    public GameObject c_instance;
    bool upward_raycasthit = true;
    // Update is called once per frame
    public void no_upward_raycasthit()
    {
        upward_raycasthit = false;
    }
    void Update()
    {
        if (!Physics2D.Raycast(transform.position, transform.right, 100) && !upward_raycasthit)
        {
            c_instance.GetComponent<card_instantiate>().Next_Scene();
        }
    }
}
