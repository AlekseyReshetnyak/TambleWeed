using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRay : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Ray MouseRay = new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            RaycastHit MouseHit;

            if (Physics.Raycast(MouseRay, out MouseHit))
            {
                if (MouseHit.collider.gameObject.layer == 7)
                {
                    GunLogic gun = MouseHit.collider.GetComponent<GunLogic>();

                    gun.ActivateGun();
                }

                if (MouseHit.collider.gameObject.layer == 8)
                {
                    Spawn newSpawner = MouseHit.collider.GetComponent<Spawn>();

                    newSpawner.SpawnNewObject();
                }
            }

            Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward * 30, Color.cyan, 30);
        }
    }
}
