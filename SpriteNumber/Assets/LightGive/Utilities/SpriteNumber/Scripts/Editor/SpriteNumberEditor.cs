using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpriteNumber))]
public class SpriteNumberEditor : Editor
{
	private SerializedProperty m_defaultTextAnchorProp;
	private SerializedProperty m_maxDigitProp;
	private SerializedProperty m_spriteSizeProp;
	private SerializedProperty m_offsetProp;
	private SerializedProperty m_isDisplayZeroProp;

	private void OnEnable()
	{
		m_defaultTextAnchorProp = serializedObject.FindProperty("m_defaultTextAnchor");
		m_maxDigitProp = serializedObject.FindProperty("m_maxDigit");
		m_spriteSizeProp = serializedObject.FindProperty("m_spriteSize");
		m_offsetProp = serializedObject.FindProperty("m_offset");
		m_isDisplayZeroProp = serializedObject.FindProperty("m_isDisplayZero");
	}


	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.Space();
		EditorGUILayout.LabelField("テキストの配置");
		EditorGUILayout.BeginHorizontal();
		{
			if (GUILayout.Toggle(m_defaultTextAnchorProp.enumValueIndex == 0, "左揃え", EditorStyles.miniButtonLeft))
			{
				m_defaultTextAnchorProp.enumValueIndex = 0;
			}
			if (GUILayout.Toggle(m_defaultTextAnchorProp.enumValueIndex == 1, "中央揃え", EditorStyles.miniButtonMid))
			{
				m_defaultTextAnchorProp.enumValueIndex = 1;
			}
			if (GUILayout.Toggle(m_defaultTextAnchorProp.enumValueIndex == 2, "右揃え", EditorStyles.miniButtonRight))
			{
				m_defaultTextAnchorProp.enumValueIndex = 2;
			}
		}
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.PropertyField(m_isDisplayZeroProp, new GUIContent("ゼロを表示するか"));
		EditorGUILayout.PropertyField(m_maxDigitProp, new GUIContent("最大桁数"));
		EditorGUILayout.PropertyField(m_spriteSizeProp, new GUIContent("スプライトのサイズ"));
		EditorGUILayout.PropertyField(m_offsetProp, new GUIContent("スプライトの間隔"));

		serializedObject.ApplyModifiedProperties();
	}
}