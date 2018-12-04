using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float NeighbourRadius = 3.0f;
    public float radius = 1;
    public Vector3 regionSize = Vector3.one;
    public int rejectionSamples = 30;
    public float displayRadius = 1;

    [HideInInspector]
    public List<Vector3> points;

    void OnValidate()
    {
        points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube((regionSize / 2) + transform.position, regionSize);
        if (points != null)
        {
            foreach (Vector3 point in points)
            {
                Gizmos.DrawSphere(point + transform.position, displayRadius);
                for (int i = 0; i < points.Count; i++)
                {
                    if(point != points[i])
                    {
                        if(Vector3.Distance(point, points[i]) <= NeighbourRadius)
                        {
                            Gizmos.DrawLine(point, points[i]);
                        }
                    }
                }
            }
        }
    }
}