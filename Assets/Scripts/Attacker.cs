using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionZoneType;


public class Attacker : MonoBehaviour
{
    // Start is called before the first frame update
    public float crystals = 100;
    public float miningValue = 1;
    private InteractionZone interactZone = null;


    private void Update() {
        if (interactZone)
            interactZone.activate(this);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Component zone = other.GetComponent("InteractionZone");
        if (zone != null) {
            interactZone = (InteractionZone)zone;
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        interactZone = null;
    }

}
