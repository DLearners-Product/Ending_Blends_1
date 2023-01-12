using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector2 mousePos;
    public Vector2 initalPos;

    bool isdrag;
    GameObject otherGameObject;

    Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void Start()
    {
        //initalPos = this.GetComponent<RectTransform>().position;
        initalPos = this.transform.position;
    }


    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePos;

       // Debug.Log("Drag");
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End Drag"  + otherGameObject.name);
        if(otherGameObject!=null)
        {
            if (this.gameObject.name.Contains(otherGameObject.name))
            {
                Debug.Log("contains " + otherGameObject.name);
                dragmain.OBJ_dragmain.THI_correct();
                otherGameObject.transform.GetChild(0).gameObject.SetActive(true);
                for(int i=0;i<otherGameObject.transform.childCount;i++)
                {
                    if(this.gameObject.name==otherGameObject.transform.GetChild(i).name)
                    {
                        Debug.Log("contains1 == " + otherGameObject.transform.GetChild(i).name);
                        otherGameObject.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
               // otherGameObject.GetComponent<Collider2D>().enabled = false;
                this.GetComponent<drag>().enabled = false; 
                this.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("contains " + otherGameObject.name);
                dragmain.OBJ_dragmain.THI_wrg();
                this.transform.position = initalPos;
            }
        }
        else
        {
            this.transform.position = initalPos;
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.parent.name == "options")
            otherGameObject = other.gameObject;
        //Debug.Log("Stay :" + otherGameObject.name);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.parent.name == "options")
            otherGameObject = null;
        

    }

}
