namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Managers;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Change Amount of Value Quest View")]
    public class HP_ChangeAmountOfValueQuestView : QuestView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected int amountToDo;
        [SerializeField] protected string notificationToReceive, questDescription;
        protected int amountDone;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected virtual void AddObservers()
        {
            NotificationManager.Instance.AddObserver(notificationToReceive, gameObject, (_, _) => IncrementAmount());
        }
        protected virtual void RemoveObservers()
        {
            NotificationManager.Instance.RemoveObservers(gameObject);
        }
        
        protected override void CheckQuestStatus()
        {
            NotificationManager.Instance.PostNotification("cd", gameObject, $"{questDescription} ({amountDone} / {amountToDo})");

            if (amountDone < amountToDo) return;
            IsCompleted = true;
            NotificationManager.Instance.PostNotification("rd", gameObject);
            RemoveObservers();
        }

        protected virtual void IncrementAmount()
        {
            amountDone++;
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