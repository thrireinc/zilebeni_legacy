namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Internal;

    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Boss Moveset Spawn Enemy View")]
    public class HP_BossMovesetSpawnEnemyView : HP_MovesetMovementView
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected HP_EnemyView enemyReference;
        [SerializeField] protected int numberOfHordes, numberOfEnemiesPerSpawn;
        [SerializeField] protected float timeBetweenEnemies, timeBetweenHordes;
        [SerializeField] protected Transform[] spawnPoints;
        protected List<HP_EnemyView> instantiatedEnemies = new();

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
            for (var i = 0; i < numberOfHordes; i++)
            {
                animator.Play(movementAnimation.name);
                
                for (var j = 0; j < numberOfEnemiesPerSpawn; j++)
                {
                    foreach (var spawnPoint in spawnPoints)
                    {
                        var instance = Instantiate(enemyReference, spawnPoint.position, Quaternion.identity);
                        instantiatedEnemies.Add(instance);
                        yield return new WaitForSeconds(timeBetweenEnemies);
                    }
                }

                animator.Play(idleAnimation.name);
                yield return new WaitForSeconds(timeBetweenHordes);
            }

            yield return new WaitForSeconds(movementDuration);

            foreach (var instantiatedEnemy in instantiatedEnemies.Where(instantiatedEnemy => instantiatedEnemy != null))
                Destroy(instantiatedEnemy.gameObject);

            instantiatedEnemies.Clear();
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