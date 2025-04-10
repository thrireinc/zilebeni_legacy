namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views.Internal
{
    using System;
    
    [Serializable]
    public class HP_DeathMenuItemView
    {
        #region Variables

        #region Public Variables

        public HP_DeathMenuCardView card;
        public string id;

        #endregion

        #endregion

        #region Constructor

        public HP_DeathMenuItemView(HP_DeathMenuCardView card, string id)
        {
            this.card = card;
            this.id = id;
        }

        #endregion
    }
}