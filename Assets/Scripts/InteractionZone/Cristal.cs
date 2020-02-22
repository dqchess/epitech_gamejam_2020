using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionZoneType { 
    public class Cristal : InteractionZone
    {
        private void Start() {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();

        }

         public override void updateZone(Attacker attacker) {
            attacker.crystals += attacker.miningValue * Time.deltaTime;
        }
        public override void activate(Attacker attacker) {
              this.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
        }
        public override void deactivate(Attacker attacker) {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();
       }
    }  
}