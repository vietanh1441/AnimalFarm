using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Central : MonoBehaviour {

    public int money, dog, chicken, cow, pig, horse, cat, goat, sheep;
    public GameObject bM;
    public BoardManager bM_script;
    public int day;
    public List<GameObject> editableList = new List<GameObject>();

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	// Use this for initialization
	void Start () {
        
	}


    void OnLevelWasLoaded()
    {
        Debug.Log("GoInNewLevel");
        if (Application.loadedLevel == 1)
        {
            bM = GameObject.Find("BoardManager");
            bM_script = bM.GetComponent<BoardManager>();
           // bM_script.SettingUp();
         //   Debug.Log("RunThis");
            NewGame();
        }

    }
	// Update is called once per frame
	void Update () {
	
	}

    public void GoToLevel(int value)
    {
        
        Application.LoadLevel(1);
    }

    public void NewDay()
    {
        Sync();
        bM_script.NewDay();
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(2, 2, -10);
    }

    public void Sync()
    {
        bM_script.money = money;
        bM_script.dog = dog;
        bM_script.chicken = chicken;
        bM_script.cow = cow;
        bM_script.pig = pig;
        bM_script.horse = horse;
        bM_script.cat = cat;
        bM_script.goat = goat;
        bM_script.sheep = sheep;
    }

    public void NewGame()
    {
        Debug.Log("Whatabt here?");
        money = 5;
        dog = 5;
        chicken = 0;
        cow = 0;
        pig = 0;
        horse = 0;
        cat = 0;
        goat = 0;
        sheep = 0;
        day = 1;
        Sync();
        bM_script.SettingUp();
    }

    public void Edit()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(2, 2, -10);
        foreach(GameObject obj in editableList)
        {
            obj.SendMessage("SetEditable");
        }
        GameObject.Find("Unedit").transform.position = new Vector3(-4, 4, -2);
    }

    public void Unedit()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(-20, -20, -10);
        foreach (GameObject obj in editableList)
        {
            obj.SendMessage("UnsetEditable");
        }
        GameObject.Find("Unedit").transform.position = new Vector3(-40, -40, 20);
    }
}
