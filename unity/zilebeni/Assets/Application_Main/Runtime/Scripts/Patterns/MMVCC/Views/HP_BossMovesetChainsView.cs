namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Internal;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Boss Moveset Chains View")]
    public class HP_BossMovesetChainsView : HP_MovesetMovementView
    {
        #region Variables

        #region Protected Variables
        
        [SerializeField] protected HP_ChainView chainReference;
        [SerializeField] protected HP_ChainInstantiationBoundsView bounds;
        protected List<Vector3> takenPositions = new();
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods
        
        protected void OnDisable()
        {
            StopAllCoroutines();
        }
        protected IEnumerator MovementCoroutine()
        {
            for (var i = 0; i < movementDuration; i++)
            {
                var randomPosition = Vector3.zero;
                var randomRotation = Vector3.zero;
                var randomScale = Vector3.zero;
                var spriteRotation = Vector3.zero;
                var maxWidth = 0f;
                
                do
                {
                    var randomWall = Random.Range(1, 5);
                    switch (randomWall)
                    {
                        case 1: // Left
                            randomPosition = new Vector3(bounds.GetLowerLeft.position.x, bounds.GetLowerLeft.position.y, Random.Range(bounds.GetLowerLeft.position.z, bounds.GetUpperLeft.position.z));
                            randomRotation = new Vector3(0, 0, 0);
                            randomScale = new Vector3(1, 1, 1);
                            spriteRotation = new Vector3(25, 0, 0);
                            maxWidth = Vector3.Distance(bounds.GetLowerLeft.position, bounds.GetLowerRight.position);
                            break;
                        
                        case 2: // Top
                            randomPosition = new Vector3(Random.Range(bounds.GetUpperLeft.position.x, bounds.GetUpperRight.position.x), bounds.GetUpperLeft.position.y, bounds.GetUpperLeft.position.z);
                            randomRotation = new Vector3(0, 90, 0);
                            randomScale = new Vector3(1.75f, 1.2f, 0.975f);
                            spriteRotation = new Vector3(-90, 0, 0);
                            maxWidth = Vector3.Distance(bounds.GetLowerLeft.position, bounds.GetUpperLeft.position) / 1.75f;
                            break;
                        
                        case 3: // Right
                            randomPosition = new Vector3(bounds.GetUpperRight.position.x, bounds.GetUpperRight.position.y, Random.Range(bounds.GetLowerRight.position.z, bounds.GetUpperRight.position.z));
                            randomRotation = new Vector3(0, 180, 0);
                            randomScale = new Vector3(1, 1, 1);
                            spriteRotation = new Vector3(-25, 0, 0);
                            maxWidth = Vector3.Distance(bounds.GetUpperLeft.position, bounds.GetUpperRight.position);
                            break;
                        
                        case 4: // Bottom
                            randomPosition = new Vector3(bounds.GetLowerRight.position.x, bounds.GetLowerRight.position.y, Random.Range(bounds.GetLowerLeft.position.z, bounds.GetLowerRight.position.z));
                            randomRotation = new Vector3(0, 270, 0);
                            randomScale = new Vector3(1.75f, 1.2f, 0.975f);
                            spriteRotation = new Vector3(90, 0, 0);
                            maxWidth = Vector3.Distance(bounds.GetLowerRight.position, bounds.GetUpperRight.position) / 1.75f;
                            break;
                    }
                } 
                while (IsPositionAlreadyTaken(randomPosition));
                
                takenPositions.Add(randomPosition);
                
                var placeholder = Instantiate(chainReference);
                placeholder.SetupPosition(randomPosition);
                placeholder.SetupRotation(randomRotation, spriteRotation);
                placeholder.SetupScale(randomScale);
                placeholder.SetupColor(new Color(1, 1, 1, 0.25f));

                LeanTween.value(0, maxWidth, 0.25f).setOnUpdate(value =>
                {
                    placeholder.SetupSpriteRenderer(value);
                }).setOnComplete(() =>
                {
                    LeanTween.value(0, 1, 0.5f).setOnComplete(() =>
                    {
                        var instance = Instantiate(chainReference);
                        instance.SetupPosition(randomPosition);
                        instance.SetupRotation(randomRotation, spriteRotation);
                        instance.SetupScale(randomScale);
                    
                        LeanTween.value(0, maxWidth, 0.5f)
                        .setOnUpdate(value =>
                        {
                            instance.SetupSpriteRenderer(value);
                            instance.SetupCollider(value);
                        })
                        .setOnComplete(() =>
                        {
                            placeholder.gameObject.SetActive(false);
                        
                            LeanTween.value(maxWidth, 0, 0.5f).setOnUpdate(value => 
                            {
                                instance.SetupSpriteRenderer(value);
                                instance.SetupCollider(value);
                            })
                            .setOnComplete(() =>
                            {
                                takenPositions.Remove(randomPosition);
                                Destroy(instance.gameObject);
                            })
                            .setDelay(1f);
                        });
                    });
                });
                
                yield return new WaitForSeconds(0.5f / 4);
                yield return new WaitForSeconds(2.75f / 4);
            }
        }
        protected IEnumerator BackToIdle()
        {
            yield return new WaitForSeconds(14);
            animator.Play(idleAnimation.name);
        }
        protected bool IsPositionAlreadyTaken(Vector3 position)
        {
            return takenPositions.Any(takenPosition => takenPosition.x - 1 <= position.x && takenPosition.x + 1 >= position.x && takenPosition.y - 1 <= position.y && takenPosition.y + 1 >= position.y && takenPosition.z - 1 <= position.z && takenPosition.z + 1 >= position.z);
        }
        
        #endregion
        
        #region Public Methods

        public override void Movement()
        {
            animator.Play(movementAnimation.name);
            StartCoroutine(MovementCoroutine());
            StartCoroutine(BackToIdle());
        }

        #endregion

        #endregion
    }
}