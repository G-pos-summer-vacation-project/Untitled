using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : MonoBehaviour
{
    readonly int[] MONEY_TO_GO = {20000, 80000, 200000}; // money to go demo
    readonly int PENTHOUSE = 3000000; // money to buy penthouse
    readonly int END_DAY = 100;
    double[,] EVENT_POSSIBILITY = new double[4, 4] { { 1.0, 1.0, 1.0, 0 }, { 1.0, 1.0, 0, 0 }, { 1.0, 1.0, 1.0, 1.0 }, { 1.0, 0, 0, 0 } };
    readonly double ORIGINAL_POS22 = 1.0;
    readonly double ORIGINAL_POS23 = 1.0;

    public static int button;
    public static int choice;
    public bool isChoicing;
    bool isFinished;

    public int gold;
    public int day;
    public int currentPlaceNum; // 0:¾²·¹±âÀå, 1:½ÃÀ§, 2:Àíºû, 3:´Þºû.
    public int demoProgress;
    public int bedStatus;

    public TextMeshProUGUI eventText;
    public TextMeshProUGUI c21, c22, c31, c32, c33;

    public List<string> ownedNPC = new List<string>();
    public List<string> ownedItem;

    public GameObject goToPlay;
    public GameObject blur;
    public List<GameObject> backGrounds;
    public List<GameObject> buttons;
    public Dictionary<string, GameObject> images = new Dictionary<string, GameObject>();
    public List<string> upComingEvents;
    public Dictionary<int, EventInfo> eventHelper = new Dictionary<int, EventInfo>();

    public int eventID;

    void Awake()
    {
        baseVarInitalization();
        setBackGround(currentPlaceNum);
        selectEvent();
    }

    void Start()
    {
        eventID = 0;
        foreach (var eventName in upComingEvents)
        {
            if(eventID != 0)
            {
                eventHelper.Add(eventID, new EventInfo("...", "none", "none", eventID + 1));
                eventID++;
            }

            var lines = getLines(eventName);

            for(int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                string[] words = line.Split(' ');

                addEventInfo(words);
            }
            eventID += lines.Count;
        }

        eventID = 0;
        isChoicing = false;
        button = 0;
        choice = 0;
    }

    void Update()
    {
        if(eventHelper.ContainsKey(eventID))
        {
            // Debug.Log(eventID);
            if(isChoicing)
            {
                if(choice != 0)
                {
                    eventID = eventHelper[eventID].path[choice - 1];
                    nextEventManager();
                    isChoicing = false;
                    nextEventManager();

                    if (!isChoicing)
                    {
                        blur.SetActive(false);
                        for (int i = 0; i < 5; i++)
                            if (buttons[i].activeSelf == true)
                                buttons[i].SetActive(false);
                    }
                    
                    choice = button = 0;
                }
            }
            else if(button == 1)
            {
                nextEventManager();
                button = 0;
            }
        }
        else if(!isFinished)
        {
            if (button == 1)
            {
                eventText.text = "";
                goToPlay.SetActive(true);
                isFinished = true;
            }
        }
    }

    void addEventInfo(string[] words) // reading and adding event
    {
        int p1, p2, p3, id = eventID + sToInt(words[0]), startPoint = 1;
        p1 = p2 = p3 = eventID;
        string corpus, func, image = "none";

        if (words[1][0] == '^')
        {
            image = sliceCombine(words[1], 1, words[1].Length);
            startPoint = 2;
        }

        if (words[words.Length - 1] == "button2")
        {
            func = "button2";
            corpus = sliceCombine(words, startPoint, words.Length - 3);

            p1 += sToInt(words[words.Length - 3]);
            p2 += sToInt(words[words.Length - 2]);

            eventHelper.Add(id, new EventInfo(corpus, image, func, p1, p2));
        }
        else if (words[words.Length - 1] == "button3")
        {
            func = "button3";
            corpus = sliceCombine(words, startPoint, words.Length - 4);
            p1 += sToInt(words[words.Length - 4]);
            p2 += sToInt(words[words.Length - 3]);
            p3 += sToInt(words[words.Length - 2]);
            eventHelper.Add(id, new EventInfo(corpus, image, func, p1, p2, p3));
        }
        else if (words[words.Length - 1].Contains(":"))
        {
            var values = words[words.Length - 1].Split(":");
            func = values[0];
            corpus = sliceCombine(words, startPoint, words.Length - 2);
            p1 += sToInt(words[words.Length - 2]);
            if (func == "npc")
                eventHelper.Add(id, new EventInfo(corpus, image, ":"+func, values[1], p1));
            else
                eventHelper.Add(id, new EventInfo(corpus, image, ":"+func, p1, sToInt(values[1])));
        }
        else if (words[words.Length - 1].Contains("/"))
        {
            var values = words[words.Length - 1].Split("/");
            func = values[0];
            corpus = sliceCombine(words, startPoint, words.Length - 3);
            p1 += sToInt(words[words.Length - 3]);
            p2 += sToInt(words[words.Length - 2]);
            if (func == "npc")
                eventHelper.Add(id, new EventInfo(corpus, image, "/" + func, values[1], p1, p2));
            else
                eventHelper.Add(id, new EventInfo(corpus, image, "/" + func, p1, p2, sToInt(values[1])));
        }
        else if (words[words.Length - 1][0] == 'p')
        {
            func = words[words.Length - 1];
            corpus = sliceCombine(words, startPoint, words.Length - 3);
            p1 += sToInt(words[words.Length - 3]);
            p2 += sToInt(words[words.Length - 2]);
            eventHelper.Add(id, new EventInfo(corpus, image, func, p1, p2));
        }
        else
        {
            func = "none";
            corpus = sliceCombine(words, startPoint, words.Length - 1);
            p1 += sToInt(words[words.Length - 1]);
            eventHelper.Add(id, new EventInfo(corpus, image, func, p1));
        }
    }

    void nextEventManager() // when textcanvas clicked
    {
        string func = eventHelper[eventID].function;
        if (func[0] == 'b')
        {
            if(!blur.activeSelf) blur.SetActive(true);
            isChoicing = true;
            if(eventText.text != "NOT ENOUGH GOLD")
                eventText.text = "";
            if (func == "button2")
            {
                if (!buttons[0].activeSelf) buttons[0].SetActive(true);
                if (!buttons[1].activeSelf) buttons[1].SetActive(true);
                c21.text = eventHelper[eventHelper[eventID].path[0]].corpus;
                c22.text = eventHelper[eventHelper[eventID].path[1]].corpus;
            } // button2
            else
            {
                if (!buttons[2].activeSelf) buttons[2].SetActive(true);
                if (!buttons[3].activeSelf) buttons[3].SetActive(true);
                if (!buttons[4].activeSelf) buttons[4].SetActive(true);
                c31.text = eventHelper[eventHelper[eventID].path[0]].corpus;
                c32.text = eventHelper[eventHelper[eventID].path[1]].corpus;
                c33.text = eventHelper[eventHelper[eventID].path[2]].corpus;
            } //button3
            return;
        }

        string imageName = eventHelper[eventID].image;
        if (imageName != "none")
        {
            foreach (var image in images.Values)
                if (image.activeSelf == true)
                    image.SetActive(false);

            if (imageName != "empty")
            {
                var image = images[imageName];
                if (image.activeSelf == false)
                    image.SetActive(true);
            }
        }

        eventText.text = eventHelper[eventID].corpus;

        if (func[0] == 'p')
        {
            var rand = new System.Random();
            int pos = sToInt(func[3].ToString() + func[4].ToString());
            if (rand.NextDouble() < pos * 0.01)
            {
                eventID = eventHelper[eventID].path[0];
            }
            else
            {
                eventID = eventHelper[eventID].path[1];
            }
        }
        else if (func[0] == '/')
        {
            var realFunc = sliceCombine(func, 1, func.Length);
            bool goPath1 = false;
            switch (realFunc)
            {
                case "gold":
                    if (gold >= eventHelper[eventID].path[2]) goPath1 = true;
                    break;
                case "npc":
                    if (ownedNPC.Contains(eventHelper[eventID].name)) goPath1 = true;
                    break;
                case "bed":
                    if (bedStatus == eventHelper[eventID].path[2]) goPath1 = true;
                    break;
                case "demo":
                    if (demoProgress >= eventHelper[eventID].path[2]) goPath1 = true;
                    break;
            }

            var prev = eventID;

            if(goPath1) eventID = eventHelper[eventID].path[0];
            else eventID = eventHelper[eventID].path[1];

            if (isChoicing && !goPath1 && prev >= eventID)
            {
                var s = "";
                switch (realFunc)
                {
                    case "gold":
                        s = "NOT ENOUGH GOLD";
                        break;
                }
                eventText.text = s;
            }
        }
        else
        {
            if(func[0] == ':')
            {
                var realFunc = sliceCombine(func, 1, func.Length);
                switch (realFunc)
                {
                    case "gold":
                        gold += eventHelper[eventID].path[1];
                        break;
                    case "npc":
                        if(!ownedNPC.Contains(eventHelper[eventID].name))
                            ownedNPC.Add(eventHelper[eventID].name);
                        break;
                    case "bed":
                        bedStatus = eventHelper[eventID].path[1];
                        break;
                    case "demo":
                        demoProgress += eventHelper[eventID].path[1];
                        break;
                    case "place":
                        currentPlaceNum = eventHelper[eventID].path[1];
                        setBackGround(currentPlaceNum);
                        break;
                }
            }
            eventID = eventHelper[eventID].path[0];
        }
    }

    void OnDisable()
    {
        MainData.gold = gold;
        MainData.day = day;
        MainData.currentPlaceNum = currentPlaceNum;
        MainData.demoProgress = demoProgress;
        MainData.bedStatus = bedStatus;
        MainData.ownedItem = ownedItem;
        MainData.ownedNPC = ownedNPC;
    }

    void baseVarInitalization()
    {
        gold = MainData.gold;
        day = MainData.day;
        currentPlaceNum = MainData.currentPlaceNum;
        demoProgress = MainData.demoProgress;
        bedStatus = MainData.bedStatus;
        ownedItem = MainData.ownedItem;
        ownedNPC = MainData.ownedNPC;

        backGrounds.Add(GameObject.Find("Dump"));
        backGrounds.Add(GameObject.Find("Demo"));
        backGrounds.Add(GameObject.Find("Gray"));
        backGrounds.Add(GameObject.Find("Moon"));

        buttons.Add(GameObject.Find("choice21"));
        buttons.Add(GameObject.Find("choice22"));
        buttons.Add(GameObject.Find("choice31"));
        buttons.Add(GameObject.Find("choice32"));
        buttons.Add(GameObject.Find("choice33"));

        string[] imageName = {"kid", "poorKid"};

        foreach (var name in imageName)
        {
            images.Add(name, GameObject.Find(name));
            images[name].SetActive(false);
        }

        goToPlay.SetActive(false);

        for (int i = 0; i < 5; i++)
        {
            buttons[i].SetActive(false);
        }

        eventText.text = "";
        isFinished = false;
    }

    void selectEvent()
    {
        // ending event process
        if (day == END_DAY)
        {

            return;
        }

        // main event process
        if (day == 0)
        {
            upComingEvents.Add("main0");
            return;
        }
        if (currentPlaceNum < 3 && gold >= MONEY_TO_GO[currentPlaceNum])
        {
            upComingEvents.Add("main" + (currentPlaceNum + 1).ToString());
            return;
        }

        // sub event process
        switch (currentPlaceNum)
        {
            case 0:
                if (day % 2 == 0)
                {
                    tryAddingEvent("sub00"); // loan shark
                }
                if(!ownedNPC.Contains("kid"))
                {
                    tryAddingEvent("sub01"); // kid
                }
                //tryAddingEvent("sub02"); // crazy man and drunk
                break;
            case 1:
                //tryAddingEvent("sub10"); // demo crowd
                //tryAddingEvent("sub11"); // demo leader
                break;
            case 2:
                //tryAddingEvent("sub20"); // factory owner
                //tryAddingEvent("sub21"); // factory
                if (bedStatus == 0)
                {
                    var tmp1 = EVENT_POSSIBILITY[2, 2];
                    var tmp2 = EVENT_POSSIBILITY[2, 3];
                    EVENT_POSSIBILITY[2, 2] = ORIGINAL_POS22;
                    EVENT_POSSIBILITY[2, 3] = ORIGINAL_POS23;
                    //tryAddingEvent("sub22"); // blackguard
                    //tryAddingEvent("sub23"); // thief
                    EVENT_POSSIBILITY[2, 2] = tmp1;
                    EVENT_POSSIBILITY[2, 3] = tmp2;
                }
                else
                {
                    //tryAddingEvent("sub22"); // blackguard
                    //tryAddingEvent("sub23"); // thief
                }
                break;
            case 3:
                if(bedStatus == 4)
                {
                    //tryAddingEvent("sub30"); // president
                }
                break;
        }
    }

    void tryAddingEvent(string eventName)
    {
        var rand = new System.Random();
        double possibility = EVENT_POSSIBILITY[eventName[3] - '0', eventName[4] - '0'];
        if (rand.NextDouble() < possibility)
        {
            upComingEvents.Add(eventName);
        }
    }

    void setBackGround(int placeNum) // show only one intended background
    {
        for (int i = 0; i < 4; i++)
            if (backGrounds[i].activeSelf == true)
                backGrounds[i].SetActive(false);
        if(!backGrounds[placeNum].activeSelf)
            backGrounds[placeNum].SetActive(true);
    }

    string sliceCombine(string[] corpus, int start, int end)
    {
        if (start == end)
            return "";
        string res = corpus[start];
        for(int i = start + 1; i < end; i++)
        {
            res += " " + corpus[i];
        }
        return res;
    }

    string sliceCombine(string corpus, int start, int end)
    {
        if (start == end)
            return "";
        string res = corpus[start].ToString();
        for (int i = start + 1; i < end; i++)
        {
            res += corpus[i].ToString();
        }
        return res;
    }

    int sToInt(string s)
    {
        int res = 0, startPoint = 0, factor = 1;
        if (s[0] == '-')
        {
            startPoint = 1;
            factor = -1;
        }

        if (s[0] == '+')
        {
            startPoint = 1;
        }

        for (int i = startPoint; i < s.Length; i++)
        {
            res = res * 10 + s[i] - '0';
        }
        return res * factor;
    }

    List<string> getLines(string eventName)
    {
        TextAsset asset = Resources.Load("Encounters/" + eventName) as TextAsset;
        string str = asset.text;

        //Debug.Log(str);

        var lines = str.Split('\n');
        var Lines = new List<string>();
        foreach(var line in lines)
        {
            if (line == "")
                continue;

            if('0' <= line[line.Length - 1] && line[line.Length - 1] <= '9')
                Lines.Add(line);
            else
            {
                Lines.Add(sliceCombine(line, 0, line.Length - 1));
            }
        }

        //string path = "Assets/Resources/Encounters/";
        //string Tag_path = path + eventName + ".txt";

        //var lines_ = new List<string>();
        //foreach (string line in File.ReadLines(Tag_path))
        //{
        //    lines_.Add(line);
        //}


        return Lines;
        
        
    }
}
