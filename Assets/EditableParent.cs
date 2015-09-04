using UnityEngine;
using System.Collections;

public class EditableParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetEditable()
    {
        foreach (Transform child in transform)
        {
            child.SendMessage("SetEditable");

        }
    }

    public void UnsetEditable()
    {
        foreach (Transform child in transform)
        {
            child.SendMessage("SetEditable");

        }
    }
}
