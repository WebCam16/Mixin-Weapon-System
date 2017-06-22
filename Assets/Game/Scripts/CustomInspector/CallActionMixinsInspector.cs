using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(CallMixinActions))]
public class CallActionMixinsInspector : Editor
{

    CallMixinActions callMixinAction;
    ReorderableList mixinList;

    float lineHeight;
    float lineHeightSpace;

    void OnEnable()
    {
        if (target == null)
        {
            return;
        }

        lineHeight = EditorGUIUtility.singleLineHeight;
        lineHeightSpace = lineHeight + 10;

        callMixinAction = (CallMixinActions)target;

        mixinList = new ReorderableList(serializedObject, serializedObject.FindProperty("actionsMixins"), true, true, true, true);

        mixinList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            SerializedProperty element = mixinList.serializedProperty.GetArrayElementAtIndex(index);

            SerializedObject elementObj = new SerializedObject(element.objectReferenceValue);
            elementObj.Update();
            EditorGUI.LabelField(new Rect(rect.x, rect.y, rect.width - 80, lineHeight), elementObj.FindProperty("Name").stringValue);
            EditorGUIUtility.labelWidth = 70;
            EditorGUI.PropertyField(new Rect(rect.width - 80, rect.y, 80, lineHeight), elementObj.FindProperty("showMixin"));
            EditorGUIUtility.labelWidth = 0;
            elementObj.FindProperty("showInfo").boolValue = EditorGUI.Foldout(new Rect(rect.x, rect.y + lineHeightSpace, rect.width, lineHeight), elementObj.FindProperty("showInfo").boolValue, new GUIContent("Info"));

            if (elementObj.FindProperty("showInfo").boolValue)
            {
                EditorGUI.ObjectField(new Rect(rect.x, rect.y + (lineHeightSpace * 2), rect.width, lineHeight), element, new GUIContent("Object"));

                SerializedProperty propertyIterator = elementObj.GetIterator();

                int i = 3;
                bool showChildren = true;
                while (propertyIterator.NextVisible(showChildren))
                {
                    EditorGUI.PropertyField(new Rect(rect.x, rect.y + (lineHeightSpace * i), rect.width, lineHeight), propertyIterator);
                    i++;
                    if (propertyIterator.isArray)
                    {
                        showChildren = propertyIterator.isExpanded;
                    }

                }
            }
            elementObj.ApplyModifiedProperties();

        };

        mixinList.elementHeightCallback = (int index) =>
        {
            int i = 2;
            float height = 0;
            SerializedProperty element = mixinList.serializedProperty.GetArrayElementAtIndex(index);

            SerializedObject elementObj = new SerializedObject(element.objectReferenceValue);
            if (elementObj.FindProperty("showInfo").boolValue)
            {

                i++;
                elementObj.Update();
                SerializedProperty propertyIterator = elementObj.GetIterator();

                
                bool showChildren = true;
                while (propertyIterator.NextVisible(showChildren))
                {
                    i++;
                    if (propertyIterator.isArray)
                    {
                        showChildren = propertyIterator.isExpanded;
                    }
                }
            }
            height = lineHeightSpace * i;

            return height;
        };


    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        mixinList.DoLayoutList();

        for(int i = 0; i <callMixinAction.actionsMixins.Count; i++)
        {
            if(!callMixinAction.actionsMixins[i].showMixin && callMixinAction.actionsMixins[i].hideFlags == HideFlags.None)
            {
                callMixinAction.actionsMixins[i].hideFlags = HideFlags.HideInInspector;
            }
            else if(callMixinAction.actionsMixins[i].showMixin && callMixinAction.actionsMixins[i].hideFlags == HideFlags.HideInInspector)
            {
                callMixinAction.actionsMixins[i].hideFlags = HideFlags.None;
            }
        }

    }

}
