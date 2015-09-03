using UnityEngine;
using System.Collections;

public class CoinMaker : MonoBehaviour {
    public GameObject coin;
    
	// Use this for initialization
	void Start () {
        
	}
	
    public void MakeItRain()
    {
        if (transform.childCount < 5)
        {
            GameObject instance = Instantiate(coin, new Vector3(Mathf.Round(Random.Range(1, 7)), Mathf.Round(Random.Range(1, 7)), -1), Quaternion.identity) as GameObject;
            instance.transform.parent = transform;
        }
        Invoke("MakeItRain", 5);
    }
    
    public void DryIt()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
            CancelInvoke("MakeItRain");
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
