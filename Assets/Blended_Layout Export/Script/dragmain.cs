using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dragmain : MonoBehaviour
{
    public static dragmain OBJ_dragmain;
   // public GameObject[] GA_Questions;
    public int I_Anscount;
    //public GameObject G_Final,G_Words;
    public GameObject[] GA_Options;
    int I_count;
   //public GameObject G_oldnext, G_final;
    public AudioSource AS_crt, AS_wrg;

    private void Awake()
    {
        OBJ_dragmain = this;
    }

    public void Start()
    {
       // OBJ_dragmain = this;
        // I_Qcount = -1;
        // G_oldnext.SetActive(false);
       // G_Final.SetActive(false);
        
        showquestion();
    }
    public void showquestion()
    {

       for(int i=0;i<GA_Options.Length; i++)
        {
            GA_Options[i].transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
            GA_Options[i].transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
        }
        
       
        
    }

    public void THI_correct()
    {
        
        AS_crt.Play();


    }
    public void THI_wrg()
    {
        AS_wrg.Play();
    }
    
   
   

    
}
