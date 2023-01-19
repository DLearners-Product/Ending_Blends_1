using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phoneme : MonoBehaviour
{
    public static phoneme OBJ_phoneme;
    public GameObject[] GA_Questions;
    public int I_Qcount,I_count;
    public AudioSource AS_crt, AS_wrg,AS_Empty;
    public AudioClip[] AC_clips;
    public Text TXT_max, TXT_Current;
    public GameObject G_Final;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        OBJ_phoneme = this;
        I_Qcount = 0;
        THI_ShowQuestion();
        G_Final.SetActive(false);

        TXT_max.text = AC_clips.Length.ToString();
    }
    public void THI_ShowQuestion()
    {
        for(int i=0;i<GA_Questions.Length;i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[I_Qcount].SetActive(true);
        I_count = 4;
        for (int i=0;i< GA_Questions[I_Qcount].transform.GetChild(0).childCount;i++)
        {
            GA_Questions[I_Qcount].transform.GetChild(0)
                .transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
        }
        int count = I_Qcount + 1;
        TXT_Current.text = count.ToString();
    }
    public void BUT_Speaker()
    {
        AS_Empty.clip = AC_clips[I_Qcount];
        AS_Empty.Play();
    }
   
    public void BUT_Next()
    {
        if (I_Qcount < GA_Questions.Length - 1)
        {
            I_Qcount++;
            THI_ShowQuestion();
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
        }
        else
        {
            G_Final.SetActive(true);
        }
    }
    
    public void THI_Wrong()
    {
        AS_wrg.Play();
    }
    public void THI_Correct()
    {
        I_count--;
        AS_crt.Play();
       
    }
}
