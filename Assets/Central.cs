using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Central : MonoBehaviour {

    public int money, dog, chicken, cow, pig, horse, cat, goat, sheep, time;
    public GameObject bM;
    private Text coin_txt, time_txt;

    public BoardManager bM_script;
    public int day;
    private GameObject editableParent;

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
            GameObject coin = GameObject.Find("Coin");
            coin_txt = coin.GetComponent<Text>();
            editableParent = GameObject.Find("EditableParent");
        }

    }
	// Update is called once per frame
	void Update () {
        if (Application.loadedLevel == 1)
        {
            coin_txt.text = " " + money;
        }
        //time_txt.text = " " + time;

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
        bM_script.time = time;
    }

    public void NewGame()
    {
        Debug.Log("Whatabt here?");
       
        Sync();
        bM_script.SettingUp();
    }

    public void Edit()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(2, 2, -10);
        editableParent.SendMessage("SetEditable");
        GameObject.Find("Unedit").transform.position = new Vector3(-4, 4, -2);
    }

    public void Unedit()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(-20, -20, -10);
        GameObject.Find("BuyAnimal").transform.position = new Vector3(-40, 6, -20);
        GameObject.Find("BuyTree").transform.position = new Vector3(-40, 4, -20);
        GameObject.Find("BuyFarmTool").transform.position = new Vector3(-40, 2, -20);
        editableParent.SendMessage("UnsetEditable");
        GameObject.Find("Unedit").transform.position = new Vector3(-40, -40, -20);
    }

    public void Buy()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(2, 2, -10);
        //get other object to the surface
        GameObject.Find("BuyAnimal").transform.position = new Vector3(0,-2,-2);
        GameObject.Find("BuyTree").transform.position = new Vector3(2, -2, -2);
        GameObject.Find("BuyFarmTool").transform.position = new Vector3(4, -2, -2);
        editableParent.SendMessage("UnsetEditable");
        GameObject.Find("Unedit").transform.position = new Vector3(-4, 0, -2);
    }
}
