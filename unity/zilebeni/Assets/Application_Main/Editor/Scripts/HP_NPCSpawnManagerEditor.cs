#if UNITY_EDITOR

namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEditorInternal;
    using UnityEngine;
    using Runtime.Scripts.Patterns.MMVCC.Controllers;
    
    [CustomEditor(typeof(HP_NPCSpawnController)), CanEditMultipleObjects]
    public class HP_NPCSpawnManagerEditor : Editor
    {
        #region Variables

        #region Protected Variables

        protected SerializedProperty npcsIds;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void OnEnable()
        {
            Setup();
        }

        protected void Setup()
        {
            SetupNpcsIds();
        }
        protected void Show()
        {
            EditorGUILayout.LabelField(new GUIContent("NPCs", "Lists all npcs in the game."), EditorStyles.boldLabel);
            ShowNpcsIds();
        }
        
        protected void SetupNpcsIds()
        {
            npcsIds = serializedObject.FindProperty("npcsIds");
        }
        protected void ShowNpcsIds()
        {
            EditorGUI.indentLevel+=2;
            EditorGUILayout.PropertyField(npcsIds, new GUIContent("IDs", "References to the NPCs' IDs."));
            EditorGUI.indentLevel-=2;
        }

        #endregion

        #region Public Methods

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            Show();
            serializedObject.ApplyModifiedProperties();
        }

        #endregion
        
        #endregion
    }
}

#endif