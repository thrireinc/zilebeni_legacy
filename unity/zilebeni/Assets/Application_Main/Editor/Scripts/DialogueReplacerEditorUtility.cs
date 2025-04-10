#if UNITY_EDITOR

namespace HiscomProject.Editor.Scripts
{
    using UnityEditor;
    using UnityEngine;
    using HiscomEngine.Runtime.Scripts.Structures.ScriptableObjects;
    
    public class DialogueReplacerEditorUtility : EditorWindow
    {
        #region Variables

        #region Protected Variables

        protected static readonly string DialoguesFolder = "Scriptable Objects/Dialogues";

        #endregion

        #endregion
        
        #region Methods

        #region Protected Methods
        
        [MenuItem("Window/Hiscom Engine/Dialogues/Rename dialogues' speaker name")]
        protected static void RenameDialogueSpeakerName()
        {
            foreach (var dialogueScriptableObject in Resources.LoadAll<DialogueScriptableObject>(DialoguesFolder))
            {
                foreach (var dialogueContentView in dialogueScriptableObject.GetDialogueContent)
                {
                    switch (dialogueContentView.GetSpeakerId)
                    {
                        case "character_Niara":
                            dialogueContentView.SetSpeakerName = "Niara";
                            break;
                    
                        case "character_Daktari":
                            dialogueContentView.SetSpeakerName = "Daktari";
                            break;
                    
                        case "character_Luena":
                            dialogueContentView.SetSpeakerName = "Luena";
                            break;
                    
                        case "character_Amai":
                            dialogueContentView.SetSpeakerName = "Amai";
                            break;
                    
                        case "character_Adumi":
                            dialogueContentView.SetSpeakerName = "Adumi";
                            break;
                    
                        case "character_Lenmi":
                            dialogueContentView.SetSpeakerName = "Lenmi";
                            break;
                    }
                }
                
                EditorUtility.SetDirty(dialogueScriptableObject);
            }
            
            AssetDatabase.SaveAssets();
        }

        [MenuItem("Window/Hiscom Engine/Dialogues/Replace dialogues' speaker icon")]
        protected static void ReplaceDialogueSpeakerIcon()
        {
            foreach (var dialogueScriptableObject in Resources.LoadAll<DialogueScriptableObject>(DialoguesFolder))
            {
                foreach (var dialogueContentView in dialogueScriptableObject.GetDialogueContent)
                {
                    switch (dialogueContentView.GetSpeakerId)
                    {
                        case "character_Niara":
                            dialogueContentView.SetIcon = Resources.Load<Sprite>($"{DialoguesFolder}/Icons/sprt_UI_Niara");
                            break;
                    
                        case "character_Daktari":
                            dialogueContentView.SetIcon = Resources.Load<Sprite>($"{DialoguesFolder}/Icons/sprt_UI_Daktari");
                            break;
                    
                        case "character_Luena":
                            dialogueContentView.SetIcon = Resources.Load<Sprite>($"{DialoguesFolder}/Icons/sprt_UI_Luena");
                            break;
                    
                        case "character_Amai":
                            dialogueContentView.SetIcon = Resources.Load<Sprite>($"{DialoguesFolder}/Icons/sprt_UI_Amai");
                            break;
                    
                        case "character_Adumi":
                            dialogueContentView.SetIcon = Resources.Load<Sprite>($"{DialoguesFolder}/Icons/sprt_UI_Adumi");
                            break;
                    
                        case "character_Lenmi":
                            dialogueContentView.SetIcon = Resources.Load<Sprite>($"{DialoguesFolder}/Icons/sprt_UI_Lenmi");
                            break;
                    }
                }
                
                EditorUtility.SetDirty(dialogueScriptableObject);
            }
            
            AssetDatabase.SaveAssets();
        }

        #endregion

        #endregion
    }
}

#endif