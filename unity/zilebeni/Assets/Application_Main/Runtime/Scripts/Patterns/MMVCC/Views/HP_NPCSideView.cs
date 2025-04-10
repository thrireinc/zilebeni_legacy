namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using System.Collections;
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Structures.Extensions;
    
    public class HP_NPCSideView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected GameObject player;
        [SerializeField] protected bool invertAxis;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected void Start()
        {
            StartCoroutine(HybridUpdate());
        }

        protected IEnumerator HybridUpdate()
        {
            var left = transform.localScale.Abs().Multiply(new Vector3(-1, 1, 1));
            var right = transform.localScale.Abs();
            
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                transform.localScale = player.transform.position.x > transform.position.x ?  invertAxis ? left : right : invertAxis ? right : left;
            }
        }

        #endregion

        #endregion
    }
}