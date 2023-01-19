using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public AudioSource AS_Empty;
    public AudioClip[] AC_Clips;
    int I_Qcount;
    public Text TXT_Current, TXT_Max;
    public GameObject G_Final;
    public Button backButton, nextButton;
    // Start is called before the first frame update
    void Start()
    {
        G_Final.SetActive(false);
        I_Qcount = 0;
        int count = I_Qcount + 1;
        TXT_Current.text = count.ToString();
        TXT_Max.text = AC_Clips.Length.ToString();
        backButton.gameObject.SetActive(false);
    }
    public void BUT_Next()
    {
        if(I_Qcount<AC_Clips.Length-1)
        {
            I_Qcount++;
            int count = I_Qcount + 1;
            TXT_Current.text = count.ToString();
            BUT_Enabler();
        }
        else
        {
            G_Final.SetActive(true);
        }
    }
    public void BUT_Back()
    {
        if (I_Qcount >0)
        {
            I_Qcount--;
            int count = I_Qcount + 1;
            TXT_Current.text = count.ToString();
            BUT_Enabler();
        }
        else
        {
            G_Final.SetActive(true);
        }
    }
    public void BUT_Speaker()
    {
        AS_Empty.clip = AC_Clips[I_Qcount];
        AS_Empty.Play();
    }
    // enabling back and next button during runtime
    public void BUT_Enabler()
    {
        if (I_Qcount == 0)
        {
            backButton.gameObject.SetActive(false);
        }
        else if (I_Qcount == AC_Clips.Length - 1)
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
