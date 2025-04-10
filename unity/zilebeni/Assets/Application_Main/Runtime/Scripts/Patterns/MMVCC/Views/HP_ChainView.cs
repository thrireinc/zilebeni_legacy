namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Views
{
    using UnityEngine;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Views/HP Chain View")]
    public class HP_ChainView : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected SpriteRenderer spriteRenderer;
        [SerializeField] protected BoxCollider boxCollider;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public void SetupPosition(Vector3 randomPosition)
        {
            transform.position = randomPosition;
        }
        public void SetupRotation(Vector3 randomRotation, Vector3 spriteRotation)
        {
            transform.rotation = Quaternion.Euler(randomRotation);
            spriteRenderer.transform.parent.transform.localRotation = Quaternion.Euler(spriteRotation);
        }
        public void SetupScale(Vector3 randomScale)
        {
            transform.localScale = randomScale;
        }
        public void SetupSpriteRenderer(float width)
        {
            spriteRenderer.size = new Vector2(width, spriteRenderer.size.y);
        }
        public void SetupCollider(float width)
        {
            boxCollider.transform.parent.transform.localScale = new Vector3(width, boxCollider.transform.parent.transform.localScale.y, boxCollider.transform.parent.transform.localScale.z);
        }
        public void SetupColor(Color color)
        {
            spriteRenderer.color = color;
        }

        #endregion

        #endregion
    }
}