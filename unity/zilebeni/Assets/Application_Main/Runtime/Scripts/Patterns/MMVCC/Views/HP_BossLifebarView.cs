namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using UnityEngine.UI;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;

    public class HP_BossLifebarView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected StatsController lifeStatsController;
        [SerializeField] protected Slider lifeSlider;
        [SerializeField] protected int lifeStatID;
    
        #endregion

        #endregion
    
        #region Methods

        #region Protected Methods

        protected virtual void Start()
        {
            SetupLife();
        }
        protected virtual void SetupLife()
        {
            var lifeStat = lifeStatsController.GetStat(lifeStatID);
            if (lifeStat == null) return;
            lifeSlider.value = lifeSlider.maxValue = lifeStat.GetStatAmount;
            lifeStat.OnStatAmountChanged += ShowLife;
        }
        protected virtual void ShowLife(float value)
        {
            lifeSlider.value = value;
        }

        #endregion
    
        #endregion
    }
}