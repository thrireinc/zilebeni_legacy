namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using UnityEngine.UI;
    using Structures.Enums;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Stat Interface Item View")]
    public class HP_StatInterfaceItemView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected Image statIMG;
        [SerializeField] protected Sprite fullSprite, emptySprite;
        protected HP_PlayerStatUIItemState itemState;
        
        #endregion

        #region Public Variables

        public HP_PlayerStatUIItemState GetItemState => itemState;

        #endregion
        
        #endregion

        #region Methods

        #region Protected Methods

        protected virtual void Start()
        {
            Enable();
        }

        #endregion
        
        #region Public Methods

        /// <summary>
        /// Enables the item.
        /// </summary>
        public virtual void Enable()
        {
            itemState = HP_PlayerStatUIItemState.Full;
            statIMG.sprite = fullSprite;
        }
        
        /// <summary>
        /// Disables the item.
        /// </summary>
        public virtual void Disable()
        {
            itemState = HP_PlayerStatUIItemState.Empty;
            statIMG.sprite = emptySprite;
        }

        #endregion

        #endregion
    }
}