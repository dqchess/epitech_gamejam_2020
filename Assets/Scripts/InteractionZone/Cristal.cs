using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionZoneType {
    public class Cristal : InteractionZone
    {
        public override void activate(Attacker attacker) {
            attacker.crystals += attacker.miningValue * Time.deltaTime;
        }
    }  
}