using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SkillBox : MonoBehaviour
{
    public Skill skill;
    public bool canBuy;
    public GameObject skillPointPrefab;
    int currentLevel;
    List<Color> colors = new List<Color>();
    private Text priceText;

    public List<UnityEvent> upgradeEvents = new List<UnityEvent>();
    void Start()
    {
        priceText = transform.GetChild(2).GetChild(0).GetComponent<Text>();
        canBuy = false;
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
            priceText.text = skill.price[0].ToString();
            transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (skill.price.Count > currentLevel)
        {
            float crystalsNb = (skill.hasInput) ? AttackerStats.instance.crystals : Defenser.instance.crystals;
            if (canBuy == false && crystalsNb >= skill.price[currentLevel])
            {
                canBuy = true;
                priceText.color = new Color(0, 255, 0);
            }
            else if (canBuy == true && crystalsNb < skill.price[currentLevel])
            {
                canBuy = false;
                priceText.color = new Color(255, 0, 0);
            }
        }
    }
    public void UpdateSkillLevel()
    {
        float crystalsNb = (skill.hasInput) ? AttackerStats.instance.crystals : Defenser.instance.crystals;
        if (skill.maxLevel > currentLevel && skill.price.Count > currentLevel && crystalsNb >= skill.price[currentLevel])
        {
            AttackerStats.instance.crystals -= (skill.hasInput) ? skill.price[currentLevel] : 0;
            Defenser.instance.crystals -= (skill.hasInput) ? 0 : skill.price[currentLevel];
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
                    priceText.text = skill.price[currentLevel].ToString();
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

    public void ResetLevel()
    {
        Debug.Log("Reset " + name);
        currentLevel = 0;
        for (int i = 0; i < skill.levelThreshold; i++)
        {
            transform.GetChild(1).GetChild(i).GetComponent<Image>().color = new Color(0, 0, 0);
        }
        Transform priceGameObject = transform.GetChild(2);
        if (priceGameObject.gameObject.activeSelf)
        {
            if (currentLevel >= skill.maxLevel)
            {
                priceGameObject.gameObject.SetActive(false);
            }
            else
            {
                priceText.text = skill.price[currentLevel].ToString();
            }
        }
    }
}
