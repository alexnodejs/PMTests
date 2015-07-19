//	QuickBrush: Prefab Placement Tool
//	by PlayTangent
//	all rights reserved
//	www.ProCore3d.com

using UnityEngine;
using UnityEditor;
using System.Collections;

public class qb_About : qb_Window
{
	[MenuItem ("Tools/QuickBrush/About")]
	public static void ShowWindow()
	{
		window = EditorWindow.GetWindow<qb_About>(false,"QB About");

	 	window.position = new Rect(50,50,284,200);
		window.minSize = new Vector2(284f,100f);
		window.maxSize = new Vector2(284f,140f);
	}
	
	public const string RELEASE_VERSION = "1.1.1e";
	const string BUILD_DATE = "6-24-2015";
	static Texture2D bulletPointTexture;
	
	public override void OnGUI()
	{
		base.OnGUI();
		
		EditorGUILayout.Space();

		EditorGUILayout.BeginVertical();
			
			MenuListItem(false,true,"QuickBrush " + RELEASE_VERSION);
			
			EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("Version Number:");
				EditorGUILayout.LabelField(RELEASE_VERSION);
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("Build Date:");
				EditorGUILayout.LabelField(BUILD_DATE);
			EditorGUILayout.EndHorizontal();
				
		EditorGUILayout.EndVertical();
	}
	

}