using UnityEngine;
using System.Collections;

public class NewButton : MonoBehaviour
{

    public string hit;
    private GameObject central;
    private Central central_scr;
    public int value;
    private bool on;
    public GameObject drag;

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
        GameObject.Find("AnimalDrag").transform.position = new Vector3(100, 6, -10);
        GameObject.Find("TreeDrag").transform.position = new Vector3(100, 4, -10);
        GameObject.Find("ToolDrag").transform.position = new Vector3(100, 2, -10);
    }

    public void BuySomething()
    {
        GameObject.Find("AnimalDrag").transform.position = new Vector3(100, -2, -10);
        GameObject.Find("TreeDrag").transform.position = new Vector3(100, -2, -10);
        GameObject.Find("ToolDrag").transform.position = new Vector3(100, -2, -10);
        GameObject.Find("BuyAnimal").transform.position = new Vector3(-6, -2, -2);
        GameObject.Find("BuyTree").transform.position = new Vector3(-5, -2, -2);
        GameObject.Find("BuyFarmTool").transform.position = new Vector3(-4, -2, -2);
        if(drag.transform.position.x == 100)
        { 
            drag.transform.position = new Vector3(0, drag.transform.position.y, -1);
            on = true;
        }
        else
        {
            drag.transform.position = new Vector3(100, drag.transform.position.y, -10);
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

    public void StartDay()
    {
        GameObject.Find("BoardManager").SendMessage("StartDay");
    }
}