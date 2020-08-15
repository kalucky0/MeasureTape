#if UNITY_EDITOR
using UnityEngine;

[ExecuteInEditMode]
public class MeasureTape : MonoBehaviour
{
    public Color lineColor = Color.yellow;
    public bool initialized = false;
    public Vector3 startPoint = Vector3.zero;
    public Vector3 endPoint = new Vector3(0, 1, 0);
    public float distance;
    public float gizmoSize = 0.1f;
    public bool showCentimeters = true;
    public bool scaleToPixels = false;
    public int pixelsPerUnit = 128;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = this.lineColor;
        Gizmos.DrawCube(startPoint, new Vector3(gizmoSize, gizmoSize, gizmoSize));
        Gizmos.DrawCube(endPoint, new Vector3(gizmoSize, gizmoSize, gizmoSize));
        Gizmos.DrawLine(startPoint, endPoint);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = this.lineColor;
        Gizmos.DrawCube(startPoint, new Vector3(gizmoSize, gizmoSize, gizmoSize));
        Gizmos.DrawCube(endPoint, new Vector3(gizmoSize, gizmoSize, gizmoSize));
        Gizmos.DrawLine(startPoint, endPoint);
    }
}
#endif
