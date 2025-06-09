using System;
using System.Collections.Generic;

public class DialogueManager
{
    // Dialogue events
    public event Action<string> OnDialogueDisplayed;
    public event Action<List<string>> OnChoicesDisplayed;
    public event Action<int> OnChoiceMade;
    
    // Current dialogue state
    private string currentDialogue;
    private List<string> currentChoices;
    private List<Action> choiceActions;
    
    public DialogueManager()
    {
        choiceActions = new List<Action>();
    }
    
    // Start a conversation with dialogue but no choices
    public void StartDialogue(string dialogue)
    {
        currentDialogue = dialogue;
        OnDialogueDisplayed?.Invoke(currentDialogue);
    }
    
    // Start a conversation with dialogue and choices
    public void StartDialogueWithChoices(string dialogue, List<string> choices)
    {
        currentDialogue = dialogue;
        currentChoices = choices;
        choiceActions.Clear();
        
        OnDialogueDisplayed?.Invoke(currentDialogue);
        OnChoicesDisplayed?.Invoke(currentChoices);
    }
    
    // Add a callback for a specific choice
    public void AddChoiceAction(int choiceIndex, Action action)
    {
        while (choiceActions.Count <= choiceIndex)
        {
            choiceActions.Add(null);
        }
        
        choiceActions[choiceIndex] = action;
    }
    
    // Handle the player making a choice
    public void MakeChoice(int choiceIndex)
    {
        if (choiceIndex >= 0 && choiceIndex < currentChoices.Count)
        {
            OnChoiceMade?.Invoke(choiceIndex);
            
            // Record the choice in GameManager
            GameManager.Instance.RecordChoice(currentChoices[choiceIndex]);
            
            // Execute the associated action if one exists
            if (choiceIndex < choiceActions.Count && choiceActions[choiceIndex] != null)
            {
                choiceActions[choiceIndex].Invoke();
            }
        }
    }
    
    // Example of a timed choice implementation
    public void StartTimedChoice(string dialogue, List<string> choices, float timeLimit, Action timeoutAction)
    {
        StartDialogueWithChoices(dialogue, choices);
        
        // In a real implementation, you would start a timer here
        // When the timer expires, if no choice was made, invoke the timeoutAction
        // This is a simplified example
    }
} 