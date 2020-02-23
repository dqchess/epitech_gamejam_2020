using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    #region Singleton

    public static GameUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameUI");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnGameUIChanged();
    public OnGameUIChanged OnGameUIChangedCallback;

    public Transform attackSideParent;
    public Transform defenseSideParent;
    public Text attackCrystalCount;
    public Text defenseCrystalCount;

    [SerializeField]
    List<SkillBox> attackSkillBoxes = new List<SkillBox>();

    [SerializeField]
    List<SkillBox> defenseSkillBoxes = new List<SkillBox>();

    [SerializeField]
    public List<SkillBox> autoTurretBoxes = new List<SkillBox>();

    void Start()
    {
        for (int i = 0; i < attackSideParent.childCount; i++)
        {
            SkillBox tmp = attackSideParent.GetChild(i).GetComponent<SkillBox>();
            if (tmp)
                attackSkillBoxes.Add(tmp);
        }
        for (int i = 0; i < defenseSideParent.childCount; i++)
        {
            SkillBox tmp = defenseSideParent.GetChild(i).GetComponent<SkillBox>();
            if (tmp)
                defenseSkillBoxes.Add(tmp);
        }
    }

    private void Update()
    {
        foreach (SkillBox attackBox in attackSkillBoxes)
        {
            if (Input.GetKeyDown(attackBox.skill.input))
                attackBox.skill.Upgrade();
        }
        attackCrystalCount.text = ((int)(AttackerStats.instance.crystals)).ToString();
        defenseCrystalCount.text = ((int)(Defenser.instance.crystals)).ToString();
    }

    public void UpdateSkillLevel(Skill skillUpgraded)
    {
        SkillBox skillBoxUpgraded = findSkillInBoxes(skillUpgraded);
        if (skillBoxUpgraded)
            skillBoxUpgraded.UpdateSkillLevel();
    }

    SkillBox findSkillInBoxes(Skill skillSearched)
    {
        foreach (SkillBox attackBox in attackSkillBoxes)
        {
            if (attackBox.skill == skillSearched)
                return attackBox;
        }
        foreach (SkillBox defenseBox in defenseSkillBoxes)
        {
            if (defenseBox.skill == skillSearched)
                return defenseBox;
        }
        foreach (SkillBox autoTurretBox in autoTurretBoxes)
        {
            if (autoTurretBox.skill == skillSearched)
                return autoTurretBox;
        }
        return null;
    }
}
