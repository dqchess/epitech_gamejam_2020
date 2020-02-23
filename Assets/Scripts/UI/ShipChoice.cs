using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Class")]
public class ShipChoice : ScriptableObject
{
    public string className;
    public Sprite classImage;
    public KeyCode input;
    public string inputName;
}
