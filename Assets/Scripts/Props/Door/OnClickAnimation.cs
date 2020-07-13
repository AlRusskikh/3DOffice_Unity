using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickAnimation : MonoBehaviour
{
    void Operate()
    {   
        StartCoroutine(Open());
        IEnumerator Open()
        {
            
            transform.Rotate(0, 90, 0);
            yield return new WaitForSeconds(1.5f);
            transform.Rotate(0, -90, 0);
        }     
    }
    void OnMouseDown()
    {
        Operate();
    }

    
}
