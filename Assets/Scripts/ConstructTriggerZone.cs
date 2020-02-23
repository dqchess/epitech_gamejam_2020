using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructTriggerZone : MonoBehaviour
{
    public GameObject bubble;
    private void OnMouseOver()
    {
        bubble.SetActive(true);
    }

    private void OnMouseExit()
    {
        bubble.SetActive(false);
        gameObject.SetActive(false);
    }
}
