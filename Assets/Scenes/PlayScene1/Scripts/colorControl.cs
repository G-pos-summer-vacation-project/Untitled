using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorControl : MonoBehaviour
{
    public GameObject raycaster;
    int[] arr = new int[4];
    int[] ans = new int[4];
    int num = 0;
    Color c;
    bool isCorrect = true;
    // Start is called before the first frame update
    void Start()
    {
        generate_random_array();
    }
    public void button1()
    {
        ans[num++] = 0;
    }
    public void button2()
    {
        ans[num++] = 1;
    }
    public void button3()
    {
        ans[num++] = 2;
    }
    public void button4()
    {
        ans[num++] = 3;
    }
    void generate_random_array()
    {
        int random;
        for (int i = 0; i < 4; i++)
        {
            random = Random.Range(0, 4);
            arr[i] = random;
        }
        for(int i = 0; i < 4; i++)
        {
            switch (arr[i])
            {
                case 0:
                    c= Color.blue;
                    break;
                case 1:
                    c= Color.yellow;
                    break;
                case 2:
                    c = Color.green;
                    break;
                case 3:
                    c = Color.red;
                    break;
            }
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = c;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (num == 4)
        {
            for (int i= 0;i< 4; i++)
            {
                if (arr[i] != ans[i])
                {
                    raycaster.GetComponent<IsInCenter>().Incorrect();
                    isCorrect = false;
                }
            }
            if (isCorrect) raycaster.GetComponent<IsInCenter>().Correct();
            num = 0;
            isCorrect = true;
            generate_random_array();
        }
    }
}
