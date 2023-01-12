using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class magicshow : MonoBehaviour
{
    public GameObject[] GA_Questions;
    public int I_Qcount;
    public GameObject G_Final,G_magician;
    public Text TXT_max, TXT_Current;
    // Start is called before the first frame update
    void Start()
    {
        I_Qcount = 0;
        THI_ShowQuestion();
        G_Final.SetActive(false);
        TXT_max.text = GA_Questions.Length.ToString();
    }

    public void THI_ShowQuestion()
    {
        for (int i = 0; i < GA_Questions.Length; i++)
        {
            GA_Questions[i].SetActive(false);
        }
        GA_Questions[I_Qcount].SetActive(true);
        int count = I_Qcount + 1;
        TXT_Current.text = count.ToString();
    }
    public void BUT_Next()
    {
        if (I_Qcount < GA_Questions.Length - 1)
        {
            G_magician.GetComponent<Animator>().SetInteger("Cond", 0);
            I_Qcount++;
            THI_ShowQuestion();
        }
        else
        {
            G_Final.SetActive(true);
        }
    }
    public void BUT_PlayAnim()
    {
        G_magician.GetComponent<Animator>().SetInteger("Cond",I_Qcount + 1);
    }
    public void BUT_Back()
    {
        if (I_Qcount > 0)
        {
            G_magician.GetComponent<Animator>().SetInteger("Cond", 0);
            I_Qcount--;
            THI_ShowQuestion();
        }
        else
        {
            G_Final.SetActive(true);
        }
    }
}
