using UnityEngine;
using System.Collections;

public class NewButton : MonoBehaviour
{

    public string hit;
    private GameObject central;
    private Central central_scr;
    public int value;

   

    // Use this for initialization
    void Start()
    {
        central = GameObject.Find("Central");
        central_scr = central.GetComponent<Central>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Invoke(hit, 0.1f);
    }

    public void GoToLevel()
    {
        central_scr.GoToLevel(value);
    }

    public void NewDay()
    {
        central_scr.NewDay();
    }

    public void Edit()
    {
        central_scr.Edit();
    }

    public void Unedit()
    {
        central_scr.Unedit();
    }
}