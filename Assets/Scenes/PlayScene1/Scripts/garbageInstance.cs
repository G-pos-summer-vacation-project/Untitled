using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class garbageInstance : MonoBehaviour
{
    public GameObject Garbage;
    public RectTransform init_position;
    int garbage_type_num = 20;
    
    private int instance_num = 1;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Garbage.transform.GetChild(0).gameObject, init_position.position, init_position.rotation);
    }
    public void Instantiate_garbage()
    { 
        if (instance_num <= 5)
        {
            int random = Random.Range(0, garbage_type_num);
            GameObject go;
            go= Instantiate(Garbage.transform.GetChild(random).gameObject, init_position.position, init_position.rotation);
            go.GetComponent<generic_garbage_script>().gar_sequence = random;
            instance_num++;
            //Debug.Log(instance_num);
            //Debug.Log(garbage_num);
        }
        
    }
    public void destroyed()
    {
        if (instance_num > 0) instance_num--;
        //Debug.Log(instance_num);
    }
    public void loadnextscene()
    {
        SceneManager.LoadScene("PlayScene2");
    }
    // Update is called once per frame

}