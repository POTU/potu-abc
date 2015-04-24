using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(SubUIMaster))]
public class SubUiMasterEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		if (Application.isPlaying)
		{
			SubUIMaster controller = (SubUIMaster)target;
			MethodInfo[] methodInfos = typeof(SubUIMaster).GetMethods(
				BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance
			);
			foreach (MethodInfo methodInfo in methodInfos)
			{
				if (GUILayout.Button(methodInfo.Name))
				{
					methodInfo.Invoke(controller, null);
				}
			}
		}
	}
}
