using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainData : MonoBehaviour
{
    public static MainData Instance;

    public static int gold;
    public static int day;
    public static int currentPlaceNum; // 0:��������, 1:����, 2:���, 3:�޺�
    public static int demoProgress;
    public static int bedStatus; // 0 : ���, 1 : ������ ��, 2 : ��� ��, 3: ����, 4: ȣ��

    public static List<string> ownedNPC;
    public static List<string> ownedItem;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
