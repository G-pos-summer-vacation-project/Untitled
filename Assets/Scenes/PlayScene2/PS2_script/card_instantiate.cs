using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class card_instantiate : MonoBehaviour
{
    public Transform init_position;
    public GameObject cards;
    //int repos_seq = 1;
    int card_num;
    int init_sort_layer = 3;
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
            GameObject ins_gar= Instantiate(cards.transform.GetChild(sequence).gameObject, init_position.position, init_position.rotation);
            ins_gar.GetComponent<generic_card>().get_gar_seq(sequence);
            ins_gar.GetComponent<SpriteRenderer>().sortingOrder = init_sort_layer++;
        }
    }
    public void Next_Scene()
    {
        if(MainData.point == 0)
            SceneManager.LoadScene("GameOverScene");
        else
            SceneManager.LoadScene("ResultScene");
    }
}
