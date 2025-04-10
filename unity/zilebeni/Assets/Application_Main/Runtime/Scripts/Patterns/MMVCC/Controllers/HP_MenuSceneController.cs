namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using System.IO;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    using HiscomEngine.Runtime.Scripts.Structures.ScriptableObjects;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views;

    public class HP_MenuSceneController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables
        
        [SerializeField] protected string[] filesToLoad;
        [SerializeField] protected RectTransform cutoutMask;
        [SerializeField] protected GameObject startGameButtonGameObject, newGameButtonGameObject, newGameModalParentPNL, newGameModalPNL, logo;
        [SerializeField] protected DataRulesScriptableObject dataRules;
        [SerializeField] protected Button[] continueBTN;
        [SerializeField] protected FadeUIEffectView fadeUIEffectView;
        [SerializeField] protected HoverUIEffectView hoverUIEffectView;
        [SerializeField] protected HP_OptionsMenuController optionsMenuController;
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void Start()
        {
            SetupMask();
            SetupNewGameModal();
            CheckForSavedFiles();
            AnimateLogo();
        }
        protected void SetupMask()
        {
            cutoutMask.sizeDelta = Vector2.one;
        }
        protected void SetupNewGameModal()
        {
            newGameModalParentPNL.SetActive(false);
        }
        protected void CheckForSavedFiles()
        {
            foreach (var btn in continueBTN)
                btn.interactable = true;
            hoverUIEffectView.enabled = true;
            newGameButtonGameObject.SetActive(true);
            startGameButtonGameObject.SetActive(false);
            
            if (filesToLoad.All(file => File.Exists($"{Path.Combine(dataRules.GetDataPath, dataRules.GetSaveFolder, file)}{dataRules.GetFileType}"))) return;
            
            foreach (var btn in continueBTN)
                btn.interactable = false;
            hoverUIEffectView.enabled = false;
            startGameButtonGameObject.SetActive(true);
            newGameButtonGameObject.SetActive(false);
        }

        protected void AnimateLogo()
        {
            LeanTween.moveLocalY(logo, 330, 2).setEaseInOutQuad().setOnComplete(() =>
            {
                LeanTween.moveLocalY(logo, 300, 2f).setEaseInOutQuad().setOnComplete(AnimateLogo);
            });
        }

        #endregion
    
        #region Public Methods

        public void OnSceneStart()
        {
            LeanTween.value(gameObject, 0, 2500, 1).setOnUpdate(value =>
            {
                cutoutMask.sizeDelta = new Vector2(value, value);
            })
            .setOnComplete(() =>
            {
                cutoutMask.gameObject.SetActive(false);
            });
        }
        public void OnNewGameButtonPressed()
        {
            var files = Directory.GetFiles($"{Path.Combine(dataRules.GetDataPath, dataRules.GetSaveFolder)}");
            foreach (var file in files)
                File.Delete(file);
            Directory.Delete($"{Path.Combine(dataRules.GetDataPath, dataRules.GetSaveFolder)}");
            
            fadeUIEffectView.Effect();
        }
        public void OnPlayGameButtonPressed()
        {
            fadeUIEffectView.Effect();
        }
        public void OnOpenNewGameModalButtonPressed()
        {
            newGameModalPNL.transform.localScale = Vector3.zero;
            newGameModalParentPNL.SetActive(true);
            LeanTween.scale(newGameModalPNL, Vector3.one, 0.5f).setEaseOutBack();
        }
        public void OnCloseNewGameModalButtonPressed()
        {
            newGameModalParentPNL.SetActive(false);
        }
        public void OnQuitButtonPressed()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        #endregion

        #endregion
    }
}