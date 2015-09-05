using UnityEngine;
using System.Collections;

public class CoinMaker : MonoBehaviour {
    public GameObject coin;
    public GameObject bM;
    public BoardManager bM_script;
	// Use this for initialization
	void Start () {
        bM = GameObject.Find("BoardManager");
        bM_script = bM.GetComponent<BoardManager>();
        bM_script.CountDownList.Add(gameObject);
        bM_script.CleanUpList.Add(gameObject);
      
	}

    public void StartCountDown()
    {
        if (transform.childCount < 5)
        {
            GameObject instance = Instantiate(coin, new Vector3(Mathf.Round(Random.Range(1, 7)), Mathf.Round(Random.Range(1, 7)), -1), Quaternion.identity) as GameObject;
            instance.transform.parent = transform;
        }
        Invoke("StartCountDown", 5);
    }
    
    public void StopCountDown()
    {

    }

    public void CleanUp()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
           
        }
        CancelInvoke("StartCountDown");
    }

	// Update is called once per frame
	void Update () {
	
	}
}
