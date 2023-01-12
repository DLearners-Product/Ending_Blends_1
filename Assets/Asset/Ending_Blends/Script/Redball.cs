using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Redball : MonoBehaviour, IDragHandler, IEndDragHandler
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
        if (otherGameObject != null)
        {
            if (this.gameObject.name == otherGameObject.name)
            {
                phoneme.OBJ_phoneme.THI_Correct();
                otherGameObject.transform.GetChild(0).gameObject.SetActive(true);
                otherGameObject.GetComponent<Collider2D>().enabled = false;
                this.GetComponent<Redball>().enabled = false;
                this.gameObject.SetActive(false);
            }
            else
            {
                phoneme.OBJ_phoneme.THI_Wrong();
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
        if (other.transform.parent.name == "drop")
            otherGameObject = other.gameObject;
        //Debug.Log("Stay :" + otherGameObject.name);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.parent.name == "drop")
            otherGameObject = null;


    }
}
