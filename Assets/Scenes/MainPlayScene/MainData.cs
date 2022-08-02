using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainData : MonoBehaviour
{
    public static MainData Instance;

    public static int gold;
    public static int earnedGold;
    public static int day;
    public static int currentPlaceNum; // 0:¾²·¹±âÀå, 1:½ÃÀ§, 2:Àíºû, 3:´Şºû
    public static int demoProgress;
    public static int bedStatus; // 0 : ³ë¼÷, 1 : Àú·ÅÇÑ ¹æ, 2 : ºñ½Ñ ¹æ, 3: ¸ğÅÚ, 4: È£ÅÚ
    public static int point;
    public static int totalPoint;

    public static List<string> ownedNPC = new List<string>();
    public static List<string> ownedItem = new List<string>();

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
}
