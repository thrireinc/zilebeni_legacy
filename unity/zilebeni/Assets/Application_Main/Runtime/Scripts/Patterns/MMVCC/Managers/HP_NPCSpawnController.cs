namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Views;
    
    public class HP_NPCSpawnController : MonoBehaviour
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected List<string> npcsIds;
        protected List<HP_NPCView> npcsReferences = new ();
        
        #endregion
        
        #region Public Variables
        
        public List<string> GetNpcsIds => npcsIds;
        public List<HP_NPCView> GetNpcsReferences => npcsReferences;
        
        #endregion

        #endregion

        #region Methods

        #region Public Methods

        public virtual void OnDayStarted()
        {
            foreach (var npc in FindObjectsOfType<HP_NPCView>())
            {
                if (!npc.gameObject.activeSelf) continue;
                npc.gameObject.SetActive(false);
                if (npcsIds.All(id => id != npc.GetNpcId)) continue;
                npcsReferences.Add(npc);
                npc.gameObject.SetActive(true);
            }
        }

        #endregion

        #endregion
    }
}