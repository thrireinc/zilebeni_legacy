namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views;

    public class HP_Bullet3DView : Bullet3DView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected TrailRenderer bulletTrailRenderer;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public override void Move(Vector3 direction)
        {
            base.Move(direction);
            bulletTrailRenderer.emitting = true;
        }
        public override void Reset()
        {
            base.Reset();
            bulletTrailRenderer.emitting = false;
            bulletTrailRenderer.Clear();
        }

        #endregion

        #endregion
    }
}