using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class card_instantiate : MonoBehaviour
{
    public Transform init_position;
    public GameObject cards;
    int repos_seq = 1;
    int card_num;
    // Start is called before the first frame update
    void Start()
    {
        MainData.point = 0;
        card_num = card_repository.cc_instance.get_card_num();
        card_repository.cc_instance.reset_seq();
        card_repository.cc_instance.reset_all();
        instanciate_card();
    }
    public void instanciate_card()
    {
        for(int i = 0; i < card_num; i++)
        {
            int sequence = card_repository.cc_instance.card_seq[i];
            Instantiate(cards.transform.GetChild(sequence).gameObject, init_position.position, init_position.rotation);
        }
    }
    public void recive_col(int n)
    {
        if (n - 1 == card_repository.cc_instance.card_seq[repos_seq]/2)
        {
            int temp = card_repository.cc_instance.card_seq[card_num- repos_seq];
            switch (temp)
            {
                case 0:
                    MainData.gold += 160;
                    MainData.point += 1500;
                    break;
                case 1:
                    MainData.gold += 150;
                    MainData.point += 1400;
                    break;
                case 2:
                    MainData.gold += 200;
                    MainData.point += 2000;
                    break;
                case 3:
                    MainData.gold += 170;
                    MainData.point += 1600;
                    break;
                case 4:
                    MainData.gold += 140;
                    MainData.point += 1300;
                    break;
                case 5:
                    MainData.gold += 140;
                    MainData.point += 1200;
                    break;
                case 6:
                    MainData.gold += 180;
                    MainData.point += 1300;
                    break;
                case 7:
                    MainData.gold += 140;
                    MainData.point += 1800;
                    break;
            }
        }
        if (repos_seq == card_num) SceneManager.LoadScene("ResultScene");
        repos_seq++;
        
    }
}
