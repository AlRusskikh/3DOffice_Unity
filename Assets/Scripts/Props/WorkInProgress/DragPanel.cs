using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPanel : MonoBehaviour
{
    private GameObject currentProps;

    [Tooltip("Ссылка на префаб драгуемого элемента")]
    [SerializeField] private GameObject dragPrefab;

    [Tooltip("Ссылка на Content ScrollView")]
    [SerializeField] private Transform scrollViewContent;

    [Tooltip("Материалы для перекраски объектов")]
    public List<GameObject> newProps;

    private void Start()
    {

        for (int i = 0; i < newProps.Count; ++i)
        {
            var dragObject = Instantiate(dragPrefab, scrollViewContent);
            var script = dragObject.GetComponent<DragElement>();

            script.dragObject = newProps[i];
            script.DefaultParentTransform = scrollViewContent;
            script.DragParentTransform = transform;
            script.SiblingIndex = i;
            //newProps[i] = createdProps; 
        }
        
    }
}
