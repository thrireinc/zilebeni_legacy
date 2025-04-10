namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEngine;
    using Runtime.Scripts.Patterns.MMVCC.Views.Internal;
    
    [CustomEditor(typeof(HP_MovesetMovementView)), CanEditMultipleObjects]
    public class HP_MovesetMovementViewEditor : Editor
    {
        #region Variables

        #region Protected Variables

        protected SerializedProperty movementDuration, animator, idleAnimation, movementAnimation;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected void OnEnable()
        {
            Setup();
        }

        protected virtual void Setup()
        {
            SetupMovementDuration();
            SetupMovementAnimation();
        }
        protected virtual void Show()
        {
            ShowMovementDuration();
            ShowMovementAnimation();
        }

        protected virtual void SetupMovementDuration()
        {
            movementDuration = serializedObject.FindProperty("movementDuration");
        }
        protected virtual void ShowMovementDuration()
        {
            EditorGUILayout.PropertyField(movementDuration, new GUIContent("Duration", "The duration of the movement (seconds)"));
        }
        protected virtual void SetupMovementAnimation()
        {
            animator = serializedObject.FindProperty("animator");
            idleAnimation = serializedObject.FindProperty("idleAnimation");
            movementAnimation = serializedObject.FindProperty("movementAnimation");
        }
        protected virtual void ShowMovementAnimation()
        {
            EditorGUILayout.PropertyField(animator, new GUIContent("Animator", "The animator component"));
            EditorGUILayout.PropertyField(idleAnimation, new GUIContent("Idle animation", "The idle animation"));
            EditorGUILayout.PropertyField(movementAnimation, new GUIContent("Movement animation", "The animation to play"));
        }

        protected virtual void MovementButton()
        {
            if (GUILayout.Button("TEST MOVEMENT"))
                ((HP_MovesetMovementView) target).Movement();
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