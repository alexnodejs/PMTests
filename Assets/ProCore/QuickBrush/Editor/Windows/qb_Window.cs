//	QuickBrush: Prefab Placement Tool
//	by PlayTangent
//	all rights reserved
//	www.ProCore3d.com

using UnityEngine;
using UnityEditor;
using System.Collections;

public class qb_Window : EditorWindow
{
	public static qb_Window window;

//	private bool builtStyles = false;
	private bool ranEnable = false;
	//private string dir;
	
	void OnEnable()
	{
		window = this;
		//GetDirectory();
		LoadTextures();
		BuildStyles();
		
		ranEnable = true;
	}
	
	public virtual void OnGUI()
	{
		
		if(ranEnable == false)
			OnEnable();
			
		//if(builtStyles == false)
			BuildStyles();
	}
	
	protected static void MenuListItem(bool bulleted, bool centered, string text)
	{
		EditorGUILayout.BeginHorizontal();
		
		if(bulleted)
			GUILayout.Label(bulletPointTexture,window.bulletPointStyle);
		
		if(centered)
			EditorGUILayout.LabelField(text,window.labelStyle_centered);
		
		else
			EditorGUILayout.LabelField(text,window.labelStyle);
		
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.Space();
	}
	
	protected static void MenuListItem(bool bulleted, string text)
	{
		MenuListItem(bulleted,false,text);
	}
	
	protected static void MenuListItem(string text)
	{
		MenuListItem(false, false, text);
	}

	protected static void LoadTextures()
	{
		window.DoLoadTextures();
	}
	protected virtual void DoLoadTextures()
	{
		string guiPath = qb_Utility.GetHeadDirectory() + "/Resources/Skin/";
		bulletPointTexture 	= AssetDatabase.LoadAssetAtPath(guiPath + "qb_bullet.tga", typeof(Texture2D)) as Texture2D;//Resources.LoadAssetAtPath(//guiPath + "qb_bullet.tga", typeof(Texture2D)) as Texture2D;
	}
	
#region Shared Textures
	static Texture2D bulletPointTexture;
#endregion
	
#region Shared Styles
	[SerializeField] protected GUIStyle labelStyle;
	[SerializeField] protected GUIStyle labelStyle_bold;
	[SerializeField] protected GUIStyle labelStyle_centered;
	[SerializeField] protected GUIStyle menuBlockStyle;
	[SerializeField] protected GUIStyle bulletPointStyle;
#endregion
	
    protected void BuildStyles()
    {
    	DoBuildStyles();
//		builtStyles = true;
	}
	protected virtual void DoBuildStyles()
	{
		labelStyle = new GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).label);
		labelStyle.alignment = TextAnchor.UpperLeft;
		labelStyle.wordWrap = true;
		labelStyle.padding.left = 0;
		labelStyle.margin.left = 0;
		
		labelStyle_bold = new GUIStyle(EditorStyles.boldLabel);
		
		labelStyle_centered = new GUIStyle(EditorStyles.label);
		labelStyle_centered.alignment = TextAnchor.UpperCenter;
		
		bulletPointStyle = new GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).label);
		bulletPointStyle.margin.right = 0;
		bulletPointStyle.margin.left = 0;
		bulletPointStyle.margin.top = 0;
		bulletPointStyle.margin.bottom = 0;
		bulletPointStyle.padding.right = 0;
		bulletPointStyle.padding.left = 0;
		bulletPointStyle.padding.top = 0;
		bulletPointStyle.padding.bottom = 0;
		
		menuBlockStyle = new GUIStyle(EditorStyles.textField);//GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).box);//new GUIStyle(EditorStyles.textField); //new GUIStyle(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Scene).textField);
		menuBlockStyle.alignment = TextAnchor.UpperLeft;
	}	

}
