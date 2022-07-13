using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInCenter : MonoBehaviour
{
    RaycastHit2D rh;
    public GameObject instantiater;
    public GameObject NextGarbage;
    public GameObject cardControl;
    public ParticleSystem ps;
    int time = 0;
    int regen_time = 1000;
    // Start is called before the first frame update
    // Update is called once per frame
    public void Incorrect()
    {
        if (rh = Physics2D.Raycast(transform.position, transform.right, 100)) rh.transform.GetComponent<generic_garbage_script>().SendMessage("destroy_self");
        instantiater.GetComponent<garbageInstance>().destroyed();
    }
    public void Correct()
    {
        if (rh = Physics2D.Raycast(transform.position, transform.right, 100))
        {
            cardControl.GetComponent<card_count>().card_num(rh.transform.GetComponent<generic_garbage_script>().gar_sequence);
            rh.transform.GetComponent<generic_garbage_script>().SendMessage("destroy_self");
        }
        instantiater.GetComponent<garbageInstance>().destroyed();
        Instantiate(ps, new Vector3(0, 0, 0), new Quaternion());
    }
    void Update()
    {
        
        if(rh=Physics2D.Raycast(transform.position, transform.right, 100))
        {
            NextGarbage.GetComponent<IsCenterEmpty>().SendMessage("stopNextGarbage");
            rh.transform.GetComponent<generic_garbage_script>().SendMessage("isCenterEmpty", false);
        }
        else
        {
            NextGarbage.GetComponent<IsCenterEmpty>().SendMessage("sendNextGarbage");
        }
        if (time == regen_time)
        {
            
            instantiater.GetComponent<garbageInstance>().Instantiate_garbage();
            
        }
        time++;
        if (time > regen_time) time = 0;
    }
}
