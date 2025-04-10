#if UNITY_EDITOR

namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEngine;
    using Runtime.Scripts.Patterns.MMVCC.Views;

    [CustomEditor(typeof(HP_RatMovesetDashIntoPlayerView))]
    public class HP_RatMovesetDashIntoPlayerViewEditor : Editor
    {
        #region Variables

        #region Protected Variables

        protected SerializedProperty dashForce, isOnScene, playerTag, playerReference, ratReference, DiP_notification;

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
            SetupRat();
            SetupPlayer();
            SetupNotification();
        }
        protected void Show()
        {
            ShowRat();
            EditorGUILayout.Space();
            
            ShowPlayer();
            EditorGUILayout.Space();
            
            ShowNotification();
        }

        protected void SetupRat()
        {
            dashForce = serializedObject.FindProperty("dashForce");
            ratReference = serializedObject.FindProperty("ratReference");
        }
        protected void ShowRat()
        {
            EditorGUILayout.PropertyField(ratReference, new GUIContent("Rat reference", "The rat reference"));
            EditorGUI.indentLevel++;
            {
                EditorGUILayout.PropertyField(dashForce, new GUIContent("Dash force", "The force of the dash"));
            }
            EditorGUI.indentLevel--;
        }

        protected void SetupPlayer()
        {
            isOnScene = serializedObject.FindProperty("isOnScene");
            playerReference = serializedObject.FindProperty("playerReference");
            playerTag = serializedObject.FindProperty("playerTag");
        }
        protected void ShowPlayer()
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.PropertyField(isOnScene, new GUIContent("Is on scene?", "Is this rat reference on the scene?"));

                switch (isOnScene.boolValue)
                {
                    case true:
                        EditorGUILayout.PropertyField(playerReference, new GUIContent("Player reference", "The player reference"));
                        break;
                    
                    case false:
                        EditorGUILayout.PropertyField(playerTag, new GUIContent("Player tag", "The player tag"));
                        break;
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        protected void SetupNotification()
        {
            DiP_notification = serializedObject.FindProperty("DiP_notification");
        }
        protected void ShowNotification()
        {
            EditorGUILayout.PropertyField(DiP_notification, new GUIContent("Notification to receive", "The notification to receive in order to perform the dash"));
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