using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {
    public int ripe_time;
    private int countdown;
    public GameObject fruit;
    public GameObject bM;
    public BoardManager bM_script;
	// Use this for initialization
	void Start () {
        bM = GameObject.Find("BoardManager");
        bM_script = bM.GetComponent<BoardManager>();
        bM_script.CountDownList.Add(gameObject);
        countdown = ripe_time;
        bM_script.CleanUpList.Add(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	    if(countdown == 0)
        {
            Vector3 spawnspot = new Vector3(0,0,-2);
            int rd = Random.Range(0,8);
            if(rd ==0)
            {
                spawnspot = new Vector3(1,-1,-2);
            }
            if(rd == 1)
            {
                spawnspot = new Vector3(1,0,-2);
            }
             if(rd == 2)
            {
                spawnspot = new Vector3(1,1,-2);
            }
             if(rd == 3)
            {
                spawnspot = new Vector3(0,-1,-2);
            }
             if(rd == 4)
            {
                spawnspot = new Vector3(0,1,-2);
            }
             if(rd == 5)
            {
                spawnspot = new Vector3(-1,-1,-2);
            }
             if(rd == 6)
            {
                spawnspot = new Vector3(-1,0,-2);
            }
             if(rd == 7)
            {
                spawnspot = new Vector3(-1,1,-2);
            }
             spawnspot = transform.position + spawnspot;
             GameObject instance = Instantiate(fruit, spawnspot, Quaternion.identity)as GameObject;
             instance.transform.parent = transform;
             countdown = ripe_time;
        }
	}

    public void StartCountDown()
    {
        countdown--;
        Invoke("StartCountDown", 1);
    }

    public void StopCountDown()
    {
        CancelInvoke("StartCountDown");
    }

    public void OnDestroy()
    {
        bM_script.CountDownList.Remove(gameObject);
    }

    public void CleanUp()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
