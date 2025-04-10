namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;

    public class HP_RatStatModifierView : StatModifierView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected string statsControllerName;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected void Start()
        {
            if (defaultStatsController != null) return;
            foreach (var statsController in FindObjectsOfType<StatsController>())
            {
                if (!statsController.gameObject.activeSelf || statsController.gameObject.name != statsControllerName) continue;
                defaultStatsController = statsController;
            }
        }

        #endregion

        #endregion
    }
}



