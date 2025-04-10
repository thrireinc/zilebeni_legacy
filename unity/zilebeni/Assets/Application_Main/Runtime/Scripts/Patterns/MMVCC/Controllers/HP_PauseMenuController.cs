namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views;
    using Settings = Models.HP_Constants.Settings;

    public class HP_PauseMenuController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected float overlayAnimationSpeed, optionsMenuAnimationSpeed;
        [SerializeField] protected CanvasGroup overlayCanvasGroup;
        [SerializeField] protected GameObject optionsMenuPNL, optionsMenuParentPNL, baseOptionsPNL, settingsOptionsPNL, quitMenuModalParentPNL, quitMenuModalPNL, audioOptionsPNL, controlsOptionsPNL, startAnimationPoint, endAnimationPoint;
        [SerializeField] protected Slider masterVolumeSlider, musicVolumeSlider, sfxVolumeSlider, mouseSensibilitySlider;
        [SerializeField] protected TextMeshProUGUI titleTMP;
        [SerializeField] protected RectTransform decorationRT;
        [SerializeField] protected FadeUIEffectView fadeUIEffectView;
        
        protected bool isAnimating, isPaused;
        
        #endregion
        
        #endregion

        #region Methods

        #region Protected Methods

        protected void Start()
        {
            SetupQuitModal();
            SetupBaseOptions();
            SetupSettingsOptions();
            SetupAudioOptions();
            SetupControlsOptions();
        }
        protected void SetupBaseOptions()
        {
            decorationRT.sizeDelta = new Vector2(475, 128);
            titleTMP.text = "Pause";
            optionsMenuPNL.transform.position = startAnimationPoint.transform.position;
            overlayCanvasGroup.alpha = 0;
            optionsMenuParentPNL.SetActive(false);
        }
        protected void SetupQuitModal()
        {
            quitMenuModalParentPNL.SetActive(false);
        }
        protected void SetupSettingsOptions()
        {
            settingsOptionsPNL.SetActive(false);
        }
        protected void SetupAudioOptions()
        {
            audioOptionsPNL.SetActive(false);
            
            if (PlayerPrefs.HasKey(Settings.MasterVolume))
            {
                masterVolumeSlider.value = PlayerPrefs.GetFloat(Settings.MasterVolume);
            }
            else
            {
                masterVolumeSlider.value = masterVolumeSlider.maxValue;
                PlayerPrefs.SetFloat(Settings.MasterVolume, masterVolumeSlider.value);
            }
            
            if (PlayerPrefs.HasKey(Settings.MusicVolume))
            {
                musicVolumeSlider.value = PlayerPrefs.GetFloat(Settings.MusicVolume);
            }
            else
            {
                musicVolumeSlider.value = musicVolumeSlider.maxValue;
                PlayerPrefs.SetFloat(Settings.MusicVolume, musicVolumeSlider.value);
            }
            
            if (PlayerPrefs.HasKey(Settings.SFXVolume))
            {
                sfxVolumeSlider.value = PlayerPrefs.GetFloat(Settings.SFXVolume);
            }
            else
            {
                sfxVolumeSlider.value = sfxVolumeSlider.maxValue;
                PlayerPrefs.SetFloat(Settings.SFXVolume, sfxVolumeSlider.value);
            }
        }
        protected void SetupControlsOptions()
        {
            controlsOptionsPNL.SetActive(false);
            
            if (PlayerPrefs.HasKey(Settings.MouseSensibility))
            {
                mouseSensibilitySlider.value = PlayerPrefs.GetFloat(Settings.MouseSensibility);
            }
            else
            {
                mouseSensibilitySlider.value = mouseSensibilitySlider.maxValue;
                PlayerPrefs.SetFloat(Settings.MouseSensibility, mouseSensibilitySlider.value);
            }
        }

        #endregion

        #region Public Methods

        public void ChangePauseState()
        {
            if (isPaused)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
        
        public void Open()
        {
            if (isAnimating) return;
            isAnimating = true;
            
            Time.timeScale = 0;
            isPaused = true;
            
            optionsMenuParentPNL.SetActive(true);
            LeanTween.alphaCanvas(overlayCanvasGroup, 0, 0).setIgnoreTimeScale(true);
            LeanTween.alphaCanvas(overlayCanvasGroup, 1, overlayAnimationSpeed).setIgnoreTimeScale(true);
            LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setDelay(0.15f).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                isAnimating = false;
            });
        }
        public void Close()
        {
            if (isAnimating) return;
            isAnimating = true;
            
            Time.timeScale = 1;
            isPaused = false;
            LeanTween.alphaCanvas(overlayCanvasGroup, 0, overlayAnimationSpeed).setDelay(0.15f).setIgnoreTimeScale(true);
            LeanTween.move(optionsMenuPNL, startAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                optionsMenuParentPNL.SetActive(false);
                isAnimating = false;
            });
            
            baseOptionsPNL.SetActive(true);
            settingsOptionsPNL.SetActive(false);
            audioOptionsPNL.SetActive(false);
            controlsOptionsPNL.SetActive(false);
        }
        public void OnSettingsButtonPressed()
        {
            LeanTween.move(optionsMenuPNL, startAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                titleTMP.text = "Opções";
                decorationRT.sizeDelta = new Vector2(512, 128);
                baseOptionsPNL.SetActive(false);
                settingsOptionsPNL.gameObject.SetActive(true);
                
                LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setDelay(0.15f).setIgnoreTimeScale(true);
            });
        }
        public void OnAudioButtonPressed()
        {
            LeanTween.move(optionsMenuPNL, startAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                titleTMP.text = "Áudio";
                decorationRT.sizeDelta = new Vector2(485, 128);
                settingsOptionsPNL.SetActive(false);
                audioOptionsPNL.gameObject.SetActive(true);
                
                LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setDelay(0.15f).setIgnoreTimeScale(true);
            });
        }
        public void OnControlsButtonPressed()
        {
            LeanTween.move(optionsMenuPNL, startAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                titleTMP.text = "Controles";
                decorationRT.sizeDelta = new Vector2(650, 128);
                settingsOptionsPNL.SetActive(false);
                controlsOptionsPNL.gameObject.SetActive(true);
                
                LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setDelay(0.15f).setIgnoreTimeScale(true);
            });
        }
        public void OnSettingsBackButtonPressed()
        {
            LeanTween.move(optionsMenuPNL, startAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                decorationRT.sizeDelta = new Vector2(512, 128);
                titleTMP.text = "Opções";
                controlsOptionsPNL.gameObject.SetActive(false);
                audioOptionsPNL.gameObject.SetActive(false);
                settingsOptionsPNL.SetActive(true);
                
                LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setDelay(0.15f).setIgnoreTimeScale(true);
            });
        }
        public void OnBaseBackButtonPressed()
        {
            LeanTween.move(optionsMenuPNL, startAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                decorationRT.sizeDelta = new Vector2(512, 128);
                titleTMP.text = "Pause";
                settingsOptionsPNL.gameObject.SetActive(false);
                baseOptionsPNL.SetActive(true);
                
                LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setDelay(0.15f).setIgnoreTimeScale(true);
            });
        }

        public void OnQuitModalButtonPressed()
        {
            quitMenuModalPNL.transform.localScale = Vector3.zero;
            quitMenuModalParentPNL.SetActive(true);
            LeanTween.scale(quitMenuModalPNL, Vector3.one, 0.5f).setEaseOutBack().setIgnoreTimeScale(true);
        }
        public void OnCloseQuitModalButtonPressed()
        {
            quitMenuModalParentPNL.SetActive(false);
        }
        public void OnMenuButtonPressed()
        {
            Time.timeScale = 1;
            fadeUIEffectView.Effect();
        }

        #endregion

        #endregion
    }
}