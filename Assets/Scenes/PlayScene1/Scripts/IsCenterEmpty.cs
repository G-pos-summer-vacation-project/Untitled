using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCenterEmpty : MonoBehaviour
{
    RaycastHit2D rh;
    // Start is called before the first frame update
    public void sendNextGarbage()
    {
        if (rh = Physics2D.Raycast(transform.position, transform.right, 100))
        {
            rh.transform.GetComponent<generic_garbage_script>().SendMessage("isCenterEmpty", true);
        }
    }
    public void stopNextGarbage()
    {
        if (rh = Physics2D.Raycast(transform.position, transform.right, 100))
        {
            rh.transform.GetComponent<generic_garbage_script>().SendMessage("isCenterEmpty", false);
        }
    }
    // Update is called once per frame
    
}
