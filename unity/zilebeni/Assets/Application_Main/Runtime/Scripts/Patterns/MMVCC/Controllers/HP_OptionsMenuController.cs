namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using Settings = Models.HP_Constants.Settings;
    
    public class HP_OptionsMenuController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected float overlayAnimationSpeed, optionsMenuAnimationSpeed, creditsAnimationSpeed;
        [SerializeField] protected CanvasGroup overlayCanvasGroup, creditsCanvasGroup;
        [SerializeField] protected GameObject optionsMenuPNL, optionsMenuParentPNL, baseOptionsPNL, audioOptionsPNL, controlsOptionsPNL, creditsDescriptionPNL, startAnimationPoint, endAnimationPoint;
        [SerializeField] protected Slider masterVolumeSlider, musicVolumeSlider, sfxVolumeSlider, mouseSensibilitySlider;
        [SerializeField] protected TextMeshProUGUI titleTMP;
        [SerializeField] protected RectTransform decorationRT;

        protected int creditsTweenId;
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void Start()
        {
            SetupBaseOptions();
            SetupAudioOptions();
            SetupControlsOptions();
            SetupCredits();
        }
        protected void SetupBaseOptions()
        {
            decorationRT.sizeDelta = new Vector2(512, 128);
            titleTMP.text = "Opções";
            optionsMenuPNL.transform.position = startAnimationPoint.transform.position;
            overlayCanvasGroup.alpha = 0;
            optionsMenuParentPNL.SetActive(false);
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
        protected void SetupCredits()
        {
            creditsCanvasGroup.alpha = 0;
            creditsCanvasGroup.gameObject.SetActive(false);
        }

        #endregion
        
        #region Public Methods

        public void Open()
        {
            optionsMenuParentPNL.SetActive(true);
            LeanTween.alphaCanvas(overlayCanvasGroup, 0, 0);
            LeanTween.alphaCanvas(overlayCanvasGroup, 1, overlayAnimationSpeed);
            LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setDelay(0.15f);
        }
        public void Close()
        {
            LeanTween.alphaCanvas(overlayCanvasGroup, 0, overlayAnimationSpeed).setDelay(0.15f);
            LeanTween.move(optionsMenuPNL, startAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setOnComplete(() => {optionsMenuParentPNL.SetActive(false);});
            
            baseOptionsPNL.SetActive(true);
            audioOptionsPNL.SetActive(false);
            controlsOptionsPNL.SetActive(false);
        }

        public void OnAudioButtonPressed()
        {
            LeanTween.move(optionsMenuPNL, startAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
            {
                titleTMP.text = "Áudio";
                decorationRT.sizeDelta = new Vector2(485, 128);
                baseOptionsPNL.SetActive(false);
                audioOptionsPNL.gameObject.SetActive(true);
                
                LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setDelay(0.15f);
            });
        }
        public void OnControlsButtonPressed()
        {
            LeanTween.move(optionsMenuPNL, startAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
            {
                titleTMP.text = "Controles";
                decorationRT.sizeDelta = new Vector2(650, 128);
                baseOptionsPNL.SetActive(false);
                controlsOptionsPNL.gameObject.SetActive(true);
                
                LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setDelay(0.15f);
            });
        }
        public void OnCreditsButtonPressed()
        {
            creditsCanvasGroup.gameObject.SetActive(true);
            LeanTween.moveLocalY(creditsDescriptionPNL, -2050, 0);
            LeanTween.move(optionsMenuPNL, startAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack);
            LeanTween.alphaCanvas(creditsCanvasGroup, 1, 1).setOnComplete(() =>
            {
                creditsTweenId = LeanTween.moveLocalY(creditsDescriptionPNL, 2050, creditsAnimationSpeed).setOnComplete(() =>
                {
                    LeanTween.alphaCanvas(creditsCanvasGroup, 0, 1).setOnComplete(() =>
                    {
                        creditsCanvasGroup.gameObject.SetActive(false);
                    });
                    LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack);
                }).id;
            });
        }
        public void OnExitCreditsButtonPressed()
        {
            LeanTween.alphaCanvas(creditsCanvasGroup, 0, 0.5f).setOnComplete(() =>
            {
                creditsCanvasGroup.gameObject.SetActive(false);
                LeanTween.cancel(creditsTweenId);
            });
            LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setDelay(0.15f).setEase(LeanTweenType.easeOutBack);
        }
        public void OnBackButtonPressed()
        {
            LeanTween.move(optionsMenuPNL, startAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
            {
                decorationRT.sizeDelta = new Vector2(512, 128);
                titleTMP.text = "Opções";
                controlsOptionsPNL.gameObject.SetActive(false);
                audioOptionsPNL.gameObject.SetActive(false);
                baseOptionsPNL.SetActive(true);
                
                LeanTween.move(optionsMenuPNL, endAnimationPoint.transform.position, optionsMenuAnimationSpeed).setEase(LeanTweenType.easeOutBack).setDelay(0.15f);
            });
        }
        
        #endregion

        #endregion
    }  
}