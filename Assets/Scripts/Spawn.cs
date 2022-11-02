using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ObjSpawn;
    private Vector2 MousePosition;
    
    void Start()
    {
        
    }

    
    void Update()
    {

    }

    public void SpawnNewObject()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Instantiate(ObjSpawn, new Vector3(MousePosition.x, MousePosition.y, 0), Quaternion.Euler(0, 0, 90));
    }
}
