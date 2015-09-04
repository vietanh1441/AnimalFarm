using UnityEngine;
using System.Collections;

public class NewButton : MonoBehaviour
{

    public string hit;
    private GameObject central;
    private Central central_scr;
    public int value;
    private bool on;
   

    // Use this for initialization
    void Start()
    {
        on = false;
        central = GameObject.Find("Central");
        central_scr = central.GetComponent<Central>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Invoke(hit, 0.1f);
    }

    public void GoToLevel()
    {
        central_scr.GoToLevel(value);
    }

    public void NewDay()
    {
        central_scr.NewDay();
    }

    public void Edit()
    {
        central_scr.Edit();
    }

    public void Unedit()
    {
        central_scr.Unedit();
    }

    public void BuyAnimal()
    {
        if(!on)
        { 
            GameObject.Find("AnimalDrag").transform.position = new Vector3(0, 6, -1);
            on = true;
        }
        else
        {
            GameObject.Find("AnimalDrag").transform.position = new Vector3(100, 6, -10);
            on = false;
        }
    }

    public void BuyTree()
    {
        if (!on)
        {
            GameObject.Find("TreeDrag").transform.position = new Vector3(0, 4, -1);
            on = true;
        }
        else
        {
            GameObject.Find("TreeDrag").transform.position = new Vector3(100, 4, -10);
            on = false;
        }
    }

    public void BuyTool()
    {
        if (!on)
        {
            GameObject.Find("ToolDrag").transform.position = new Vector3(0, 2, -1);
            on = true;
        }
        else
        {
            GameObject.Find("ToolDrag").transform.position = new Vector3(100, 2, -10);
            on = false;
        }
    }



    public void Buy()
    {
        central_scr.Buy();
    }

    public void BuyItem()
    {
        if (transform.parent != null)
        {
            transform.parent.gameObject.SendMessage("Buy");
        }
    }
}