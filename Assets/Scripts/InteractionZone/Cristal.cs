using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractionZoneType { 
    public class Cristal : InteractionZone
    {
        private void Start() {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();

        }

         public override void updateZone(AttackerStats attacker) {
            attacker.crystals += attacker.miningValue * Time.deltaTime;
        }
        public override void activate(AttackerStats attacker) {
              this.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
        }
        public override void deactivate(AttackerStats attacker) {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();
       }
    }  
}