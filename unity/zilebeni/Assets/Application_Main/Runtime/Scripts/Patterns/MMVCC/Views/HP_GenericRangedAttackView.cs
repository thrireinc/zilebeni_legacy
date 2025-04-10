namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views.Internal;
    using HiscomEngine.Runtime.Scripts.Structures.Extensions;
    using HiscomEngine.Runtime.Scripts.Structures.Extensions;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Generic Ranged Attack View")]
    public class HP_GenericRangedAttackView : RangedCombatView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected GameObject debugCube;

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected override void Move(bool canMove)
        {
            UpdateRotation();
            base.Move(canMove);
        }
        
        protected virtual void UpdateRotation()
        {
            var gunLocalScale = gunTransform.localScale.Abs();
            var mousePosition = InputExtensions.GetMouseWorldPosition();
            var cameraRotation = Quaternion.Euler(-35, 0, 0);
            var direction = cameraRotation * (mousePosition - gunTransform.position);
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            gunTransform.rotation = Quaternion.Euler(35, 0, angle);
            
            if (InputExtensions.GetMouseViewportPosition().x > 0.5f)
                UpdateTowardsRight();
            else
                UpdateTowardsLeft();
            return;

            void UpdateTowardsLeft()
            {
                playerView.GetComponent<Rigidbody>().transform.Flip(Vector3.left);
                gunTransform.localScale = new Vector3(gunLocalScale.x * -1, gunLocalScale.y * -1, gunLocalScale.z);
            }
            void UpdateTowardsRight()
            {
                playerView.GetComponent<Rigidbody>().transform.Flip(Vector3.right);
                gunTransform.localScale = new Vector3(gunLocalScale.x, gunLocalScale.y, gunLocalScale.z);
            }
        }
        protected override void ShootWithMouse(BulletView instance)
        {
            var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            Physics.Raycast(ray, out var hit);
            if (hit.collider == null) return;
            //Instantiate(debugCube, hit.point, Quaternion.identity);
            instance.Move((hit.point - bulletSpawn.position).normalized);
            movementSound.Play();
            canMoveEvent?.Invoke();
        }
        protected override void ShootWithoutMouse(BulletView instance)
        {
            
        }

        #endregion

        #endregion
    }
}