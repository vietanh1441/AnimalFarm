using UnityEngine;
using System.Collections;

public class Editable : MonoBehaviour {
    private GameObject central;
    private Central central_scr;
    private bool editable;
    private Vector3 offset;
    private Vector3 screenPoint;
	// Use this for initialization
	void Start () {
        central = GameObject.Find("Central");
        central_scr = central.GetComponent<Central>();
        central_scr.editableList.Add(gameObject);
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
}
