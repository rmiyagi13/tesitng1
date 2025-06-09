using System.Collections.Generic;

public class Character
{
    // Basic character properties
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Archetype { get; private set; } // e.g., "The Leader", "The Skeptic", etc.
    
    // Character state
    public bool IsAlive { get; private set; }
    public Dictionary<string, float> Relationships { get; private set; }
    public List<string> Traits { get; private set; }
    
    // Character history and backstory elements
    public List<string> Secrets { get; private set; }
    public Dictionary<string, bool> BackstoryFlags { get; private set; }
    
    public Character(string id, string name, string archetype)
    {
        Id = id;
        Name = name;
        Archetype = archetype;
        IsAlive = true;
        Relationships = new Dictionary<string, float>();
        Traits = new List<string>();
        Secrets = new List<string>();
        BackstoryFlags = new Dictionary<string, bool>();
    }
    
    // Character relationship methods
    public void UpdateRelationship(string targetCharacterId, float delta)
    {
        if (!Relationships.ContainsKey(targetCharacterId))
        {
            Relationships[targetCharacterId] = 0f;
        }
        
        Relationships[targetCharacterId] += delta;
        // Clamp values between -100 and 100
        Relationships[targetCharacterId] = System.Math.Clamp(Relationships[targetCharacterId], -100f, 100f);
    }
    
    // Character state methods
    public void Die()
    {
        IsAlive = false;
        // Trigger any necessary story events related to death
    }
    
    public void RevealSecret(string secretId)
    {
        // Logic for when a character's secret is revealed
        // This could trigger story events or affect relationships
    }
    
    // Interaction methods
    public void AddTrait(string trait)
    {
        if (!Traits.Contains(trait))
        {
            Traits.Add(trait);
        }
    }
    
    public void SetBackstoryFlag(string flagId, bool value)
    {
        BackstoryFlags[flagId] = value;
    }
} 