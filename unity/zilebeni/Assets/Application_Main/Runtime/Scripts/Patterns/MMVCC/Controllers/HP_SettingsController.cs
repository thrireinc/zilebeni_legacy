namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using UnityEngine.Audio;
    using Settings = Models.HP_Constants.Settings;
    using Input = HiscomEngine.Runtime.Scripts.Structures.Extensions.InputExtensions;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Controllers/HP Settings Controller")]
    public class HP_SettingsController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected AudioMixer audioMixer;

        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void Start()
        {
            audioMixer.SetFloat(Settings.MasterVolume, PlayerPrefs.GetFloat(Settings.MasterVolume));
            audioMixer.SetFloat(Settings.MusicVolume, PlayerPrefs.GetFloat(Settings.MusicVolume));
            audioMixer.SetFloat(Settings.SFXVolume, PlayerPrefs.GetFloat(Settings.SFXVolume));
        }

        #endregion
        
        #region Public Methods

        public virtual void OnMainVolumeSliderValueChanged(float value)
        {
            PlayerPrefs.SetFloat(Settings.MasterVolume, value);
            audioMixer.SetFloat(Settings.MasterVolume, value);
        }
        public virtual void OnMusicVolumeSliderValueChanged(float value)
        {
            PlayerPrefs.SetFloat(Settings.MusicVolume, value);
            audioMixer.SetFloat(Settings.MusicVolume, value);
        }
        public virtual void OnSFXVolumeSliderValueChanged(float value)
        {
            PlayerPrefs.SetFloat(Settings.SFXVolume, value);
            audioMixer.SetFloat(Settings.SFXVolume, value);
        }
        public virtual void OnMouseSensibilitySliderValueChanged(float value)
        {
            PlayerPrefs.SetFloat(Settings.MouseSensibility, value);
        }

        #endregion

        #endregion
    }
}