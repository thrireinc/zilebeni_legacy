using System;

namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using FancyCarouselView.Runtime.Scripts;
    using EasingCore;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Managers;
    using Views;
    using Views.Internal;
    
    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Controllers/HP Death Menu Controller")]
    public class HP_DeathMenuController : CarouselView<string, HP_DeathMenuCardView>
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected float changeSelectedCellSpeed;
        [SerializeField] protected HP_NPCSpawnController npcSpawnController;
        [SerializeField] protected CanvasGroup deathMenuCanvasGroup, tentacleCanvasGroup;
        
        protected List<HP_DeathMenuCardView> cells = new ();
        protected string selectedNpcId;
        
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
        protected void Awake()
        {
            Context.CarouselCellInstantiated += (cell) =>
            {
                cells.Add(cell);
            };
        }
        protected void Start()
        {
            deathMenuCanvasGroup.alpha = tentacleCanvasGroup.alpha = 0;
            UpdateSelectedCell(0);
            ActiveCellChanged += UpdateSelectedCell;
        }
        protected void AddObservers()
        {
            NotificationManager.Instance.AddObserver("carouselUpdated", gameObject, (_, data) =>
            {
                var deathMenuItem = (HP_DeathMenuItemView)data;
                
                foreach (var npc in npcSpawnController.GetNpcsReferences.Where(npc => npc.GetNpcId == deathMenuItem.id))
                {
                    deathMenuItem.card.NpcNameTMP.text = npc.GetNpcName;
                    deathMenuItem.card.NpcSplashArtIMG.sprite = npc.GetNpcSplashScreenArtSprite;
                    deathMenuItem.card.Id = npc.GetNpcId;
                    break;
                }
            });
        }
        protected void RemoveObservers()
        {
            NotificationManager.Instance.RemoveObservers(gameObject);
        }
        protected void UpdateSelectedCell(int id)
        {
            cells[id].BgIMG.color = new Color(93 / 255f, 24 / 255f, 49 / 255f, 1);
            selectedNpcId = cells[id].Id;
        }

        #endregion

        #region Public Methods

        public void OnNextButtonPressed()
        {
            foreach (var cell in cells)
                cell.BgIMG.color = new Color(51 / 255f, 29 / 255f, 66 / 255f, 1);

            ScrollToAfter(changeSelectedCellSpeed, Ease.InOutSine);
        }
        public void OnPreviousButtonPressed()
        {
            foreach (var cell in cells)
                cell.BgIMG.color = new Color(51 / 255f, 29 / 255f, 66 / 255f, 1);

            ScrollToBefore(changeSelectedCellSpeed, Ease.InOutSine);
        }
        
        public void OnDeathMenuOpened()
        {
            Setup(npcSpawnController.GetNpcsIds);
            LeanTween.alphaCanvas(deathMenuCanvasGroup, 1, .5f).setEaseInExpo().setIgnoreTimeScale(true);
        }
        public void OnKillButtonPressed()
        {
            var killedNpc = npcSpawnController.GetNpcsReferences.FirstOrDefault(npc => npc.GetNpcId == selectedNpcId);
            npcSpawnController.GetNpcsReferences.Remove(killedNpc);
            npcSpawnController.GetNpcsIds.Remove(killedNpc.GetNpcId);
            killedNpc.gameObject.SetActive(false);

            LeanTween.alphaCanvas(tentacleCanvasGroup, 1, 1f).setOnComplete(() =>
            {
                LeanTween.value(0, 1, 0).setDelay(5).setOnComplete(() =>
                {
                   // Passar fase 
                });
            });
        }

        #endregion

        #endregion
    }
}