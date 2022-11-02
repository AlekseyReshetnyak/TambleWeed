using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    [SerializeField] private double Force;
    private Vector3 mousePosition;
    private BoxCollider BoxColid;
    private Animator anim;

    private bool GateOnRotate;
    private bool GateOnMove;

    void Start()
    {
        GateOnRotate = false;
        GateOnMove = true;
        BoxColid = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (GateOnMove)
        {
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
        
        if (GateOnRotate)
        {
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

    public void ActivateGun()
    {
        if (!GateOnMove && !GateOnRotate)
        {
            Vector3 startPoint = new Vector3(transform.position.x + (BoxColid.size.x - BoxColid.center.x) * Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), transform.position.y + (BoxColid.size.y - BoxColid.center.y) * Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad));

            Ray GunRay = new Ray(startPoint, transform.TransformDirection(Vector3.right));
            RaycastHit Hit;

            if(Physics.Raycast(GunRay, out Hit, 100, LayerMask.GetMask("Player")))
            {
                StartCoroutine(StartGunWork(Hit));
            }

            Debug.DrawRay(startPoint, transform.TransformDirection(Vector3.right), Color.red, 100);
        }
    }

    IEnumerator StartGunWork(RaycastHit Hit, int countFrame = 0)
    {
        anim.Play("GunWork");
        while (countFrame <= 120)
        {
            countFrame += 1;

            Hit.collider.transform.position -= Vector3.Normalize(transform.TransformDirection(Vector3.right)) * Time.deltaTime;
            yield return null;
        }
    }
}
