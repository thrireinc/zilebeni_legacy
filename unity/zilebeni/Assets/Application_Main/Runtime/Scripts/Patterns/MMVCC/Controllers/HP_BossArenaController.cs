namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using UnityEngine.Events;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Controllers/HP Boss Arena Controller")]
    public class HP_BossArenaController : MonoBehaviour
    {
        #region Variables

        [SerializeField] protected Camera mainCamera;
        [SerializeField] protected float zAnimationPosition;
        [SerializeField] protected GameObject[] walls;
        [SerializeField] protected UnityEvent onCameraAnimated;
        [SerializeField] protected HP_CameraLimitsView cameraLimits;
        
        
        #endregion

        #region Methods
        
        #region Public Methods
        
        public void OnEnterArena()
        {
            LeanTween.moveZ(mainCamera.gameObject, zAnimationPosition, 1.75f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
            {
                foreach (var wall in walls)
                    LeanTween.value(wall, 1, 0, 1).setOnUpdate(value =>
                    {
                        wall.GetComponent<SpriteRenderer>().material.SetFloat("_Alpha", value);
                    })
                    .setOnComplete(() =>
                    {
                        wall.transform.parent.transform.parent.gameObject.SetActive(false);
                    });
                
                onCameraAnimated?.Invoke();
                cameraLimits.enabled = true;
            });
        }
        
        #endregion

        #endregion
    }
}