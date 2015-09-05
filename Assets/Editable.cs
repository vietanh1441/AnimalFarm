using UnityEngine;
using System.Collections;

public class Editable : MonoBehaviour {
 
    public bool editable;
    private Vector3 offset;
    private Vector3 screenPoint;
    private GameObject owner;
	// Use this for initialization
	void Start () {
        transform.parent = GameObject.Find("EditableParent").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseDown()
    {
        if (editable)
        {
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (editable)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            transform.position = curPosition;
        }
    }

    void OnMouseUp()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), -1);
        if(transform.position.x <0 || transform.position.x > 10 || transform.position.y < 0 || transform.position.y > 10)
        {
            owner.GetComponent<SaleItem>().own++;
            Destroy(gameObject);
        }
    }
    public void SetEditable()
    {
        editable = true;
        Debug.Log("Set");
    }

    public void UnsetEditable()
    {
        editable = false;
    }

    public void SetOwner(GameObject own)
    {
        owner = own;
    }
    
}
