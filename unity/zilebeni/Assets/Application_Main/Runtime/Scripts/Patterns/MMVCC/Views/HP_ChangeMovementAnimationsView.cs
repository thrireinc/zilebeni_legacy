namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views.Internal;
    
    [AddComponentMenu("Scripts/Hiscom Engine/Patterns/MMVCC/Views/HP Change Movement Animations")]
    public class HP_ChangeMovementAnimations : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected MovementsView movement;
    
        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public void ChangeDefaultAnimationClip(AnimationClip defaultAnimationClip)
        {
            movement.DefaultAnimationClip = defaultAnimationClip;
        }
        public void ChangeMovementAnimationClip(AnimationClip movementAnimationClip)
        {
            movement.MovementAnimationClip = movementAnimationClip;
        }

        #endregion

        #endregion
    }
}