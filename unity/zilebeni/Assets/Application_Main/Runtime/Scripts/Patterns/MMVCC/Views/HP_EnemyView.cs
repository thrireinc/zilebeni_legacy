namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using UnityEngine.Animations;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Enemy View")]
    public class HP_EnemyView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected ParentConstraint parentConstraint;
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected virtual void Start()
        {
            Setup();
        }

        protected virtual void Setup()
        {
            SetupParentConstraint();
        }
        
        protected virtual void SetupParentConstraint()
        {
            var constraintSource = new ConstraintSource
            {
                sourceTransform = GameObject.FindWithTag("_rotationConstraint").transform,
                weight = 1
            };
            parentConstraint.AddSource(constraintSource);
        }

        #endregion

        #endregion
    }
}