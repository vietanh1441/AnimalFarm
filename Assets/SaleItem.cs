using UnityEngine;
using System.Collections;

public class SaleItem : MonoBehaviour {
    public GameObject saleItem;
    public GameObject drag;
    public Drag drag_script;
    private Vector3 screenPoint;
    private Vector3 offset;
    private GameObject newItem;
    public int price;
    private GameObject central;
    private Central central_scr;
    public int own;
	// Use this for initialization
	void Start () {
        own = 0;
        drag = transform.parent.gameObject;
        drag_script = drag.GetComponent<Drag>();
        drag_script.AddList(gameObject);
        central = GameObject.Find("Central");
        central_scr = central.GetComponent<Central>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Readjust()
    {
        if (transform.parent != null)
        {
            transform.localPosition = new Vector3(0, 0 - 0.03f * drag_script.theList.IndexOf(gameObject), -1);
        }
    }

    void OnMouseDown()
    {
        if (own > 0)
        {
            newItem = Instantiate(saleItem, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            newItem.SendMessage("SetEditable");
            own--;
            newItem.SendMessage("SetOwner", gameObject);
        }
    }

    void OnMouseDrag()
    {

        if (newItem != null)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            newItem.transform.position = curPosition;
        }
        
    }

    void OnMouseUp()
    {
        if (newItem != null)
        {
            newItem.transform.position = new Vector3(Mathf.Round(newItem.transform.position.x), Mathf.Round(newItem.transform.position.y), -1);
        }
        newItem = null;
    }

    public void Buy()
    {
        if(central_scr.money >= price)
        {
            own++;
            central_scr.money = central_scr.money - price;
        }
        else
        {

        }
    }
}
