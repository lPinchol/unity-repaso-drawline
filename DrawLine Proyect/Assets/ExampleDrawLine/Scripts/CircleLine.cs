using System;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CircleLine : MonoBehaviour
{
    public Color color = Color.blue;
    public float radius = 10;
    public float resolution = 100;
    public bool startInOrigin = false;
    public bool endInOrigin = false;
    public bool drawEdges = false;
    public float fOVDegrees = 360;

    void Update()
    {
        DebugCreateCircle(transform.position, color, radius, resolution, startInOrigin, endInOrigin, drawEdges, fOVDegrees);
    }

    public void DebugCreateCircle(Vector3 origin, Color color, float radius = 5f, float resolution = 100f, bool startInOrigin = true, bool endInOrigin = false, bool drawEdges = false, float fOVDegrees = 360)
    {
        float circumference = 0;
        Quaternion rot_a = Quaternion.AngleAxis(-(circumference * 0.5f), transform.up);

        Vector3 startCorner = origin;
        Vector3 previousCorner = startCorner;

        for (int i = 0; i < resolution + 1; i++)
        {

            float fovAngle = fOVDegrees / 180;
            float cornerAngle = ((rot_a.eulerAngles.y + transform.eulerAngles.y) * Mathf.Deg2Rad) + (fovAngle * Mathf.PI / (float)resolution) * i;

            Vector3 currentCorner = new Vector3((Mathf.Sin(cornerAngle) * radius), 0, (Mathf.Cos(cornerAngle) * radius)) + origin;

            if (!(i == 0 && !startInOrigin)) Debug.DrawLine(currentCorner, previousCorner, color);

            if (drawEdges) Debug.DrawLine(origin, currentCorner, color);

            previousCorner = currentCorner;
        }
        if (endInOrigin) Debug.DrawLine(previousCorner, origin, color);
    }
}