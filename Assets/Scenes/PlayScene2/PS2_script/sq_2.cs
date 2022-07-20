using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sq_2 : MonoBehaviour
{
    public GameObject card_instance;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        card_instance.GetComponent<card_instantiate>().recive_col(2);
    }
}
