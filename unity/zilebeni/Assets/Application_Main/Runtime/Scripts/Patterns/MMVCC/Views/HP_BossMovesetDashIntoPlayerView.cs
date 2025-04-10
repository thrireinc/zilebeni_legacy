namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Rendering;
    using UnityEngine.Rendering.HighDefinition;
    using HiscomEngine.Runtime.Scripts.Structures.Extensions;
    using Internal;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Boss Moveset Dash Into Player View")]
    public class HP_BossMovesetDashIntoPlayerView : HP_MovesetMovementView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected AnimationClip startDashAnimation, endDashAnimation;
        [SerializeField] protected CanvasGroup movementCanvasGroup;
        [SerializeField] protected int numberOfDashes;
        [SerializeField] protected Rigidbody bossRigidbody;
        [SerializeField] protected GameObject bossReference, playerReference;
        [SerializeField] protected Vector3 playerLightOffset;
        [SerializeField] protected VolumeProfile defaultProfile;
        [SerializeField] protected float dashForce, animationDelay, profileLuxIntensity, sceneLuxIntensity, playerLuxIntensity;
        [SerializeField] protected Light sceneLight, playerLight;
        
        protected HDRISky defaultProfileSky;
        protected float defaultProfileLuxIntensity, defaultSceneLuxIntensity, defaultPlayerLuxIntensity;
        
        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods

        protected void Start()
        {
            if (defaultProfile.TryGet(out defaultProfileSky))
            {
                defaultProfileLuxIntensity = defaultProfileSky.desiredLuxValue.value;
                defaultSceneLuxIntensity = sceneLight.intensity;
                defaultPlayerLuxIntensity = playerLight.intensity;
            }
        }
        protected void OnDisable()
        {
            StopAllCoroutines();
        }
        protected IEnumerator HybridUpdate()
        {
            while (true)
            {
                playerLight.transform.position = playerReference.transform.position + playerLightOffset;
                yield return new WaitForSeconds(0.001f);
            }
        }

        protected IEnumerator MovementCoroutine()
        {
            StartMovement();
            yield return new WaitForSeconds(movementDuration);
            EndMovement();
        }
        protected void StartMovement()
        {
            animator.Play(idleAnimation.name);
            StartCoroutine(HybridUpdate());

            LeanTween.alphaCanvas(movementCanvasGroup, 1, .5f).setOnComplete(() =>
            {
                sceneLight.intensity = sceneLuxIntensity;
                defaultProfileSky.desiredLuxValue.value = profileLuxIntensity;

                LeanTween.value(0, 1, .5f).setOnComplete(() =>
                {
                    movementCanvasGroup.alpha = 0;
                    
                    LeanTween.value(defaultPlayerLuxIntensity, playerLuxIntensity, .5f)
                    .setOnUpdate(value =>
                    {
                        playerLight.intensity = value;
                    })
                    .setOnComplete(() =>
                    {
                        StartCoroutine(Dash());
                    });
                });
            });
        }
        protected void EndMovement()
        {
            animator.Play(idleAnimation.name);
            StopAllCoroutines();
            
            LeanTween.value(playerLuxIntensity, defaultPlayerLuxIntensity, .25f)
            .setOnUpdate(value =>
            {
                playerLight.intensity = value;
            })
            .setOnComplete(() =>
            {
                movementCanvasGroup.alpha = 1;
                
                sceneLight.intensity = defaultSceneLuxIntensity;
                defaultProfileSky.desiredLuxValue.value = defaultProfileLuxIntensity;

                LeanTween.alphaCanvas(movementCanvasGroup, 0, 0.25f);
            });
        }
        
        protected IEnumerator Dash()
        {
            bossRigidbody.Halt();
            animator.Play(startDashAnimation.name);
            yield return new WaitForSeconds(animationDelay);

            var start = bossReference.transform.position;
            var end = new Vector3(playerReference.transform.position.x, start.y, playerReference.transform.position.z);
            var direction = (end - start).normalized;
            var magnitude = (end - start).magnitude;
            var movementDuration = magnitude / dashForce;

            // Calculate the velocity needed to reach the target position in the given time
            var velocity = direction * (magnitude / movementDuration);
            var elapsedTime = 0f;
            
            animator.Play(movementAnimation.name);
            while (elapsedTime < movementDuration)
            {
                elapsedTime += Time.deltaTime;
                // Set the Rigidbody's velocity instead of using MovePosition
                bossRigidbody.velocity = velocity;
                yield return null;
            }

            // Reset the velocity after the movement is done
            bossRigidbody.velocity = Vector3.zero;

            animator.Play(endDashAnimation.name);
            yield return new WaitForSeconds((movementDuration - 1) / numberOfDashes);
            StartCoroutine(Dash());
        }
        
        #endregion

        #region Public Methods

        public override void Movement()
        {
            StartCoroutine(MovementCoroutine());
        }

        #endregion

        #endregion
    }
}