using System.Collections;
using System.Collections.Generic;

public class GameManager
{
    // Singleton pattern for game manager
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    // Game state tracking
    public Dictionary<string, float> CharacterRelationships { get; private set; }
    public List<string> PlayerChoices { get; private set; }
    public Dictionary<string, bool> StoryFlags { get; private set; }

    private GameManager()
    {
        // Initialize game state
        CharacterRelationships = new Dictionary<string, float>();
        PlayerChoices = new List<string>();
        StoryFlags = new Dictionary<string, bool>();
    }

    // Methods for tracking player choices and their consequences
    public void RecordChoice(string choiceId)
    {
        PlayerChoices.Add(choiceId);
        // TODO: Implement butterfly effect consequences
    }

    public void UpdateRelationship(string characterId, float delta)
    {
        if (!CharacterRelationships.ContainsKey(characterId))
        {
            CharacterRelationships[characterId] = 0f;
        }
        
        CharacterRelationships[characterId] += delta;
    }

    public void SetStoryFlag(string flagId, bool value)
    {
        StoryFlags[flagId] = value;
    }

    // Game state management
    public void SaveGame()
    {
        // TODO: Implement save functionality
    }

    public void LoadGame()
    {
        // TODO: Implement load functionality
    }
} 