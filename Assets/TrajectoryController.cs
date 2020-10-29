using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryController : MonoBehaviour
{
    [Header("Line renderer variables")]
    public LineRenderer line;
    public int resolution;

    [Header("Physics variables")]
    public Vector3 velocity;
    public float yLimit;
    public float g;

    private float mouseX;
    private float mouseY;
    private float lastX;
    private float lastY;
    private void Start()
    {
        g = Mathf.Abs(Physics.gravity.y);

    }
    private void Update()
    {
        StartCoroutine(RenderArc());
        

        if (Input.GetMouseButton(0))
        {
            lastX = Input.GetAxis("Mouse X");
            lastY = Input.GetAxis("Mouse Y");
            velocity.x += -lastX  * .8f;
            velocity.z += -lastY * 2f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //ball movement
        }

    }
    private IEnumerator RenderArc()
    {
        line.positionCount = resolution + 1;
        line.SetPositions(CalculateLineArray());
        yield return null;
    }

    private Vector3[] CalculateLineArray()
    {
        
        
        Vector3[] lineArray = new Vector3[resolution + 1];
        for (int i = 0; i < lineArray.Length; i++)
        {
            var t = i / (float)lineArray.Length;
            lineArray[i] = CalculateLinePoint(t);
        }
        return lineArray;
    }
    private Vector3 CalculateLinePoint(float t)
    {
        float z = velocity.z * t;
        float x = (velocity.x * t) - (g * Mathf.Pow(t, 2) / 2);
        return new Vector3((x + transform.position.x),transform.position.y ,(z +transform.position.z));

    }
}
