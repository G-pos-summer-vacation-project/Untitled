using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class card_repository : MonoBehaviour
{
    public static card_repository cc_instance;
    public int[] gar_cards = new int[7];
    public int[] card_seq = new int[40];
    static int seq = 0;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (cc_instance == null)
        {
            cc_instance = this;
        }
        else if (cc_instance != this) Destroy(gameObject);
        for (int i = 0; i < 8; i++)
        {
            gar_cards[i] = 0;
        }
    }

    public int get_card_num()
    {
        int sum = 0;
        for(int i = 0; i < 8; i++)
        {
            sum += gar_cards[i];
        }
        return sum;
    }
    public void append_card_seq(int n)
    {
        card_seq[seq] = n;
        seq++;
    }
    public void reset_seq()
    {
        seq = 0;
    }
    public void reset_all()
    {
        for(int i = 0; i < 8; i++)
        {
            gar_cards[i] = 0;
        }
    }
    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "ResultScene") Destroy(gameObject);
    }
}
