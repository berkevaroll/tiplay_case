using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryController : MonoBehaviour
{


    [Header("Objects")]
    public GameObject startPoint;
    public GameObject midPoint;
    public GameObject endPoint;
    public LineRenderer line;

    private float mouseX;
    private float mouseY;
    private float lastX;
    private float lastY;
    private void Start()
    {

    }
    private void Update()
    {



        if (Input.GetMouseButton(0))
        {

            lastX = Input.GetAxis("Mouse X");
            lastY = Input.GetAxis("Mouse Y");
            Vector3 myMid = midPoint.transform.position;
            Vector3 myEnd = endPoint.transform.position;
            midPoint.transform.position = new Vector3(myMid.x - lastY, myMid.y, myMid.z + lastX * 1.2f);
            endPoint.transform.position = new Vector3(myEnd.x - lastY, myEnd.y, myEnd.z + lastX * .6f);

        }
        //StartCoroutine(RenderArc());
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<ParabolaController>().FollowParabola();
        }

    }
    //private IEnumerator RenderArc()
    //{
    //    line.positionCount = resolution + 1;
    //    line.SetPositions(CalculateLineArray());
    //    yield return null;
    //}

    //private Vector3[] CalculateLineArray()
    //{
        
        
    //    Vector3[] lineArray = new Vector3[resolution + 1];
    //    for (int i = 0; i < lineArray.Length; i++)
    //    {
    //        var t = i / (float)lineArray.Length;
    //        lineArray[i] = CalculateLinePoint(t);
    //    }
    //    return lineArray;
    //}
    //private Vector3 CalculateLinePoint(float t)
    //{
    //    float z = velocity.z * t;
    //    float x = (velocity.x * t) - (g * Mathf.Pow(t, 2) / 2);
    //    return new Vector3((x + transform.position.x),transform.position.y ,(z +transform.position.z));

    //}
}
