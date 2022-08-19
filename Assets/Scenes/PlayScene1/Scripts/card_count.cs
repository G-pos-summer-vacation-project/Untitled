using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum gar_enum{
    paper, plastic, metal, glass, food, cloth, other
}
public class card_count : MonoBehaviour
{
    public GameObject card_repos;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < 7; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = "0";
        }
        
    }
    public void card_num(int n)
    {
        int temp=0;
        int temp2 = -1;
        int temp3 = -1;
        switch (n)
        {
            case 0:
                temp = (int)gar_enum.plastic;
                break;
            case 1:
                temp = (int)gar_enum.plastic;
                break;
            case 2:
                temp = (int)gar_enum.paper;
                break;
            case 3:
                temp = (int)gar_enum.paper;
                break;
            case 4:
                temp = (int)gar_enum.paper;
                break;
            case 5:
                temp = (int)gar_enum.paper;
                break;
            case 6:
                temp = (int)gar_enum.metal;
                break;
            case 7:
                temp = (int)gar_enum.metal;
                break;
            case 8:
                temp = (int)gar_enum.metal;
                break;
            case 9:
                temp = (int)gar_enum.metal;
                break;
            case 10:
                temp = (int)gar_enum.glass;
                break;
            case 11:
                temp = (int)gar_enum.cloth;
                break;
            case 12:
                temp = (int)gar_enum.cloth;
                break;
            case 13:
                temp = (int)gar_enum.cloth;
                break;
            case 14:
                temp = (int)gar_enum.food;
                break;
            case 15:
                temp = (int)gar_enum.metal;
                temp2 = (int)gar_enum.glass;
                break;
            case 16:
                temp = (int)gar_enum.other;
                break;
            case 17:
                temp = (int)gar_enum.glass;
                temp2 = (int)gar_enum.metal;
                temp3 = (int)gar_enum.other;
                break;
            case 18:
                temp = (int)gar_enum.glass;
                temp2 = (int)gar_enum.metal;
                temp3 = (int)gar_enum.other;
                break;
            case 19:
                temp = (int)gar_enum.paper;
                break;
        }
        card_repos.GetComponent<card_repository>().gar_cards[temp]++;
        if (temp2 >= 0) card_repos.GetComponent<card_repository>().gar_cards[temp2]++;
        if (temp3 >= 0) card_repos.GetComponent<card_repository>().gar_cards[temp3]++;
        card_repos.GetComponent<card_repository>().append_card_seq(temp);
        if (temp2 >= 0) card_repos.GetComponent<card_repository>().append_card_seq(temp2);
        if (temp3 >= 0) card_repos.GetComponent<card_repository>().append_card_seq(temp3);
        gameObject.transform.GetChild(temp).GetComponent<TextMeshProUGUI>().text = card_repos.GetComponent<card_repository>().gar_cards[temp].ToString();
        if (temp2 >= 0) gameObject.transform.GetChild(temp).GetComponent<TextMeshProUGUI>().text = card_repos.GetComponent<card_repository>().gar_cards[temp2].ToString();
        if (temp3 >= 0) gameObject.transform.GetChild(temp).GetComponent<TextMeshProUGUI>().text = card_repos.GetComponent<card_repository>().gar_cards[temp3].ToString();

    }
    
}
