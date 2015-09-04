using UnityEngine;
using System.Collections;

public class AnimalManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Butcher()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);

        }
    }
}
