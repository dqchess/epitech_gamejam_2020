using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpShip : MonoBehaviour
{

    public GameObject intialShip;

    public GameObject DestroyerClass3;
    public GameObject SniperClass3;
    public GameObject SpeedyClass3;

    public GameObject DestroyerChoice;
    public GameObject SniperChoice;
    public GameObject SpeedyChoice;
    private GameObject shipClass2GO;
    private string shipClass2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void choiceClass3() {
        Debug.Log(shipClass2);
        if (shipClass2 == "destroyer")
            DestroyerChoice.SetActive(true);
        else if (shipClass2 == "sniper")
            SniperChoice.SetActive(true);
        else if (shipClass2 == "speedy")
            SpeedyChoice.SetActive(true);
    }

    public void LevelUpshipClass2(GameObject newShip) {
        intialShip.SetActive(false);
        newShip.SetActive(true);
        shipClass2GO = newShip;
        shipClass2 = newShip.name;
        // Debug.Log(gameObject.transform.GetChild(0).gameObject.GetActive());
    }

    public void LevelUpShipDestroyerClass3(GameObject newShip) {
        shipClass2GO.SetActive(false);
        DestroyerClass3.SetActive(true);
        newShip.SetActive(true);
        // Debug.Log(gameObject.transform.GetChild(0).gameObject.GetActive());
    }

    public void LevelUpShipSniperClass3(GameObject newShip) {
        shipClass2GO.SetActive(false);
        SniperClass3.SetActive(true);
        newShip.SetActive(true);
        // Debug.Log(gameObject.transform.GetChild(0).gameObject.GetActive());
    }
    
    public void LevelUpShipSpeedyClass3(GameObject newShip) {
        shipClass2GO.SetActive(false);
        SpeedyClass3.SetActive(true);
        newShip.SetActive(true);
        // Debug.Log(gameObject.transform.GetChild(0).gameObject.GetActive());
    }
}
