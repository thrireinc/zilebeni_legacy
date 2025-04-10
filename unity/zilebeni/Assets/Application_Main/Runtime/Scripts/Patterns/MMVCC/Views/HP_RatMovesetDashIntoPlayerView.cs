namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using System.Collections;
    using UnityEngine;
    using Internal;
    using HiscomEngine.Runtime.Scripts.Structures.Extensions;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Managers;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Rat Moveset Dash Into Player View")]
    public class HP_RatMovesetDashIntoPlayerView : HP_MovesetMovementView
    {
        #region Variables

        #region Protected Variables
        
        [SerializeField] protected float dashForce;
        [SerializeField] protected bool isOnScene;
        [SerializeField][TagSelector] private string playerTag;
        [SerializeField] protected GameObject playerReference;
        [SerializeField] protected Rigidbody ratReference;
        [SerializeField] protected string DiP_notification;
        protected bool isDashing;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected void OnEnable()
        {
            AddObservers();
        }
        protected void OnDisable()
        {
            RemoveObservers();
        }

        protected void AddObservers()
        {
            NotificationManager.Instance.AddObserver(DiP_notification, gameObject, (sender, content) =>
            {
                if (sender == null || sender != ratReference.gameObject) return;
                Movement();
            });
        }
        protected void RemoveObservers()
        {
            NotificationManager.Instance.RemoveObservers(gameObject);
        }

        protected IEnumerator Dash()
        {
            var direction = (isOnScene ? playerReference : GameObject.FindWithTag(playerTag)).transform.position - ratReference.transform.position;
            direction.Normalize();
            ratReference.Halt();
            animator.Play(movementAnimation.name);
            ratReference.AddForce(direction * dashForce);
            yield return new WaitForSeconds(movementDuration - 1);
            isDashing = false;
        }
        
        #endregion

        #region Public Methods

        public override void Movement()
        {
            StartCoroutine(Dash());
        }

        #endregion

        #endregion
    }
}