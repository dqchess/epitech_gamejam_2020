using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public Sprite icon;
    public int maxLevel;
    public List<int> price;
    public bool hasInput;
    public KeyCode input;
    public string inputName;
    public int currentLevel = 0;
    public List<UnityEvent> upgradeEvents = new List<UnityEvent>();

    public void Upgrade()
    {
        GameUI.instance.UpdateSkillLevel(this);
    }

    public void SkillUpgraded(int level)
    {
        currentLevel = level;
        if (upgradeEvents.Count > level && upgradeEvents[currentLevel - 1] != null)
            upgradeEvents[currentLevel - 1].Invoke();
    }
}
