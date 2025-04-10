namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using Views;
    
    public class HP_QuestUIController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] private HP_QuestController questController;
        [SerializeField] protected CanvasGroup iconCanvasGroup, exclamationMarkCanvasGroup;
        [SerializeField] protected GameObject descriptionPNL, placeholderPNL;
        [SerializeField] private RectTransform contentRT;
        [SerializeField] protected HP_QuestUIView questUIViewPrefab;
        
        #endregion

        #endregion
        
        #region Methods

        #region Public Methods

        public void Enable()
        {
            descriptionPNL.SetActive(true);
        }
        public void Disable()
        {
            descriptionPNL.SetActive(false);
        }
        public virtual void StartQuestById(int id)
        {
            var quest = questController.GetQuestById(id);
            var instance = Instantiate(questUIViewPrefab, contentRT);
            instance.Initialize(quest.gameObject);
            placeholderPNL.SetActive(false);
            
            LeanTween.alphaCanvas(iconCanvasGroup, 0f, 0.5f).setEase(LeanTweenType.easeInBack).setOnComplete(() =>
            {
                LeanTween.alphaCanvas(exclamationMarkCanvasGroup, 1f, 0.5f).setEase(LeanTweenType.easeInBack).setOnComplete(() =>
                {
                     LeanTween.alphaCanvas(exclamationMarkCanvasGroup, 0f, 0.5f).setEase(LeanTweenType.easeInBack).setOnComplete(() =>
                     {
                         LeanTween.alphaCanvas(iconCanvasGroup, 1f, 0.5f).setEase(LeanTweenType.easeInBack);
                     }).setDelay(1f);   
                });
            });
        }

        #endregion

        #endregion
    }
}