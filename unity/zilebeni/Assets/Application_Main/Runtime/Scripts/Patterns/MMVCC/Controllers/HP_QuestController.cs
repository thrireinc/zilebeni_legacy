namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Controllers/HP Quest Controller")]
    public class HP_QuestController : QuestController
    {
        #region Variables

        #region Protected Variables

        [SerializeField] private HP_QuestUIController questUiController;

        #endregion

        #endregion
        
        #region Methods

        #region Public Methods

        public override void StartQuestById(int id)
        {
            var quest = GetQuestById(id);
            if (quest.IsStarted) return;
            quest.IsStarted = true;
            
            GetQuestById(id).StartQuest();
            questUiController.StartQuestById(id);
        }

        #endregion

        #endregion
    }
}
