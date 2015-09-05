using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public GameObject central;
    public Central central_script;
    public int type; //money, apple, egg, 
    public int value;
	// Use this for initialization
	void Start () {
        central = GameObject.Find("Central");
        central_script = central.GetComponent<Central>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Calculate()
    {
        Debug.Log("Calculate");
        Debug.Log(type);
        if (type == 0)
        {
            central_script.money = central_script.money + 1;
        }
        if (type == 1)
        {
            central_script.money = central_script.money + 3;
        }
        if (type == 2)
        {
            central_script.money = central_script.money + 10;
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
