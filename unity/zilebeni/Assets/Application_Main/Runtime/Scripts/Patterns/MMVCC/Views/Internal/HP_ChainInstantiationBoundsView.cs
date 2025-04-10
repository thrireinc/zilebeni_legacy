namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views.Internal
{
    using System;
    using UnityEngine;
    
    [Serializable]
    public class HP_ChainInstantiationBoundsView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected Transform lowerLeft, upperLeft, upperRight, lowerRight;

        #endregion

        #region Public Variables

        public Transform GetLowerLeft => lowerLeft;
        public Transform GetUpperLeft => upperLeft;
        public Transform GetUpperRight => upperRight;
        public Transform GetLowerRight => lowerRight;

        #endregion

        #endregion
    }
}