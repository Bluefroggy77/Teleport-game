using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circileProject : MonoBehaviour
{
    [Range(0, 100)]
    public int seg = 100;
    [Range(0, 20)]
    public float xrad = 17.75f;
    [Range(0, 20)]
    public float yrad = 17.75f;
    LineRenderer line;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.SetVertexCount(seg + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }

    void CreatePoints()
    {
        float x;
        float y;

        float angle = 20f;

        for (int i = 0; i < (seg + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xrad;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yrad;

            line.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / seg);
        }
    }
}
