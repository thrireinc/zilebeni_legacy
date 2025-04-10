namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using System.Collections;
    using UnityEngine;
    
    public class HP_CameraLimitsView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected GameObject target;
        [SerializeField] protected Vector2 horizontalLimits, verticalLimits;
        protected Vector3 offset;
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods
        
        protected void OnEnable()
        {
            transform.parent = null;
            offset = transform.position - target.transform.position;
            StartCoroutine(HybridUpdate());
        }

        protected void OnDisable()
        {
            StopAllCoroutines();
        }

        protected IEnumerator HybridUpdate()
        {
            while (true)
            {
                var position = target.transform.position + offset;
                position.x = Mathf.Clamp(position.x, horizontalLimits.x, horizontalLimits.y);
                position.z = Mathf.Clamp(position.z, verticalLimits.x, verticalLimits.y);
                transform.position = new Vector3(position.x, transform.position.y, position.z);
                
                yield return new WaitForSeconds(0.01f);
            }
        }

        #endregion

        #endregion
    }
}