using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class card_count : MonoBehaviour
{
    public static card_count instance;
    int[] gar_card= new int[8];
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        for (int i = 0; i < 8; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = "0";
            gar_card[i] = 0;
        }
        
    }
    public void card_num(int n)
    {
        int temp=0;
        switch (n)
        {
            case 0:
                temp = 1;
                break;
            case 1:
                temp = 0;
                break;
            case 2:
                temp = 0;
                break;
            case 3:
                temp = 2;
                break;
            case 4:
                temp = 2;
                break;
            case 5:
                temp = 3;
                break;
            case 6:
                temp = 0;
                break;
            case 7:
                temp = 6;
                break;
            case 8:
                temp = 7;
                break;
            case 9:
                temp = 5;
                break;
        }
        gar_card[temp]++;
        gameObject.transform.GetChild(temp).GetComponent<TextMeshProUGUI>().text = gar_card[temp].ToString();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
