using UnityEngine;
using System.Collections;

/// <summary>
/// This is the sensor that tell the parent that it hit something
/// </summary>

public class Sensor : MonoBehaviour {

    public int pos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (pos == 0)
        {
            transform.parent.SendMessage("UpSignal", other.gameObject);
        }
        else if (pos == 1)
        {
            transform.parent.SendMessage("DownSignal", other.gameObject);
        }
        else if ( pos == 2)
        {
            transform.parent.SendMessage("RightSignal", other.gameObject);
        }
        else if ( pos == 3)
        {
            transform.parent.SendMessage("LeftSignal", other.gameObject);
        }
        else if (pos == 4)
        {
            transform.parent.SendMessage("CentralSignal", other.gameObject);
        }
    }
}
