using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour {
    public GameObject bM;
    public BoardManager bM_script;
    public float speed;
    public bool moving;
    public int direction;   //up, down, right, left
    public GameObject store;
    private int status; //normal, happy, sad

  
    public int type; //chicken, cat, cow, chicken

	// Use this for initialization
	void Start () {
        
    //    direction = 0;
        //Get BoardManager script and add itself into the list
        bM = GameObject.Find("BoardManager");
        bM_script = bM.GetComponent<BoardManager>();
       // bM_script.animal.Add(gameObject);
        //bM_script.obj[(int)transform.position.x, (int)transform.position.y] = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {

            if (direction == 0)
            {
                transform.Translate(0, speed, 0);

            }
            else if (direction == 1)
            {
                transform.Translate(0, -speed, 0);
            }
            else if (direction == 2)
            {
                transform.Translate(speed, 0, 0);
            }
            else if (direction == 3)
            {
                transform.Translate(-speed, 0, 0);
            }
        }
	}

    public void Ready(int dir)
    {
        moving = true;
        direction = dir;
        if(type == 0)
        {
            transform.tag = "Dog";
        }
    }

    public void Signal()
    {
       
    }

    public void CheckingTag(GameObject other)
    {
        if(transform.tag == other.tag)
        {
            status = 1;
        }
    }

    public void UpSignal(GameObject other)
    {
       // transform.Translate(0, -speed, 0);
        if (other.tag == "Under" || other.tag == "Item" || other.tag == "Ignore")
        {
            //Do nothing
        }
        else if (other.tag == "Untagged")
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y),-2);
            direction = GetDirection(direction);
        }
        else
        {
            CheckingTag(other);
            direction = GetDirection(direction);
        }
    }

    public void DownSignal(GameObject other)
    {
        if (other.tag == "Under" || other.tag == "Item" || other.tag == "Ignore")
        {
            //Do nothing
        }
        else if (other.tag == "Untagged")
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y),-2);
            // transform.Translate(0, speed, 0);
            direction = GetDirection(direction);
        }
        else
        {
            CheckingTag(other);
            direction = GetDirection(direction);
        }
    }

    public void RightSignal(GameObject other)
    {
        if (other.tag == "Under" || other.tag == "Item" || other.tag == "Ignore")
        {
            //Do nothing
        }
        else if (other.tag == "Untagged")
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y),-2);
            //transform.Translate(-speed, 0, 0);
            direction = GetDirection(direction);
        }
        else
        {
            CheckingTag(other);
            direction = GetDirection(direction);
        }
    }

    public void LeftSignal(GameObject other)
    {
        if (other.tag == "Under" || other.tag == "Item" || other.tag == "Ignore")
        {
            //Do nothing
        }
        else if (other.tag == "Untagged")
        {

            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y),-2);
            //transform.Translate(speed, 0, 0);
            direction = GetDirection(direction);
        }
        else
        {
            CheckingTag(other);
            direction = GetDirection(direction);
        }
    }

    public void CentralSignal(GameObject other)
    {
        if(other.tag == "Under")
        {
            Under other_script = other.gameObject.GetComponent<Under>();
            int other_type = other_script.type;
            if(other_type == 0)
            {
                    HappyFinishing();
                
            }
            else if(other_type == 11)
            {
                if(type == 11)
                {
                    //Lay egg
                    if(store!= null && other_script.full == false)
                    {
                       GameObject instance = Instantiate(store,new Vector3(Mathf.Round(other.transform.position.x), Mathf.Round(other.transform.position.y),-2), Quaternion.identity) as GameObject;
                        store = null;
                        instance.transform.parent = GameObject.Find("CoinMaker").transform;
                        other_script.full = true;
                    }
                }
                else if (type == 10)
                {
                    if(store == null && other_script.full == true)
                    {
                        other_script.full = false;
                    }
                }
            }
            else if(other_type > 100)
            {
                //do nothing;
            }
            else 
            {
                transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y),-2);
                direction = other_type-1;
            }
        }
        else if(other.tag == "Item")
        {
            if(type == 10 )
            {
                if (store == null)
                {
                    store = other.gameObject;
                    store.transform.parent = transform;
                    store.transform.localPosition = new Vector3(0, 1, 0);
                    store.transform.tag = "Ignore";
                }
            }
        }
    }

    //Based on the original direction, change it to a diffrent one;
    public int GetDirection(int dir)
    {
        int rd = Random.Range(1, 4);
        dir = dir + rd;
        if(dir > 3)
        {
            dir = dir - 4;
        }
        return dir;
    }

    public void HappyFinishing()
    {
        moving = false;
        //Play animation
        //bM_script.objective[type]--;
        if(type==10)
        {
            if(store != null)
            {
                store.GetComponent<Item>().Calculate();
            }
        }

        bM_script.Next();
        bM_script.inside--;
        Invoke("Finishing2", 0.1f);
    }

    public void SadFinishing()
    {

    }

    public void Finishing2()
    {
        Destroy(gameObject);
    }
}
