using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClassChoosingMenu : MonoBehaviour
{

    public List<ShipChoice> classChoices = new List<ShipChoice>();
    public List<UnityEvent> choicesCallback = new List<UnityEvent>();
    public GameObject choicesParent;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = classChoices[i].classImage;
            transform.GetChild(i).GetChild(0).rotation = Quaternion.Euler(0, 0, -90);
            transform.GetChild(i).GetChild(1).GetChild(0).GetComponent<Text>().text = classChoices[i].inputName;
        }
    }

    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Input.GetKeyDown(classChoices[i].input) && choicesCallback[i] != null)
                choicesCallback[i].Invoke();
        }
    }
}
