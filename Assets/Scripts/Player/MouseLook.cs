using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }
    [SerializeField] private RotationAxes axes = RotationAxes.MouseXandY;
    [SerializeField] private float sensitivityHor = 9f;
    [SerializeField] private float sensitivityVert = 9f;
    [SerializeField] private float mimmumVert = -45f;
    [SerializeField] private float maximmumVert = 45f;
    [SerializeField] private float rotationX = 0;


    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.freezeRotation = true;
    }

   
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            rotationX = Mathf.Clamp(rotationX, mimmumVert, maximmumVert);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
        else
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            rotationX = Mathf.Clamp(rotationX, mimmumVert, maximmumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
