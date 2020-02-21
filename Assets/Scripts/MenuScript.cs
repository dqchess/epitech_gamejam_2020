using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    int index;
    Button selectedButton;
    void Start()
    {
        index = 0;
        selectedButton = null;
    }

    void Update()
    {
        if (Input.GetKeyDown("Down") && index < buttons.Count - 1)
        {
            index += 1;
            selectedButton = buttons[index];
            UpdateSelectedButton();
        } else if (Input.GetKeyDown("Up") && index > 0)
        {
            index -= 1;
            selectedButton = buttons[index];
            UpdateSelectedButton();
        } else if (Input.GetButtonDown("Submit"))
        {
            selectedButton.onClick.Invoke();
        }
    }

    void UpdateSelectedButton()
    {
        foreach (Button button in buttons)
        {
            button.transform.GetChild(1).gameObject.SetActive(false);
        }
        selectedButton.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void SelectButton(Button newButton)
    {
        index = newButton.transform.GetSiblingIndex();
        selectedButton = newButton;
        UpdateSelectedButton();
    }
}
