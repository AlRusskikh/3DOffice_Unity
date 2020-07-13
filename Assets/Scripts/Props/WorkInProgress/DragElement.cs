using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField] private Image mainImage;


    private Transform defaultParentTransform;
    public Transform DefaultParentTransform
    {
        get { return defaultParentTransform; }
        set
        {
            if (value != null)
            {
                defaultParentTransform = value;
            }
        }
    }

    private Transform dragParentTransform;
    public Transform DragParentTransform
    {
        get
        {
            return dragParentTransform;
        }
        set
        {
            if (value != null)
                dragParentTransform = value;
        }
    }


    private int siblingIndex;
    public int SiblingIndex
    {
        get { return siblingIndex; }
        set
        {
            if (value > 0)
                siblingIndex = value;
        }
    }

    public GameObject dragObject { get; internal set; }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(DragParentTransform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, 1));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(DefaultParentTransform);
        transform.SetSiblingIndex(SiblingIndex);

        //создаем луч и хит
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            //AvatarTarget.hit.collider.gameObject.transform.position;
            hit.collider.gameObject.SetActive(false);
         // Instantiate(brandNewProps, transform.position, Quaternion.identity);
        }

        
    }
}
