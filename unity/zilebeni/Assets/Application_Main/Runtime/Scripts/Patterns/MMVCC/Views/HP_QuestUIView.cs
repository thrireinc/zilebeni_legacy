namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using TMPro;
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Managers;
    
    public class HP_QuestUIView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables
        
        [SerializeField] protected TextMeshProUGUI descriptionTMP;
        protected bool isInitialized, isCompleted;
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods
        
        protected virtual void AddObservers(GameObject notificationSender)
        {
            NotificationManager.Instance.AddObserver("cd", gameObject, (sender, value) =>
            {
                if (sender == notificationSender)
                    descriptionTMP.text = (string)value;
            });
            NotificationManager.Instance.AddObserver("rd", gameObject, (sender, _) =>
            {
                if (sender != notificationSender) return;
                descriptionTMP.text = $"<s>{descriptionTMP.text}</s>";
                isCompleted = true;
                RemoveObservers();
            });
        }
        protected virtual void RemoveObservers()
        {
            NotificationManager.Instance.RemoveObservers(gameObject);
        }

        #endregion

        #region Public Methods

        public void Initialize(GameObject notificationSender)
        {
            if (isInitialized) return;
            isInitialized = true;
            AddObservers(notificationSender);
        }

        #endregion

        #endregion
    }
}