#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeasureTape))]
public sealed class MeasureTapeEditor : Editor
{
    private MeasureTape _target;
    private readonly GUIStyle _style = new();

    private void OnEnable()
    {
        _style.fontStyle = FontStyle.Bold;
        _style.normal.textColor = Color.white;
        _target = (MeasureTape)target;

        if (!_target.initialized) _target.initialized = true;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.PrefixLabel("Gizmo radius");
        _target.gizmoSize = Mathf.Clamp(
            EditorGUILayout.Slider(
                _target.gizmoSize,
                0.1f, 3.0f,
                GUILayout.ExpandWidth(false)
            ), 0.1f, 100);

        EditorGUILayout.Separator();

        EditorGUILayout.PrefixLabel("Gizmo color");
        _target.lineColor = EditorGUILayout.ColorField(
            _target.lineColor,
            GUILayout.ExpandWidth(false)
        );

        EditorGUILayout.Separator();
        EditorGUILayout.Separator();

        _target.showCentimeters = EditorGUILayout.Toggle(
            "Show centimeters",
            _target.showCentimeters,
            GUILayout.ExpandWidth(false)
        );

        _target.scaleToPixels = EditorGUILayout.Toggle(
            "Show scale/pixel",
            _target.scaleToPixels,
            GUILayout.ExpandWidth(false)
        );

        _target.pixelsPerUnit = EditorGUILayout.IntField(
            "Pixels per unit",
            _target.pixelsPerUnit,
            GUILayout.ExpandWidth(false)
        );

        EditorGUILayout.EndVertical();

        if (GUI.changed) EditorUtility.SetDirty(_target);
    }

    private void OnSceneGUI()
    {
        Undo.RecordObject(_target, "measuretape undo");

        float distance = Vector3.Distance(_target.startPoint, _target.endPoint);
        float scalePerPixel = distance * _target.pixelsPerUnit;

        if (_target.showCentimeters)
        {
            float meters = Mathf.Floor(distance);
            float cmeters = (distance - meters) * 100;

            Handles.Label(
                _target.endPoint,
                _target.scaleToPixels
                    ? $"        Distance from start point: {meters}m {cmeters}cm - Scale per pixel: {scalePerPixel}px"
                    : $"        Distance from start point: {meters}m {cmeters}cm",
                _style
            );
        }
        else
        {
            Handles.Label(
                _target.endPoint,
                _target.scaleToPixels
                    ? $"        Distance from start point: {distance}m - Scale per pixel: {scalePerPixel}px"
                    : $"        Distance from start point: {distance}m",
                _style
            );
        }

        _target.startPoint = Handles.PositionHandle(_target.startPoint, Quaternion.identity);
        _target.endPoint = Handles.PositionHandle(_target.endPoint, Quaternion.identity);
    }
}
#endif