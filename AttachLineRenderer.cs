using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttachLineRenderer : MonoBehaviour
{
    LineRenderer line;
    CapsuleCollider capsule;

    //public float LineWidth; // use the same as you set in the line renderer.

    void Start()
    {
        line = GetComponent<LineRenderer>();
        capsule = gameObject.AddComponent<CapsuleCollider>();
        capsule.radius = line.startWidth / 2;
        capsule.center = Vector3.zero;
        capsule.direction = 2; // Z-axis for easier "LookAt" orientation
    }

    void Update()
    {
        Vector3 start = line.GetPosition(0);
        Vector3 target = line.GetPosition(1);
        
        capsule.transform.position = start + (target - start) / 2;
        capsule.transform.LookAt(start);
        capsule.height = (target - start).magnitude;
    }
}