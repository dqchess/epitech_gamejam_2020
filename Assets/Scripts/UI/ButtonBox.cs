using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonBox : MonoBehaviour
{
    public string skillName;
    public bool canBuy;
    private Text priceText;
    public Sprite icon;
    public int price;

    public UnityEvent callbackEvent = new UnityEvent();
    void Start()
    {
        priceText = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        canBuy = false;
        transform.GetChild(0).GetComponent<Image>().sprite = icon;
        priceText.text = price.ToString();
    }

    void Update()
    {
        float crystalsNb = Defenser.instance.crystals;
        if (canBuy == false && crystalsNb >= price)
        {
            canBuy = true;
            priceText.color = new Color(0, 255, 0);
        }
        else if (canBuy == true && crystalsNb < price)
        {
            canBuy = false;
            priceText.color = new Color(255, 0, 0);
        }
    }
    public void Use()
    {
        float crystalsNb = Defenser.instance.crystals;
        if (crystalsNb >= price)
        {
            Defenser.instance.crystals -= price;
            Transform priceGameObject = transform.GetChild(1);
            if (priceGameObject.gameObject.activeSelf)
            {
                priceText.text = price.ToString();
            }
            if (callbackEvent != null)
                callbackEvent.Invoke();
            Debug.Log(skillName + " used !");
        }
        else
        {
            Debug.Log(skillName + " couldn't be used because you don't have enough crystals !");
        }
    }
}
