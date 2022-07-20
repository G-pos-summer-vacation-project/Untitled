using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card_instantiate : MonoBehaviour
{
    public Transform init_position;
    public GameObject cards;
    int repos_seq = 1;
    // Start is called before the first frame update
    void Start()
    {
        card_repository.cc_instance.reset_seq();
        instanciate_card();
    }
    public void instanciate_card()
    {
        for(int i = 0; i < card_repository.cc_instance.get_card_num(); i++)
        {
            int sequence = card_repository.cc_instance.card_seq[i];
            Instantiate(cards.transform.GetChild(sequence).gameObject, init_position.position, init_position.rotation);
        }
    }
    public void recive_col(int n)
    {
        if (n - 1 == card_repository.cc_instance.card_seq[repos_seq]/2)
        {
            int temp = card_repository.cc_instance.card_seq[card_repository.cc_instance.get_card_num()- repos_seq];
            switch (temp)
            {
                case 0:
                    MainData.gold += 160;
                    break;
                case 1:
                    MainData.gold += 150;
                    break;
                case 2:
                    MainData.gold += 200;
                    break;
                case 3:
                    MainData.gold += 170;
                    break;
                case 4:
                    MainData.gold += 140;
                    break;
                case 5:
                    MainData.gold += 140;
                    break;
                case 6:
                    MainData.gold += 180;
                    break;
                case 7:
                    MainData.gold += 140;
                    break;
            }
        }
        repos_seq++;
    }
}
