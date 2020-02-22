using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    int index;
    Button selectedButton;

    bool verticalAxisKey;
    void Start()
    {
        index = 0;
        selectedButton = null;
        verticalAxisKey = false;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") == -1 && index < buttons.Count - 1 && !verticalAxisKey)
        {
            index += 1;
            selectedButton = buttons[index];
            UpdateSelectedButton();
            verticalAxisKey = true;
        }
        else if (Input.GetAxisRaw("Vertical") == 1 && index > 0 && !verticalAxisKey)
        {
            index -= 1;
            selectedButton = buttons[index];
            UpdateSelectedButton();
            verticalAxisKey = true;
        } else if (Input.GetAxisRaw("Vertical") == 0 && verticalAxisKey)
        {
            verticalAxisKey = false;
        }
        if (Input.GetButtonDown("Submit"))
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
