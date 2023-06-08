using UnityEngine;
using UnityEditor;

public sealed class MeasureTapeMenu : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("GameObject/Create MeasureTape", false, 0)]
    private static void CreateMeasureTape()
    {
        if (Selection.activeGameObject != null)
        {
            if (Selection.activeGameObject.name == "MeasureTape")
            {
                AddNewMeasureTape(Selection.activeGameObject);
            }
            else
            {
                if (GameObject.Find("MeasureTape") != null)
                    EditorUtility.DisplayDialog(
                        "MeasureTape Warning",
                        "Oops, You need to select a MeasureTape to add an additional copy of the tool.",
                        "OK"
                    );
                else
                    CreateNewMeasureTape();
            }
        }
        else
        {
            if (GameObject.Find("MeasureTape") != null)
                AddNewMeasureTape(GameObject.Find("MeasureTape"));
            else
                CreateNewMeasureTape();
        }
    }

    private static void CreateNewMeasureTape()
    {
        var go = new GameObject("MeasureTape");
        go.transform.position = Vector3.zero;
        go.AddComponent(typeof(MeasureTape));
    }

    private static void AddNewMeasureTape(GameObject go)
    {
        go.AddComponent(typeof(MeasureTape));
    }
#endif
}