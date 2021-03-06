﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public Sprite icon;
    public int maxLevel;
    public int levelThreshold;
    public List<int> price;
    public bool hasInput;
    public KeyCode input;
    public string inputName;
    public int currentLevel = 0;

    public void Upgrade()
    {
        GameUI.instance.UpdateSkillLevel(this);
    }

    public void SkillUpgraded(int level)
    {
        currentLevel = level;
    }
}
