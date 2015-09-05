using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    private Vector3 offset;
    private Vector3 screenPoint;
    private bool change;
    private BoardManager bM_script;

    // Use this for initialization
    void Start()
    {
        bM_script = GameObject.Find("BoardManager").GetComponent<BoardManager>();
        change = false;
        Debug.Log("AddArrow");
        bM_script.ArrowList.Add(gameObject);
    }

    public void Readjust()
    {

        
        if (transform.parent != null)
        {
            transform.parent.position = new Vector3(8, 0 + 1f * bM_script.ArrowList.IndexOf(gameObject), -1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        transform.parent.gameObject.SendMessage("PickUp");
        
    }

    public void OnMouseOver()
    {

        if (Input.GetMouseButton(1)&& change == false)
        {
            transform.parent.gameObject.SendMessage("Signal");
            change = true;
            Invoke("Change", 0.2f);
        }
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
    }
}
