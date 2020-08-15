#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class MeasureTapeMenu : MonoBehaviour
{
    [MenuItem("GameObject/Create MeasureTape", false, 0)]
    static void CreateMeasureTape()
    {
        if (Selection.activeGameObject != null)
        {
            if (Selection.activeGameObject.name == "MeasureTape")
            {
                addNewMeasureTape(Selection.activeGameObject);
            }
            else
            {
                if (GameObject.Find("MeasureTape") != null)
                    EditorUtility.DisplayDialog("MeasureTape Warning", "Oops, You need to select a MeasureTape to add an additional copy of the tool.", "OK");
                else
                    createNewMeasureTape();
            }
        }
        else
        {
            if (GameObject.Find("MeasureTape") != null)
                addNewMeasureTape(GameObject.Find("MeasureTape"));
            else
                createNewMeasureTape();
        }
    }

    static void createNewMeasureTape()
    {
        GameObject go = new GameObject("MeasureTape");
        go.transform.position = Vector3.zero;
        go.AddComponent(typeof(MeasureTape));
    }

    static void addNewMeasureTape(GameObject go)
    {
        go.AddComponent(typeof(MeasureTape));
    }
}
#endif