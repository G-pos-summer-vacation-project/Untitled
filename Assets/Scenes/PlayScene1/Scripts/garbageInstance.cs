using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageInstance : MonoBehaviour
{
    public GameObject Garbage;
    public RectTransform init_position;
    int garbage_type_num = 10;
    int garbage_num = 10;
    
    int instance_num = 1;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Garbage.transform.GetChild(0).gameObject, init_position.position, init_position.rotation);
    }
    public void Instantiate_garbage()
    { 
        if (instance_num <= 5 && garbage_num >= 0)
        {
            int random = Random.Range(0, garbage_type_num);
            GameObject go;
            go= Instantiate(Garbage.transform.GetChild(random).gameObject, init_position.position, init_position.rotation);
            go.GetComponent<generic_garbage_script>().gar_sequence = random;
            instance_num++;
            garbage_num--;
        }
    }
    public void destroyed()
    {
        instance_num--;
    }
    // Update is called once per frame
    void Update()
    {

    }

}