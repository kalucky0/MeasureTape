using UnityEngine;

[ExecuteInEditMode]
public sealed class MeasureTape : MonoBehaviour
{
#if UNITY_EDITOR
    public Color lineColor = Color.yellow;
    public bool initialized;
    public Vector3 startPoint = Vector3.zero;
    public Vector3 endPoint = new(0, 1, 0);
    public float gizmoSize = 0.1f;
    public bool showCentimeters = true;
    public bool scaleToPixels;
    public int pixelsPerUnit = 128;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = lineColor;
        Gizmos.DrawCube(startPoint, new Vector3(gizmoSize, gizmoSize, gizmoSize));
        Gizmos.DrawCube(endPoint, new Vector3(gizmoSize, gizmoSize, gizmoSize));
        Gizmos.DrawLine(startPoint, endPoint);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;
        Gizmos.DrawCube(startPoint, new Vector3(gizmoSize, gizmoSize, gizmoSize));
        Gizmos.DrawCube(endPoint, new Vector3(gizmoSize, gizmoSize, gizmoSize));
        Gizmos.DrawLine(startPoint, endPoint);
    }
#endif
}
