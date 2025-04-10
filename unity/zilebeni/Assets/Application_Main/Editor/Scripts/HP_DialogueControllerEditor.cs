#if UNITY_EDITOR

namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEngine;
    using HiscomEngine.Editor.Scripts;
    using Runtime.Scripts.Patterns.MMVCC.Controllers;

    [CustomEditor(typeof(HP_DialogueController)), CanEditMultipleObjects]
    public class HP_DialogueControllerEditor : DialogueControllerEditor
    {
        #region Variables

        #region Protected Variables

        protected SerializedProperty dialogueBoxGameObject, characterIconGameObject, dialogueBoxAnimationStartPositionRT, dialogueBoxAnimationEndPositionRT, characterIconAnimationStartPositionRT, characterIconAnimationEndPositionRT;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected override void Setup()
        {
            base.Setup();
            SetupDialogueBoxGameObject();
        }
        protected override void Show()
        {
            base.Show();
            
            EditorGUILayout.LabelField(new GUIContent("Animation Settings", "Settings related to animations"), EditorStyles.boldLabel);
            ShowDialogueBoxGameObject();
        }
        
        protected virtual void SetupDialogueBoxGameObject()
        {
            dialogueBoxGameObject = serializedObject.FindProperty("dialogueBoxGameObject");
            dialogueBoxAnimationStartPositionRT = serializedObject.FindProperty("dialogueBoxAnimationStartPositionRT");
            dialogueBoxAnimationEndPositionRT = serializedObject.FindProperty("dialogueBoxAnimationEndPositionRT");
        }
        protected virtual void ShowDialogueBoxGameObject()
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(dialogueBoxGameObject, new GUIContent("Dialogue Box: ", "The dialogue box that will be animated."), true);
            EditorGUILayout.PropertyField(dialogueBoxAnimationStartPositionRT, new GUIContent("Dialogue Box Animation Start Position: ", "The start position of the dialogue box animation."), true);
            EditorGUILayout.PropertyField(dialogueBoxAnimationEndPositionRT, new GUIContent("Dialogue Box Animation End Position: ", "The end position of the dialogue box animation."), true);
            EditorGUI.indentLevel--;
        }

        #endregion

        #endregion
    }
}

#endif