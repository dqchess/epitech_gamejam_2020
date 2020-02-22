using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractionZoneType;


public class Attacker : MonoBehaviour
{
    // Start is called before the first frame update

    private InteractionZone interactZone = null;

    private AttackerStats stats = null;

    private void Start() {
        stats = AttackerStats.instance;
    }


    private void Update() {
        if (interactZone)
            interactZone.updateZone(stats);
    }

    private void OnTriggerEnter2D(Collider2D other) {


        Component zone = other.GetComponent("InteractionZone");
        if (zone != null) {
            interactZone = (InteractionZone)zone;
            interactZone.activate(stats);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Component zone = other.GetComponent("InteractionZone");
        if (zone != null) {
            interactZone.deactivate(stats);
            interactZone = null;

        }

    }

}
