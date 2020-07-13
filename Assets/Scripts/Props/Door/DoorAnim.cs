using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    private Animator doorAnimation;
    private Color normalColor;
    private GameObject door;
    Material doorMaterial;




    private void ColorChange()   
    {
        normalColor = GetComponent<Renderer>().material.color;
        doorMaterial = GetComponent<Renderer>().material;
        print("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
        doorMaterial.color = Color.red;
    }

    private void SetNormalColor()
    {
            
        doorMaterial.color = normalColor;
    }
    

    void OnTriggerEnter(Collider coll)
    {
        if (gameObject.tag == "Red")
        {
            ColorChange();
        }
        else
        {
            doorAnimation.SetBool("isOpen", true);
        }    
    }
    void OnTriggerExit(Collider coll)
    {       

        if (gameObject.tag == "Red")
        {
            SetNormalColor();
        }
        else
        {
            doorAnimation.SetBool("isOpen", false);
        }
    }

    void Start()
    {  
        doorAnimation = GetComponent<Animator>();
    }

    

}
