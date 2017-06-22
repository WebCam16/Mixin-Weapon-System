using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(CallMixinActions))]
public class CallActionMixinsInspector : Editor {

    CallMixinActions callMixinAction;
    ReorderableList mixinList;

    float lineHeight;
    float lineHeightSpace;

    void OnEnable()
    {
        if(target == null)
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

            EditorGUI.LabelField(new Rect(rect.x, rect.y, rect.width, lineHeight), elementObj.FindProperty("Name").stringValue);

            SerializedProperty propertyIterator = elementObj.GetIterator();

            int i = 1;
            while(propertyIterator.NextVisible(true))
            {
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + (lineHeightSpace * i), rect.width, lineHeight), propertyIterator);
                i++;
            }
        };

        mixinList.elementHeightCallback = (int index) =>
        {
            float height = 0;

            SerializedProperty element = mixinList.serializedProperty.GetArrayElementAtIndex(index);

            SerializedObject elementObj = new SerializedObject(element.objectReferenceValue);

            SerializedProperty propertyIterator = elementObj.GetIterator();

            int i = 1;
            while (propertyIterator.NextVisible(true))
            {
                i++;
            }

            height = lineHeightSpace * i;

            return height;
        };


    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        mixinList.DoLayoutList();
    }

}
