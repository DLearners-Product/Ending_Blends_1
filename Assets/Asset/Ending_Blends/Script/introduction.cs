using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class introduction : MonoBehaviour
{
    public GameObject G_Mainmenu, G_Back, G_Next;
    public GameObject[] GA_slides;
    public int I_SubCount;
    public int level,I_lastcount;
    GameObject G_Bubble, G_Last;
    // Start is called before the first frame update
    void Start()
    {
       
        BUT_Mainmenu();
    }
    public void THI_Thumbnail(int index)
    {
        level = index;
        G_Mainmenu.SetActive(false);
        G_Back.GetComponent<Button>().interactable = true;
        G_Next.GetComponent<Button>().interactable = true;
        for (int i = 0; i < GA_slides.Length; i++)
        {
            GA_slides[i].SetActive(false);
        }
        GA_slides[level].SetActive(true);
        I_SubCount = 0;
        THI_subSlides();
    }
    public void THI_subSlides()
    {
        for (int i = 0; i < GA_slides[level].transform.childCount; i++)
        {
            GA_slides[level].transform.GetChild(i).gameObject.SetActive(false);
        }
        GA_slides[level].transform.GetChild(I_SubCount).gameObject.SetActive(true);
        if (I_SubCount == 4)
        {
            I_lastcount = -1;
            G_Last = GA_slides[level].transform.GetChild(I_SubCount).transform.GetChild(1).gameObject;
            for (int i = 0; i < G_Last.transform.childCount; i++)
            {
                G_Last.transform.GetChild(i).gameObject.SetActive(false);
            }
           // if (I_lastcount < G_Last.transform.childCount-1)
           // {
                Invoke("THI_Lastslide", 1f);
           // }
           // else
           // {
           //     Invoke("THI_Menu", 1f);
           // }

        }
    }
    public void THI_Lastslide()
    {
        //G_Bubble = GA_slides[level].transform.GetChild(I_SubCount).transform.GetChild(1).transform.GetChild(0).gameObject;

        if(I_lastcount<G_Last.transform.childCount)
        {
            // Debug.Log("last =" + G_Last);
            for (int i = 0; i < G_Last.transform.childCount; i++)
            {
                G_Last.transform.GetChild(i).gameObject.SetActive(false);
            }
            G_Last.transform.GetChild(I_lastcount).gameObject.SetActive(true);
           /* G_Last.transform.GetChild(I_lastcount).transform.GetChild(0).gameObject.SetActive(true);
            G_Last.transform.GetChild(I_lastcount).transform.GetChild(1).gameObject.SetActive(false);*/
        }
       else
       {
            THI_Menu();
            //Invoke("THI_Menu", 1f);
       }
        
    }
    public void THI_Menu()
    {
        G_Mainmenu.SetActive(true);
        for (int i = 0; i < GA_slides.Length; i++)
        {
            GA_slides[i].SetActive(false);
        }
    }

    public void BUT_WorkClicking()
    {
        
       // G_Bubble.GetComponent<Animator>().SetInteger("Cond", 1);
       // G_Last.transform.GetChild(I_lastcount).transform.GetChild(0).gameObject.SetActive(false);
       // Invoke("Invoke", 1.5f);
    }

    public void Invoke()
    {
      //  G_Last.transform.GetChild(I_lastcount).transform.GetChild(1).gameObject.SetActive(true);
    }
    public void BUT_individual()
    {
        /*GameObject G_Individual = EventSystem.current.currentSelectedGameObject;
        if(G_Individual.tag=="answer")
        {
            G_Bubble.GetComponent<Animator>().enabled = false;
            G_Bubble.SetActive(false);
            G_Last.transform.GetChild(I_lastcount).transform.GetChild(1).gameObject.SetActive(false);
        }*/
    }
    public void BUT_Next()
    {
        if(I_SubCount<GA_slides[level].transform.childCount-1)
        {
            I_SubCount++;
            G_Back.GetComponent<Button>().interactable = true;
            THI_subSlides();
            
        }
        if(I_SubCount==4)
        {
            G_Back.GetComponent<Button>().interactable = false;
           /* if(G_Bubble!=null)
            {
                G_Bubble.SetActive(true);
                G_Bubble.GetComponent<Animator>().enabled = true;
                G_Bubble.GetComponent<Animator>().SetInteger("Cond", 0);
            }*/
            I_lastcount++;
            THI_Lastslide();
           // Invoke("THI_Lastslide", 1.5f);
        }
        
    }

    public void BUT_Bubble_combine()
    {
        Animator Anim = EventSystem.current.currentSelectedGameObject.transform.parent.GetComponent<Animator>();
        Anim.SetInteger("Cond", 1);
    }
    public void BUT_Back()
    {
        if (I_SubCount > 0)
        {
            I_SubCount--;
            THI_subSlides();
        }
    }
    public void BUT_Mainmenu()
    {
        G_Mainmenu.SetActive(true);
        G_Back.GetComponent<Button>().interactable = false;
        G_Next.GetComponent<Button>().interactable = false;
        for (int i = 0; i < GA_slides.Length; i++)
        {
            GA_slides[i].SetActive(false);
        }
    }

}
