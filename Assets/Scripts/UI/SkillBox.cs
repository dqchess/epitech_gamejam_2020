using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SkillBox : MonoBehaviour
{
    public Skill skill;
    public GameObject skillPointPrefab;
    int currentLevel;
    List<Color> colors = new List<Color>();

    public List<UnityEvent> upgradeEvents = new List<UnityEvent>();
    void Start()
    {
        colors.Add(new Color(0, 0, 255));
        colors.Add(new Color(255, 255, 0));
        colors.Add(new Color(255, 0, 0));
        currentLevel = 0;
        transform.GetChild(0).GetComponent<Image>().sprite = skill.icon;
        for (int i = 0; i < skill.levelThreshold; i++)
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
        if (skill.price.Count == skill.maxLevel)
        {
            transform.GetChild(2).GetChild(0).GetComponent<Text>().text = skill.price[0].ToString();
            transform.GetChild(2).gameObject.SetActive(true);
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
            skill.currentLevel = currentLevel;
            Transform priceGameObject = transform.GetChild(2);
            if (priceGameObject.gameObject.activeSelf)
            {
                if (currentLevel >= skill.maxLevel)
                {
                    priceGameObject.gameObject.SetActive(false);
                } else
                {
                    priceGameObject.GetChild(0).GetComponent<Text>().text = skill.price[currentLevel].ToString();
                }
            }
            skill.SkillUpgraded(currentLevel);
            if (upgradeEvents.Count >= currentLevel && upgradeEvents[currentLevel - 1] != null)
                upgradeEvents[currentLevel - 1].Invoke();
            Debug.Log(skill.skillName + " upgraded to level " + currentLevel + " !");
        } else
        {
            Debug.Log(skill.skillName + " is already max level !");
        }
        if (currentLevel > 0)
        {
            transform.GetChild(1).GetChild((currentLevel - 1) % skill.levelThreshold).GetComponent<Image>().color = colors[(int)(((currentLevel - 1) / skill.levelThreshold) + (3 - skill.maxLevel / skill.levelThreshold))];
        }
    }   
}
