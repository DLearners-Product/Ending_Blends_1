using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Choosesort : MonoBehaviour
{
    public GameObject[] GA_Questions;
    public int I_Qcount;
    public GameObject G_Final;
    bool B_CanClick;
    GameObject G_Selected;
    public AudioSource AS_crt, AS_wrg;
    public Text TXT_max, TXT_Current;
    public Button backButton;
    public Button nextButton;

    // Start is called before the first frame update
    void Start()
    {
        I_Qcount = 0;
        THI_ShowQuestion();
        TXT_max.text = GA_Questions.Length.ToString();
        G_Final.SetActive(false);
        backButton.gameObject.SetActive(false);
    }
    public void THI_ShowQuestion()
    {
        for (int i = 0; i < GA_Questions.Length; i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[I_Qcount].SetActive(true);
        B_CanClick = true;
        if (I_Qcount < 14)
        {
            GA_Questions[I_Qcount].transform.GetChild(2).gameObject.SetActive(false);
        }
        int count = I_Qcount + 1;
        TXT_Current.text = count.ToString();
    }
    public void BUT_Next()
    {
        if(I_Qcount<GA_Questions.Length-1)
        {
            I_Qcount++;
            THI_ShowQuestion();
            BUT_Enabler();
        }else
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
    public void BUT_Clicking()
    {
        if (B_CanClick)
        {
            G_Selected = EventSystem.current.currentSelectedGameObject;
            B_CanClick = false;
            if (G_Selected.tag == "answer")
            {
                AS_crt.Play();
                G_Selected.transform.GetChild(0).GetComponent<Image>().color = Color.green;
                GA_Questions[I_Qcount].transform.GetChild(2).gameObject.SetActive(true);
                GA_Questions[I_Qcount].transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                AS_wrg.Play();
                G_Selected.transform.GetChild(0).GetComponent<Image>().color = Color.red;
                Invoke("THI_off", 1f);
            }
        }

    }

    void THI_off()
    {
        G_Selected.transform.GetChild(0).GetComponent<Image>().color = Color.grey;
        B_CanClick = true;
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
