using UnityEngine;
using System.Collections;

public class AnimalItem : MonoBehaviour {

	 public GameObject saleItem;
    public GameObject drag;
    public Drag drag_script;
    private GameObject newItem;
    public int price;
    private GameObject central;
    private Central central_scr;
    public int own;
    public int type;

    public string toolTipText = ""; // set this in the Inspector
    public string name = "";
    private string currentToolTipText = "";
    private GUIStyle guiStyleFore;
    private GUIStyle guiStyleBack;
    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;

	// Use this for initialization
	void Start () {
        own = 0;
        drag = transform.parent.gameObject;
        drag_script = drag.GetComponent<Drag>();
        drag_script.AddList(gameObject);
        central = GameObject.Find("Central");
        central_scr = central.GetComponent<Central>();
        if (type == 0)
        {
            own = central_scr.dog;
        }
        else if(type == 1)
        {
            own = central_scr.chicken;
        }
        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
        guiStyleFore.alignment = TextAnchor.UpperCenter;
        guiStyleFore.wordWrap = true;
        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperCenter;
        guiStyleBack.wordWrap = true;

       // toolTipText = name + "\n In Storage: " + own + "\n " + toolTipText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void OnMouseEnter()
    {
        currentToolTipText = name + "\n In Storage: " + own + "\n Price:" + price + " \n" +  toolTipText;

       

    }

    public void OnMouseExit()
    {
        currentToolTipText = "";
    }

    public void OnGUI()
    {
        if (currentToolTipText != "")
        {
            var x = Event.current.mousePosition.x;
            var y = Event.current.mousePosition.y-100;
           // GUI.Label(new Rect(x - 149, y + 21, 300, 60), currentToolTipText, guiStyleBack);
            
            GUIDrawRect(new Rect(x - 149, y + 21, 300, 60), new Color(0.1f, 0.1f, 0.1f, 0.8f));
            GUI.Label(new Rect(x - 150, y + 20, 300, 60), currentToolTipText, guiStyleFore);
        }
    }

    public static void GUIDrawRect(Rect position, Color color)
    {
        if (_staticRectTexture == null)
        {
            _staticRectTexture = new Texture2D(1, 1);
        }

        if (_staticRectStyle == null)
        {
            _staticRectStyle = new GUIStyle();
        }

        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();

        _staticRectStyle.normal.background = _staticRectTexture;

        GUI.Box(position, GUIContent.none, _staticRectStyle);


    }

    public void Readjust()
    {
        if (transform.parent != null)
        {
            transform.localPosition = new Vector3( 0 +0.05f * drag_script.theList.IndexOf(gameObject),0, -1);
        }
    }

    void OnMouseDown()
    {
       
    }

    void OnMouseDrag()
    {

       
        
    }

    void OnMouseUp()
    {
        
    }

    public void Buy()
    {
        if(central_scr.money >= price)
        {
            own++;
            central_scr.dog++;
            central_scr.money = central_scr.money - price;
        }
        else
        {

        }
    }
}
