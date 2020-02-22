using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBox : MonoBehaviour
{
    public Skill skill;
    public GameObject skillPointPrefab;
    int currentLevel;
    void Start()
    {
        currentLevel = 0;
        transform.GetChild(0).GetComponent<Image>().sprite = skill.icon;
        for (int i = 0; i < skill.maxLevel; i++)
        {
            Instantiate(skillPointPrefab, transform.GetChild(1));
        }
        if (skill.hasInput)
        {
            GameObject inputGameObject = transform.GetChild(3).gameObject;
            inputGameObject.SetActive(true);
            inputGameObject.transform.GetChild(0).GetComponent<Text>().text = skill.inputName;
        } else
        {
            GetComponent<Button>().enabled = true;
        }

    }

    void Update()
    {
        
    }

    public void UpdateSkillLevel()
    {
        if (skill.maxLevel > currentLevel)
        {
            currentLevel += 1;
            Debug.Log(skill.skillName + " upgraded to level " + currentLevel + " !");
        } else
        {
            Debug.Log(skill.skillName + " is already max level !");
        }
        if (currentLevel > 0)
            transform.GetChild(1).GetChild(currentLevel - 1).GetComponent<Image>().color = new Color(255, 210, 0);
    }
}
