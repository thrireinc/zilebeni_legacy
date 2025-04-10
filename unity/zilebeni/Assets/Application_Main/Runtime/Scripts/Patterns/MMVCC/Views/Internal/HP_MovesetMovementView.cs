namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views.Internal
{
    using UnityEngine;

    public abstract class HP_MovesetMovementView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected float movementDuration;
        [SerializeField] protected Animator animator;
        [SerializeField] protected AnimationClip idleAnimation, movementAnimation;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        public abstract void Movement();

        #endregion

        #endregion
    } 
}