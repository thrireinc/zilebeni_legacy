namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEngine;
    using FancyCarouselView.Editor.Scripts;
    using Runtime.Scripts.Patterns.MMVCC.Controllers;
    
    [CustomEditor(typeof(HP_DeathMenuController))]
    public class HP_DeathMenuControllerEditor : CarouselViewEditor
    {
        #region Variables

        #region Protected Variables

        protected SerializedProperty changeSelectedCellSpeed, npcSpawnController, deathMenuCanvasGroup, tentacleCanvasGroup;

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
            SetupCell();
            SetupNpcSpawnController();
            SetupCanvasGroups();
        }
        protected virtual void Show()
        {
            ShowCell();
            ShowNpcSpawnController();
            ShowCanvasGroups();
        }

        protected virtual void SetupCell()
        {
            changeSelectedCellSpeed = serializedObject.FindProperty("changeSelectedCellSpeed");
        }
        protected virtual void ShowCell()
        {
            EditorGUILayout.PropertyField(changeSelectedCellSpeed, new GUIContent("Change Selected Cell Speed", "The speed at which the selected cell changes."));
        }
        protected virtual void SetupNpcSpawnController()
        {
            npcSpawnController = serializedObject.FindProperty("npcSpawnController");
        }
        protected virtual void ShowNpcSpawnController()
        {
            EditorGUILayout.PropertyField(npcSpawnController, new GUIContent("NPC Spawn Controller", "The NPC Spawn Controller reference."));
        }
        protected virtual void SetupCanvasGroups()
        {
            deathMenuCanvasGroup = serializedObject.FindProperty("deathMenuCanvasGroup");
            tentacleCanvasGroup = serializedObject.FindProperty("tentacleCanvasGroup");
        }
        protected virtual void ShowCanvasGroups()
        {
            EditorGUILayout.PropertyField(deathMenuCanvasGroup, new GUIContent("Death Menu Canvas Group", "The Death Menu Canvas Group reference."));
            EditorGUILayout.PropertyField(tentacleCanvasGroup, new GUIContent("Tentacle Canvas Group", "The Tentacle Canvas Group reference."));
        }

        #endregion

        #region Public Methods

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            base.OnInspectorGUI();
            Show();
            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #endregion
    }
}