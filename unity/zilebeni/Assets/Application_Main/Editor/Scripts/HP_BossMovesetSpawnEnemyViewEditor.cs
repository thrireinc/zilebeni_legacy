#if UNITY_EDITOR

namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEngine;
    using Runtime.Scripts.Patterns.MMVCC.Views;

    [CustomEditor(typeof(HP_BossMovesetSpawnEnemyView))]
    public class HP_BossMovesetSpawnEnemyViewEditor : HP_MovesetMovementViewEditor
    {
        #region Variables

        #region Protected Variables

        protected SerializedProperty enemyReference, numberOfHordes, numberOfEnemiesPerSpawn, timeBetweenEnemies, timeBetweenHordes, spawnPoints;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected override void Setup()
        {
            base.Setup();
            SetupEnemyReference();
            SetupHorde();
            SetupSpawnPoints();
        }
        protected override void Show()
        {
            base.Show();
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField(new GUIContent("Enemy settings", "Settings for the enemies"), EditorStyles.boldLabel);
            ShowEnemyReference();
            ShowSpawnPoints();
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField(new GUIContent("Horde settings", "Settings for the hordes"), EditorStyles.boldLabel);
            ShowHorde();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            
            if (Application.isPlaying)
                MovementButton();
        }
        
        protected void SetupEnemyReference()
        {
            enemyReference = serializedObject.FindProperty("enemyReference");
        }
        protected void ShowEnemyReference()
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(enemyReference, new GUIContent("Enemy reference", "Reference for the enemy to spawn"));
            EditorGUI.indentLevel--;
        }

        protected void SetupHorde()
        {
            numberOfHordes = serializedObject.FindProperty("numberOfHordes");
            numberOfEnemiesPerSpawn = serializedObject.FindProperty("numberOfEnemiesPerSpawn");
            timeBetweenEnemies = serializedObject.FindProperty("timeBetweenEnemies");
            timeBetweenHordes = serializedObject.FindProperty("timeBetweenHordes");
        }
        protected void ShowHorde()
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(numberOfHordes, new GUIContent("Number of hordes", "Number of hordes to spawn"));
            EditorGUILayout.PropertyField(numberOfEnemiesPerSpawn, new GUIContent("Number of enemies per spawn", "Number of enemies to spawn per spawn point"));
            EditorGUILayout.PropertyField(timeBetweenEnemies, new GUIContent("Time between enemies", "Time between each enemy spawn"));
            EditorGUILayout.PropertyField(timeBetweenHordes, new GUIContent("Time between hordes", "Time between each horde spawn"));
            EditorGUI.indentLevel--;
        }

        protected void SetupSpawnPoints()
        {
            spawnPoints = serializedObject.FindProperty("spawnPoints");
        }
        protected void ShowSpawnPoints()
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(spawnPoints, new GUIContent("Spawn points", "Spawn points for the enemies"));
            EditorGUI.indentLevel--;
        }

        #endregion

        #endregion
    }
}

#endif