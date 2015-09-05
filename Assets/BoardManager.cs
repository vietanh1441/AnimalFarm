using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour {
    private List<Vector3> gridPositions = new List<Vector3>();	//A list of possible locations to place tiles.
    private Transform boardHolder;
    public int columns = 8; 										//Number of columns in our game board.
    public int rows = 8;											//Number of rows in our game board.
    public GameObject[] floorTiles;									//Array of floor prefabs.
    public GameObject[] outerWallTiles;								//Array of outer tile prefabs.
   // public List<GameObject> animal = new List<GameObject>();
   // public GameObject[,] obj = new GameObject[5,5];
    public GameObject[] animal;
    private GameObject ani1, ani2, ani3;
    public int direction;
    public int[] objective; 
    public int max_inside;
    public int inside;
    private bool ready, start;
    public int money, dog, chicken, cow, pig, horse, cat, goat, sheep;
    private Text time_txt;
    public GameObject central;
    public GameObject gate;
    public Central central_scr;
    public List<int> order = new List<int>();
    public int time;
    public GameObject animalManager;
    public List<GameObject> CountDownList = new List<GameObject>();
    public List<GameObject> ArrowList = new List<GameObject>();
    public List<GameObject> CleanUpList = new List<GameObject>();
    private bool start_day = false;
	void Awake () {

        
        // InitialiseList();

//        Time.timeScale = 0;
        animalManager = GameObject.Find("AnimalManager");
        start_day = false;
    
	}

   

    void Start()
    {
        central = GameObject.Find("Central");
        central_scr = central.GetComponent<Central>();
        GameObject tim = GameObject.Find("Time");
        time_txt = tim.GetComponent<Text>();
        
        //Push();
       

    }

    public void StartDay()
    {
        start_day = true;
    }

    public void SettingUp()
    {
        
        inside = 0;
        InitializeGame();

        BoardSetup();
    }

    public void NewDay()
    {
        foreach (GameObject child in ArrowList)
        {
            child.SendMessage("Readjust");
        }
        start = false;
        ready = false;
        start_day = false;
        Destroy(gate);
        inside = 0;
        InitializeGame();
    }

    //Initialize the game by creating 3 animal at the entrance
    public void InitializeGame()
    {
        int i = 0;
        for (i = 0; i < dog; i++ )
        {
            order.Add(0);
        }
        for (i = 0; i < chicken; i++ )
        {
            order.Add(1);
        }
        int rd = Random.Range(0, order.Count);
        ani1 = Instantiate(animal[order[rd]], new Vector3(5, -1, -2), Quaternion.identity) as GameObject;
        order.Remove(order[rd]);
        rd = Random.Range(0, order.Count);
        ani2 = Instantiate(animal[order[rd]], new Vector3(5, -2, -2), Quaternion.identity) as GameObject;
        order.Remove(order[rd]);
        rd = Random.Range(0, order.Count);
        ani3 = Instantiate(animal[order[rd]], new Vector3(5, -3, -2), Quaternion.identity) as GameObject;
        order.Remove(order[rd]);
        Debug.Log(animalManager.transform);
        ani1.transform.parent = animalManager.transform;
        ani2.transform.parent = animalManager.transform;
        ani3.transform.parent = animalManager.transform;

    }

    //Create 1 animal and push the other into the abyss
    public void Push()
    {
        
        ready = false;
        if (ani1 != null)
        {
            ani1.transform.position = new Vector3(5, 0, -2);
            ani1.SendMessage("Ready", direction);
            inside++;
        }
        if (ani2 != null)
        {
            ani2.transform.position = new Vector3(5, -1, -2);
        }
        if (ani3 != null)
        {
            ani3.transform.position = new Vector3(5, -2, -2);
        }
        ani1 = ani2;
        ani2 = ani3;
        if (order.Count > 0)
        {
            int rd = Random.Range(0, order.Count);
            ani3 = Instantiate(animal[order[rd]], new Vector3(5, -3, -2), Quaternion.identity) as GameObject;
            order.Remove(order[rd]);
            ani3.transform.parent = animalManager.transform;
        }
        else
        {
            ani3 = null;
        }
        
        Invoke("Ready", 1f);

        if(ani1 == null && gate == null)
        {
            gate = Instantiate(outerWallTiles[0], new Vector3(5, -1, -2), Quaternion.identity) as GameObject;
          
        }
    }

    public void Ready()
    {
        ready = true;
    }
    //Clears our list gridPositions and prepares it to generate a new board.
   /* void InitialiseList()
    {
       for(int i = 0; i < 5; i++)
       {
           for(int j = 0; j < 5; j++)
           {
               obj[i, j] = null;
           }
       }
    }*/
		
    public void SignalAnimal()
    {

    }

    public void CountDown()
    {
        time--;
        Invoke("CountDown", 1);
    }

	// Update is called once per frame
	void Update () {
        if (start == false)
        {
            if (start_day)
            {
                start = true;
                Push();
                Time.timeScale = 1;
                Invoke("CountDown", 1);
                foreach(GameObject child in CountDownList)
                {
                    child.SendMessage("StartCountDown");
                }
               
            }
        }
	    else if(inside < max_inside)
        {
            if(ready)
            {
                Push();
            }
        }
        time_txt.text = " " + time;
        if(time == 0)
        {
            EndDay();
        }
	}

   

    void BoardSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;
        GameObject instance;
        for (int x = -10; x < 10; x++ )
        {
            for(int y = -10; y < 10; y++)
            {
                instance = Instantiate(floorTiles[0], new Vector3(x, y, 1), Quaternion.identity)as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }

            //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
            for (int x = -1; x < columns + 1; x++)
            {
                //Loop along y axis, starting from -1 to place floor or outerwall tiles.
                for (int y = -1; y < rows + 1; y++)
                {
                    //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                    //   GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                   // GameObject toInstantiate;
                    //Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
                    if (x == 5 && y == -1)
                    {

                    }
                    else if ( x== 1 && y == rows)
                    {

                    }
                    else if (x == -1 || x == columns || y == -1 || y == rows)
                    {
                        instance = Instantiate(outerWallTiles[0], new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                        instance.transform.SetParent(boardHolder);
                    }
                    
                    //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                    

                    //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                    
                }
            }
     //   Instantiate(step, new Vector3(0, -2, 0f), Quaternion.identity);
    }

    public void Next()
    {
        if(inside == 1 && ani1 == null)
        {
            EndDay();
        }
        else
        {
            Push();
        }
       
        
    }

    public void EndDay()
    {
        time = 10;
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(-20, -20, -10);
        
        CancelInvoke("CountDown");
        animalManager.SendMessage("Butcher");
        foreach (GameObject child in CountDownList)
        {
            child.SendMessage("StopCountDown");
        }
        foreach (GameObject child in ArrowList)
        {
            child.SendMessage("Readjust");
        }
        foreach (GameObject child in CleanUpList)
        {
            child.SendMessage("CleanUp");
        }
    }

   
}
