using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    private Vector3 mousePosition;
    private BoxCollider2D BoxColid;

    private bool GateOnRotate;
    private bool GateOnMove;

    void Start()
    {
        GateOnRotate = false;
        GateOnMove = true;
        BoxColid = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (GateOnMove)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
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
        
        if (!GateOnMove && !GateOnRotate)
        {
            Vector3 startPoint = new Vector3(transform.position.x + (BoxColid.size.x - BoxColid.offset.x) * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), transform.position.y + (BoxColid.size.y - BoxColid.offset.y) * Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad));

            RaycastHit2D Hit = Physics2D.Raycast(startPoint, transform.TransformDirection(Vector3.right), 10, LayerMask.GetMask("Player"));

            if(Hit)
            {
                Hit.collider.transform.position -= Vector3.Normalize(transform.TransformDirection(Vector3.right)) * Time.deltaTime;
            }

            Debug.DrawRay(startPoint, transform.TransformDirection(Vector3.right), Color.red, 10);
        }
    }
}
