namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP NPC View")]
    public class HP_NPCView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected string npcId, npcName;
        [SerializeField] protected Sprite npcSplashScreenArtSprite;
        
        #endregion

        #region Public Variables
        
        public string GetNpcId => npcId;
        public string GetNpcName => npcName;
        public Sprite GetNpcSplashScreenArtSprite => npcSplashScreenArtSprite;
        
        #endregion

        #endregion
    }
}