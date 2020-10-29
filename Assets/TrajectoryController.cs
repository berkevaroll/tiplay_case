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

    private Vector3 worldPosition;
    private void Start()
    {
        g = Mathf.Abs(Physics.gravity.y);
    }
    private void Update()
    {
        StartCoroutine(RenderArc());
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        
        if (Input.GetMouseButton(0))
        {
            Vector3 lastPos = Input.mousePosition;
            lastPos.z = Camera.main.nearClipPlane;
            Vector3 delta = Vector3.zero;
            worldPosition = Camera.main.ScreenToWorldPoint(delta);
            velocity.x += worldPosition.x * Time.deltaTime;
            velocity.z += worldPosition.y * Time.deltaTime;
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
