using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public GameObject bM;
    public BoardManager bM_script;
    public int type; //money, apple, egg, 
    public int value;
	// Use this for initialization
	void Start () {
        bM = GameObject.Find("BoardManager");
        bM_script = bM.GetComponent<BoardManager>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Calculate()
    {
        if (type == 0)
        {
            bM_script.money = bM_script.money + 1;
        }
        if (type == 1)
        {
            bM_script.money = bM_script.money + 3;
        }
        if (type == 2)
        {
            bM_script.money = bM_script.money + 10;
        }
    }

   /* void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Finish")
        {
            if (type == 0)
            {
                bM_script.money = bM_script.money + 1;
            }
            if(type == 1)
            {
                bM_script.money = bM_script.money + 3;
            }
            if(type == 2)
            {
                bM_script.money = bM_script.money + 10;
            }
        }
    }*/
}
