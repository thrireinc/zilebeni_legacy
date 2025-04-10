/*#if UNITY_EDITOR

namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using HiscomEngine.Editor.Scripts;
    using Runtime.Scripts.Patterns.MMVCC.Views;

    [CustomEditor(typeof(HP_GenericRangedAttackView)), CanEditMultipleObjects]
    public class HP_GenericRangedAttackViewEditor : GenericRangedAttackViewEditor
    {
        #region Methods

        #region Public Methods

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #endregion
    }
}

#endif  */