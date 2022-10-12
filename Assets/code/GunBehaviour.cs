using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    private Vector2 PositionObject = new Vector2(4, 0);

    private float count = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Program is strated");

        gameObject.transform.position = PositionObject;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        PositionObject.Set(4 * (float)Math.Cos(count), 4 * (float)Math.Sin(count));
        gameObject.transform.position = PositionObject;
    }
}
