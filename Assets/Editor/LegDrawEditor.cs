using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LegDrawer))]
public class LegDrawEditor : Editor
{
	public void OnSceneGUI()
	{
		var t = (target as LegDrawer);

		EditorGUI.BeginChangeCheck();
		Vector3 hip = Handles.PositionHandle(t.hip, Quaternion.identity);
		Vector3 foot = Handles.PositionHandle(t.foot, Quaternion.identity);
		if (EditorGUI.EndChangeCheck())
		{
			Undo.RecordObject(target, "Move point");
			t.foot = foot;
			t.hip = hip;
		}
	}
}