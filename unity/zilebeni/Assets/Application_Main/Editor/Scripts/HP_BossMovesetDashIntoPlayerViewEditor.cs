namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEngine;
    using Runtime.Scripts.Patterns.MMVCC.Views;
    
    [CustomEditor(typeof(HP_BossMovesetDashIntoPlayerView)), CanEditMultipleObjects]
    public class HP_BossMovesetDashIntoPlayerViewEditor : HP_MovesetMovementViewEditor
    {
        #region Variables

        #region Protected Variables

        protected SerializedProperty startDashAnimation, endDashAnimation, movementCanvasGroup, numberOfDashes, animationDelay, bossReference, playerReference, bossRigidbody, playerLightOffset, defaultProfile, dashForce, profileLuxIntensity, sceneLuxIntensity, playerLuxIntensity, sceneLight, playerLight;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected override void Setup()
        {
            base.Setup();
            SetupMovementCanvasGroup();
            SetupBoss();
            SetupProfile();
            SetupScene();
            SetupPlayer();
        }
        protected override void Show()
        {
            base.Show();
            ShowMovementCanvasGroup();
            ShowProfile();
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField(new GUIContent("Scene References", "References related to the scene."), EditorStyles.boldLabel);
            ShowScene();
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField(new GUIContent("Boss References", "References related to the boss."), EditorStyles.boldLabel);
            ShowBoss();
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField(new GUIContent("Player References", "References related to the player."), EditorStyles.boldLabel);
            ShowPlayer();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            
            if (Application.isPlaying)
                MovementButton();
        }

        protected override void SetupMovementAnimation()
        {
            base.SetupMovementAnimation();
            startDashAnimation = serializedObject.FindProperty("startDashAnimation");
            endDashAnimation = serializedObject.FindProperty("endDashAnimation");
        }
        protected override void ShowMovementAnimation()
        {
            base.ShowMovementAnimation();
            EditorGUILayout.PropertyField(startDashAnimation, new GUIContent("Start dash animation", "The start dash animation"));
            EditorGUILayout.PropertyField(endDashAnimation, new GUIContent("End dash animation", "The end dash animation"));
        }
        protected void SetupMovementCanvasGroup()
        {
            movementCanvasGroup = serializedObject.FindProperty("movementCanvasGroup");
        }
        protected void ShowMovementCanvasGroup()
        {
            EditorGUILayout.PropertyField(movementCanvasGroup, new GUIContent("Canvas group", "The canvas group for the movement"));
        }

        protected void SetupBoss()
        {
            numberOfDashes = serializedObject.FindProperty("numberOfDashes");
            animationDelay = serializedObject.FindProperty("animationDelay");
            bossReference = serializedObject.FindProperty("bossReference");
            bossRigidbody = serializedObject.FindProperty("bossRigidbody");
            dashForce = serializedObject.FindProperty("dashForce");
        }
        protected void ShowBoss()
        {
            EditorGUI.indentLevel++;
            {
                EditorGUILayout.PropertyField(bossReference, new GUIContent("Boss reference", "The boss reference"));
                EditorGUILayout.PropertyField(bossRigidbody, new GUIContent("Rigidbody reference", "The rigidbody reference"));
                EditorGUI.indentLevel++;
                {
                    EditorGUILayout.PropertyField(numberOfDashes, new GUIContent("Number of dashes", "The number of dashes"));
                    EditorGUILayout.PropertyField(animationDelay, new GUIContent("Animation delay", "The delay for the animation"));
                    EditorGUILayout.PropertyField(dashForce, new GUIContent("Dash force", "The force of the dash"));
                }
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }

        protected void SetupProfile()
        {
            defaultProfile = serializedObject.FindProperty("defaultProfile");
            profileLuxIntensity = serializedObject.FindProperty("profileLuxIntensity");
        }
        protected void ShowProfile()
        {
            EditorGUILayout.PropertyField(defaultProfile, new GUIContent("Default profile", "The default profile"));
            EditorGUI.indentLevel++;
            {
                EditorGUILayout.PropertyField(profileLuxIntensity, new GUIContent("Intensity", "The intensity of the default profile (lux)"));
            }
            EditorGUI.indentLevel--;
        }

        protected void SetupScene()
        {
            sceneLight = serializedObject.FindProperty("sceneLight");
            sceneLuxIntensity = serializedObject.FindProperty("sceneLuxIntensity");
        }
        protected void ShowScene()
        {
            EditorGUI.indentLevel++;
            {
                EditorGUILayout.PropertyField(sceneLight, new GUIContent("Light reference", "The light reference"));
            
                EditorGUI.indentLevel++;
                {
                    EditorGUILayout.PropertyField(sceneLuxIntensity, new GUIContent("Intensity", "The intensity of the scene light (lux)"));
                }
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }

        protected void SetupPlayer()
        {
            playerReference = serializedObject.FindProperty("playerReference");
            playerLightOffset = serializedObject.FindProperty("playerLightOffset");
            playerLuxIntensity = serializedObject.FindProperty("playerLuxIntensity");
            playerLight = serializedObject.FindProperty("playerLight");
        }
        protected void ShowPlayer()
        {
            EditorGUI.indentLevel++;
            {
                EditorGUILayout.PropertyField(playerReference, new GUIContent("Player reference", "The player reference"));
                EditorGUILayout.Space();
            
                EditorGUILayout.PropertyField(playerLight, new GUIContent("Light reference", "The light reference"));
            
                EditorGUI.indentLevel++;
                {
                    EditorGUILayout.PropertyField(playerLuxIntensity, new GUIContent("Intensity", "The intensity of the player light (lux)"));
                    EditorGUILayout.PropertyField(playerLightOffset, new GUIContent("Position offset", "The offset for the player light's position"));
                }
                EditorGUI.indentLevel--;
            }
            EditorGUI.indentLevel--;
        }

        #endregion

        #endregion
    }
}