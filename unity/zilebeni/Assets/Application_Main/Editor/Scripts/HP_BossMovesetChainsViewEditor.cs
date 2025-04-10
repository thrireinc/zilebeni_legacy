#if UNITY_EDITOR

namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEngine;
    using Runtime.Scripts.Patterns.MMVCC.Views;
    
    [CustomEditor(typeof(HP_BossMovesetChainsView))]
    public class HP_BossMovesetChainsViewEditor : HP_MovesetMovementViewEditor
    {
        #region Variables

        #region Protected Variables

        protected SerializedProperty chainReference, bounds;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected override void Setup()
        {
            base.Setup();
            SetupChainReference();
            SetupBounds();
        }
        protected override void Show()
        {
            base.Show();
            ShowChainReference();
            EditorGUILayout.Space();
            
            ShowBounds();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            
            if (Application.isPlaying)
                MovementButton();
        }
        
        protected void SetupChainReference()
        {
            chainReference = serializedObject.FindProperty("chainReference");
        }
        protected void ShowChainReference()
        {
            EditorGUILayout.PropertyField(chainReference, new GUIContent("Chain reference", "Reference to the chain object"));
        }
        protected void SetupBounds()
        {
            bounds = serializedObject.FindProperty("bounds");
        }
        protected void ShowBounds()
        {
            EditorGUILayout.PropertyField(bounds, new GUIContent("Bounds", "Bounds of the arena where the boss can move"));
        }

        #endregion

        #endregion
    }
}

#endif