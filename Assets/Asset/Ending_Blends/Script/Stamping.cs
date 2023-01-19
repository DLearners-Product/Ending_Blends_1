using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Stamping : MonoBehaviour
{
    public GameObject[] GA_Questions, GA_Stamps;
    public int I_Qcount;
    public Material M_Greyscale;
    bool B_CanClick,B_CanStamp;
    public GameObject G_Final,G_Stamp;
    public AudioSource AS_crt, AS_wrg;
    GameObject G_Selected;
    public Text TXT_Current, TXT_Max;
    public Button backButton, nextButton;
    // Start is called before the first frame update
    void Start()
    {
        I_Qcount = 0;
        TXT_Max.text = GA_Questions.Length.ToString();
        THI_ShowQuestion();
        G_Final.SetActive(false);
        backButton.gameObject.SetActive(false);
       
    }
    private void Update()
    {
        if(B_CanStamp)
        {
            G_Stamp.SetActive(true);
            Cursor.visible = false;
            Vector3 pos= Input.mousePosition;
            pos.z = G_Stamp.transform.position.z - Camera.main.transform.position.z;
            G_Stamp.transform.position = Camera.main.ScreenToWorldPoint(pos);
        }
        else
        {
            Cursor.visible = true;
            G_Stamp.SetActive(false);
        }
    }
    public void THI_ShowQuestion()
    {
        for (int i = 0; i < GA_Questions.Length; i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[I_Qcount].SetActive(true);
        GA_Questions[I_Qcount].transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
        for(int i=0;i<GA_Stamps.Length;i++)
        {
            GA_Stamps[i].GetComponent<Image>().material = M_Greyscale;
        }
        B_CanClick = true;
        int count = I_Qcount + 1;
        TXT_Current.text = count.ToString();
    }

    public void BUT_Selecting()
    {
        if(B_CanClick)
        {
            G_Selected = EventSystem.current.currentSelectedGameObject;
            if(G_Selected.name== GA_Questions[I_Qcount].name)
            {
                AS_crt.Play();
                G_Selected.GetComponent<Image>().material = null;
                B_CanStamp = true;
                B_CanClick = false;
            }
            else
            {
                AS_wrg.Play();
            }
        }
    }
    public void BUT_Clicking()
    {
        if (B_CanStamp)
        {
            AS_crt.Play();
            GA_Questions[I_Qcount].transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            B_CanStamp = false;
        }
    }
    public void BUT_Next()
    {
        if (I_Qcount < GA_Questions.Length - 1)
        {
            I_Qcount++;
            THI_ShowQuestion();
            BUT_Enabler();
        }
        else
        {
            G_Final.SetActive(true);
        }
    }

    public void BUT_Back()
    {
        if (I_Qcount > 0)
        {
            I_Qcount--;
            THI_ShowQuestion();
            BUT_Enabler();
        }
        else
        {
            G_Final.SetActive(true);
        }
    }

    public void BUT_Enabler()
    {
        if (I_Qcount == 0)
        {
            backButton.gameObject.SetActive(false);
        }
        else if (I_Qcount == GA_Questions.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            backButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);
        }
    }
}
