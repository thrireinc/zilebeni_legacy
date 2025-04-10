namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using FancyCarouselView.Runtime.Scripts;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Managers;
    using Internal;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Death Menu Card View")]
    public class HP_DeathMenuCardView : CarouselCell<string, HP_DeathMenuCardView>
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected TextMeshProUGUI npcNameTMP;
        [SerializeField] protected Image bgIMG, npcSplashArtIMG;
        protected string id;

        #endregion

        #region Public Variables

        public string Id {get => id; set => id = value;}
        public TextMeshProUGUI NpcNameTMP {get => npcNameTMP; set => npcNameTMP = value;}
        public Image BgIMG {get => bgIMG; set => bgIMG = value;}
        public Image NpcSplashArtIMG {get => npcSplashArtIMG; set => npcSplashArtIMG = value;}

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected override void Refresh(string itemData)
        {
            id = itemData;
            
            NotificationManager.Instance.PostNotification("carouselUpdated", null, new HP_DeathMenuItemView(this, itemData));
        }
        
        #endregion

        #endregion
    }
}