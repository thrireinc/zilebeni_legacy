namespace HiscomProject.Runtime.Scripts.Patterns.MMVCC.Controllers
{
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Controllers;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Views.Internal;
    using HiscomEngine.Runtime.Scripts.Patterns.MMVCC.Models;
    using HiscomEngine.Runtime.Scripts.Structures.Enums;

    [AddComponentMenu("Scripts/Hiscom Project/Patterns/MMVCC/Controllers/HP Dialogue Controller")]
    public class HP_DialogueController : DialogueTypewriterController
    {
        #region Variables

        #region Protected Variables

        [SerializeField] protected GameObject dialogueBoxGameObject;
        [SerializeField] protected RectTransform dialogueBoxAnimationStartPositionRT, dialogueBoxAnimationEndPositionRT;
        
        protected int boxTween;
        protected bool isAnimating;
        protected DialogueContentView previousDialogueContent;
        
        #endregion

        #endregion

        #region Methods

        #region Protected Methods

        protected void Start()
        {
            LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationStartPositionRT, 0f);
        }

        protected override void UpdateDialogue()
        {
            bool IsCurrentDialogueNull()
            {
                return Identifier.IdentifyIncident(() => currentDialogue == null, IncidentType.Error, "", gameObject);
            }
            if (IsCurrentDialogueNull()) return;
            
            var currentDialogueContent = currentDialogue.GetDialogueContent;
            if (isAnimating) return;
      
            if (isTyping)
            {
                LeanTween.cancel(typewriterId);
                subtitleTMP.text = previousDialogueContent.GetSentence;
                isTyping = false;
            }
            else
            {
                if (currentDialogueContentId == currentDialogueContent.Length)
                {
                    isAnimating = true;
                    LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationStartPositionRT, .5f).setEaseOutBack().setOnComplete(() =>
                    {
                        isAnimating = false;
                        previousDialogueContent = null;
                        EndDialogue();
                    });
                    return;
                }
                
                UpdateInterface();
            }
        }
        protected override void UpdateInterface()
        {
            var currentDialogueContent = currentDialogue.GetDialogueContent[currentDialogueContentId];
            dialogueBoxGameObject.SetActive(true);
            
            switch (previousDialogueContent == null || previousDialogueContent.GetSpeakerId != currentDialogueContent.GetSpeakerId)
            {
                case true:
                    LeanTween.cancel(boxTween);
                    isAnimating = true;
                    boxTween = LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationStartPositionRT, .5f).setEaseOutBack().setOnComplete(() =>
                    {
                        subtitleTMP.text = "";
                        UpdateSpeakerName(currentDialogueContent);
                        UpdateIcon(currentDialogueContent);
                        
                        LeanTween.move(dialogueBoxGameObject, dialogueBoxAnimationEndPositionRT, 1f).setEaseOutBack().setOnComplete(() =>
                        {
                            isAnimating = false;
                            UpdateSubtitle(currentDialogueContent);
                            UpdateDubbing(currentDialogueContent);
                        });
                    }).id;
                    break;
                
                case false:
                    UpdateSubtitle(currentDialogueContent);
                    UpdateDubbing(currentDialogueContent);
                    break;
            }    
                
            currentDialogueContentId++;
            previousDialogueContent = currentDialogueContent;
        }

        #endregion

        #endregion
    }
}