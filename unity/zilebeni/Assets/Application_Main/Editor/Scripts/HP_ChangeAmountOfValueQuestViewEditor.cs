#if UNITY_EDITOR

namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEngine;
    using HiscomEngine.Editor.Scripts;
    using Runtime.Scripts.Patterns.MMVCC.Views;
    
    [CustomEditor(typeof(HP_ChangeAmountOfValueQuestView)), CanEditMultipleObjects]
    public class HP_ChangeAmountOfValueQuestViewEditor : QuestViewEditor
    {
        #region Variables

        #region Protected Variables

        protected SerializedProperty notificationToReceive, amountToDo, questDescription;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected override void Setup()
        {
            base.Setup();
            SetupNotification();
            SetupAmount();
            SetupQuestDescription();
        }
        protected override void Show()
        {
            base.Show();
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField(new GUIContent("Change amount of value Quest Settings", "Settings related to this specific itself"), EditorStyles.boldLabel);
            ShowNotification();
            ShowAmount();
            ShowQuestDescription();
        }

        protected void SetupNotification()
        {
            notificationToReceive = serializedObject.FindProperty("notificationToReceive");
        }
        protected void ShowNotification()
        {
            EditorGUI.indentLevel++;
            {
                EditorGUILayout.PropertyField(notificationToReceive, new GUIContent("Notification to receive", "The notification to receive to increment the amount of done"));
            }
            EditorGUI.indentLevel--;
        }

        protected void SetupAmount()
        {
            amountToDo = serializedObject.FindProperty("amountToDo");
        }
        protected void ShowAmount()
        {
            EditorGUI.indentLevel++;
            {
                EditorGUILayout.PropertyField(amountToDo, new GUIContent("Amount to do", "The amount to do to complete the quest"));
            }
            EditorGUI.indentLevel--;
        }
        protected void SetupQuestDescription()
        {
            questDescription = serializedObject.FindProperty("questDescription");
        }
        protected void ShowQuestDescription()
        {
            EditorGUI.indentLevel++;
            {
                EditorGUILayout.PropertyField(questDescription, new GUIContent("Quest description", "The description of the quest"));
            }
            EditorGUI.indentLevel--;
        }

        #endregion
        
        #endregion
    }
}

#endif