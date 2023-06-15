using UnityEditor;
using UnityEngine;

namespace WasderGQ.Sudoku.Utility
{
    public class LockVariableOnEditor : PropertyAttribute
    {
    }    
    #if UNITY_EDITOR
    
    [CustomPropertyDrawer(typeof(LockVariableOnEditor))]
    public class LockVariable : PropertyDrawer
    {
        public override void OnGUI(Rect location, SerializedProperty property, GUIContent line)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(location, property, line, true);
            GUI.enabled = true;
        }
    }
    #endif
    


    
}
