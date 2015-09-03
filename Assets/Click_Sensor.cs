using UnityEngine;
using System.Collections;

public class Click_Sensor : MonoBehaviour {
    private Vector3 offset;
    private Vector3 screenPoint;
    private bool change;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        
        change = true;
        Invoke("Change", 0.1f);
        transform.parent.gameObject.SendMessage("PickUp");
    }

    public void Change()
    {
        change = false;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
      /*  if (dir == 0)
        {
            curPosition.y = ypos;
        }
        else if (dir == 1)
        {
            curPosition.x = xpos;
        }*/
        transform.parent.position = curPosition;
    }

    void OnMouseUp()
    {
        transform.parent.gameObject.SendMessage("PutDown");
        transform.parent.position = new Vector3(Mathf.Round(transform.parent.position.x), Mathf.Round(transform.parent.position.y), -1);
        if(change)
        {
            transform.parent.gameObject.SendMessage("Signal");
        }
    }

}
