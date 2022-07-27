using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycaster_up : MonoBehaviour
{
    public GameObject RC_center;
    // Update is called once per frame
    void Update()
    {
        if (!Physics2D.Raycast(transform.position, transform.up, 100))
        {
            RC_center.GetComponent<RC_center>().no_upward_raycasthit();
        }
    }
}
