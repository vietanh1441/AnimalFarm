using UnityEngine;
using System.Collections;

public class Under : MonoBehaviour {
    //11: Egg maker
    //12: 
    //
    public int type;    //finish, up, down, right, left, egg
    public Sprite[] sprite;
    public int value;
    public bool full;
    public GameObject bM;
    public BoardManager bM_script;
	// Use this for initialization
	void Start () {
        ChangeSprite();
        full = false;
        bM = GameObject.Find("BoardManager");
        bM_script = bM.GetComponent<BoardManager>();
	}
	
    public void ChangeSprite()
    {
        if (type > 0 && type < 10)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite[type - 1];
        }
        
    }

	// Update is called once per frame
	void Update () {
	
	}

    void Signal()
    {
        if (type != 0)
        {
            if(type == 1)
            {
                type = 3;
            }
            else if (type == 2)
            {
                type = 4;
            }
            else if (type == 3)
            {
                type = 2;
            }
            else if (type == 4)
            {
                type = 1;
            }
        }
        ChangeSprite();
    }

    public void PickUp()
    {
        type = type + 100;
    }

    public void PutDown()
    {
        type = type - 100;
    }

    void OnMouseDown()
    {
       
    }

    public void SetFull()
    {
        full = true ;
    }

    public void UnsetFull()
    {
        full = false;
    }


}
