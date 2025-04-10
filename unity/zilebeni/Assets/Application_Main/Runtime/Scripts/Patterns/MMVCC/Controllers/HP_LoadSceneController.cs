namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;

    public class HP_LoadSceneController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected float iconChangeRate;
        [SerializeField] protected GameObject[] icons;
        protected int currentIndex;
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void Start()
        {
            currentIndex = 0;
            LeanTween.cancelAll();
            InvokeRepeating(nameof(ChangeIcon), 0, iconChangeRate);
        }

        protected void ChangeIcon()
        {
            foreach (var icon in icons)
                icon.SetActive(false);
            
            icons[currentIndex].SetActive(true);
            currentIndex = currentIndex == icons.Length - 1 ? 0 : currentIndex + 1;
        }

        #endregion

        #endregion
    }
}