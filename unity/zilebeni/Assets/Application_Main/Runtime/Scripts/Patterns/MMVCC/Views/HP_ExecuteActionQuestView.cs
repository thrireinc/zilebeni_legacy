namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Managers;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Execute Action Quest View")]
    public class HP_ExecuteActionQuestView : QuestView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected string notificationToReceive;
        [SerializeField] protected string questDescription;
        protected bool hasDoneAction;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected virtual void AddObservers()
        {
            NotificationManager.Instance.AddObserver(notificationToReceive, gameObject, (_, _) => hasDoneAction = true);
        }
        protected virtual void RemoveObservers()
        {
            NotificationManager.Instance.RemoveObservers(gameObject);
        }
        
        protected override void CheckQuestStatus()
        {
            NotificationManager.Instance.PostNotification("cd", gameObject, $"{questDescription}");

            if (!hasDoneAction) return;
            IsCompleted = true;
            NotificationManager.Instance.PostNotification("rd", gameObject);
            RemoveObservers();
        }

        #endregion

        #region Public Methods

        public override void StartQuest()
        {
            base.StartQuest();
            AddObservers();
        }
        public override void EndQuest()
        {
            base.EndQuest();
            NotificationManager.Instance.PostNotification("rd", gameObject);
        }
        
        #endregion

        #endregion
    }
}