using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ObjSpawn;

    private Collider2D ObjForm;
    private Vector2 MousePosition;
    
    void Start()
    {
        ObjForm = GetComponent<Collider2D>();
    }

    
    void Update()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetButtonDown("Fire1") && ObjForm.OverlapPoint(MousePosition))
        {
            Instantiate(ObjSpawn, new Vector3(MousePosition.x, MousePosition.y, 0), Quaternion.Euler(0, 0, 90));
        }
    }
}
