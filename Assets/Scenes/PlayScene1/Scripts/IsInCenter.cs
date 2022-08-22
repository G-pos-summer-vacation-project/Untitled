using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class IsInCenter : MonoBehaviour
{
    RaycastHit2D rh;
    public GameObject instantiater;
    public GameObject NextGarbage;
    public GameObject cardControl;
    public ParticleSystem ps;
    public GameObject pauseWindow;
    public AudioSource Audio;

    public float regen_time = 1;
    // Start is called before the first frame update
    // Update is called once per frame
    public void Incorrect()
    {
        if (rh = Physics2D.Raycast(transform.position, transform.right, 100)) rh.transform.GetComponent<generic_garbage_script>().destroy_self();
        instantiater.GetComponent<garbageInstance>().destroyed();
    }
    public void Correct()
    {
        if (rh = Physics2D.Raycast(transform.position, transform.right, 100))
        {
            cardControl.GetComponent<card_count>().card_num(rh.transform.GetComponent<generic_garbage_script>().gar_sequence);
            rh.transform.GetComponent<generic_garbage_script>().destroy_self();
        }
        instantiater.GetComponent<garbageInstance>().destroyed();
        Instantiate(ps, new Vector3(0, 0, 0), new Quaternion());
        Audio.Play();
    }
    public bool RC_isinCenter()
    {
        return Physics2D.Raycast(transform.position, transform.right, 100);
    }
    void Update()
    {
        
        if(rh=Physics2D.Raycast(transform.position, transform.right, 100))
        {
            NextGarbage.GetComponent<IsCenterEmpty>().stopNextGarbage();
            rh.transform.GetComponent<generic_garbage_script>().isCenterEmpty(false);
        }
        else
        {
            NextGarbage.GetComponent<IsCenterEmpty>().sendNextGarbage();
        }
        if (!pauseWindow.activeSelf)
            regen_time -= Time.deltaTime;
        if (0 > regen_time)
        {
            regen_time = 1;
            instantiater.GetComponent<garbageInstance>().Instantiate_garbage();
        }
    }
}
