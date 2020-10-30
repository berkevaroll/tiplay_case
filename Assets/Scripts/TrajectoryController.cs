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

    private float lastX;
    private float lastY;
    private float maxZ;
    private float maxX;
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
            Vector3 myStart = startPoint.transform.position;
            maxZ = myMid.z + lastX * .4f;
            maxX = myEnd.x - lastY;
            if (maxZ < -2.5f)
            {
                maxZ = -2.5f;
            }else if(maxZ > 2.5f)
            {
                maxZ = 2.5f;
            }
            if (maxX > 10f)
            {
                maxX = 10f;
            }else if(maxX < .5f)
            {
                maxX = .5f;
            }
            endPoint.transform.position = new Vector3(maxX, myEnd.y, midPoint.transform.position.z/2);
            midPoint.transform.position = new Vector3((endPoint.transform.position.x - startPoint.transform.position.x)/2, myMid.y, maxZ);
            
            

        }
        //StartCoroutine(RenderArc());
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<ParabolaController>().line.enabled = false;
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
