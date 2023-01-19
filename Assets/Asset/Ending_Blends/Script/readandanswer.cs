using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readandanswer : MonoBehaviour
{
    public GameObject[] GA_Questions;
    public int I_Qcount;
    public GameObject G_Final;
    public Button backButton, nextButton;
    // Start is called before the first frame update
    void Start()
    {
        I_Qcount = 0;
        THI_ShowQuestion();
        G_Final.SetActive(false);
        backButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void THI_ShowQuestion()
    {
        for (int i = 0; i < GA_Questions.Length; i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[I_Qcount].SetActive(true);

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
