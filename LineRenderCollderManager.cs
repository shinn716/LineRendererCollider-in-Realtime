using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LineRenderCollderManager : MonoBehaviour
{   
    public struct LRCol
    {
        public Vector3 start;
        public Vector3 end;
    }

    LRCol[] LRlist;
    LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        LRlist = new LRCol[line.numPositions - 1];

        StartCoroutine(Init());
    }

    private IEnumerator Init()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < line.numPositions - 1; i++)
        {
            LRlist[i].start = line.GetPosition(i);
            LRlist[i].end = line.GetPosition(i + 1);

            GameObject LRChild = new GameObject();
            LRChild.name = "LRChild" + (i + 1);
            LRChild.transform.SetParent(transform);

            LRChild.AddComponent<LineRenderer>();

            LineRenderer linec = LRChild.GetComponent<LineRenderer>();
            linec.numPositions = 2;
            linec.SetPosition(0, LRlist[i].start);
            linec.SetPosition(1, LRlist[i].end);
            linec.enabled = false;
            linec.gameObject.AddComponent<AttachLineRenderer>();
        }
    }
}
