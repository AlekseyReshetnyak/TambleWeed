using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    private Vector3 mousePosition;

    private bool GateOnRotate;
    private bool GateOnMove;

    void Start()
    {
        GateOnRotate = false;
        GateOnMove = true;
    }


    void Update()
    {
        if (GateOnMove)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);

            Debug.Log(transform.position);
        }
        
        if (GateOnRotate)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 difference = mousePosition - transform.position; 
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
            transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
        };

        if(Input.GetButtonDown("Fire1") && GateOnRotate)
        {
            GateOnRotate = false;
        }
        
        if(Input.GetButtonDown("Fire1") && GateOnMove)
        {
            GateOnRotate = true;
            GateOnMove = false;
        }
    }
}
