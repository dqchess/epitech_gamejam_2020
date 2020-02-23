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
    private string shipClass2 = "lvl1";

    private int lvlClass3 = -1;

    private int lvlShip = 1;

    public HealthBar playerHealthBar;

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
        newShip.transform.position = intialShip.transform.position;
        newShip.transform.rotation = intialShip.transform.rotation;
        newShip.GetComponent<Rigidbody2D>().velocity = intialShip.GetComponent<Rigidbody2D>().velocity;
        newShip.GetComponent<Rigidbody2D>().angularVelocity = intialShip.GetComponent<Rigidbody2D>().angularVelocity;
        newShip.SetActive(true);
        if (lvlShip == 1)
            newShip.transform.GetChild(1).gameObject.SetActive(true);
        else if (lvlShip == 2)
            newShip.transform.GetChild(2).gameObject.SetActive(true);
        else if (lvlShip == 3)
            newShip.transform.GetChild(3).gameObject.SetActive(true);
        shipClass2GO = newShip;
        shipClass2 = newShip.name;
        playerHealthBar.attachedTo = newShip.transform;
        playerHealthBar.topOffset = 75;
        // Debug.Log(gameObject.transform.GetChild(0).gameObject.GetActive());
    }

    public void LevelUpShipDestroyerClass3(int choice) {
        GameObject currentShip = null;
        lvlClass3 = choice;
        shipClass2GO.SetActive(false);
        DestroyerClass3.transform.position = shipClass2GO.transform.position;
        DestroyerClass3.transform.rotation = shipClass2GO.transform.rotation;
        DestroyerClass3.GetComponent<Rigidbody2D>().velocity = shipClass2GO.GetComponent<Rigidbody2D>().velocity;
        DestroyerClass3.SetActive(true);
        if (choice == 1) {
            if (lvlShip == 1)
                currentShip = DestroyerClass3.transform.GetChild(1).gameObject;
            else if (lvlShip == 2)
                currentShip = DestroyerClass3.transform.GetChild(2).gameObject;
            else if (lvlShip == 3)
                currentShip = DestroyerClass3.transform.GetChild(3).gameObject;
        } else if (choice == 2) {
            if (lvlShip == 1)
                currentShip = DestroyerClass3.transform.GetChild(4).gameObject;
            else if (lvlShip == 2)
                currentShip = DestroyerClass3.transform.GetChild(5).gameObject;
            else if (lvlShip == 3)
                currentShip = DestroyerClass3.transform.GetChild(6).gameObject;
        } else if (choice == 3) {
            if (lvlShip == 1)
                currentShip = DestroyerClass3.transform.GetChild(7).gameObject;
            else if (lvlShip == 2)
                currentShip = DestroyerClass3.transform.GetChild(8).gameObject;
            else if (lvlShip == 3)
                currentShip = DestroyerClass3.transform.GetChild(9).gameObject;
        }
        if (currentShip)
            currentShip.SetActive(true);
        playerHealthBar.attachedTo = currentShip.transform;
        playerHealthBar.topOffset = 125;
        // Debug.Log(gameObject.transform.GetChild(0).gameObject.GetActive());
    }

    public void LevelUpShipSniperClass3(int choice) {
        GameObject currentShip = null;
        lvlClass3 = choice;
        shipClass2GO.SetActive(false);
        SniperClass3.transform.position = shipClass2GO.transform.position;
        SniperClass3.transform.rotation = shipClass2GO.transform.rotation;
        SniperClass3.GetComponent<Rigidbody2D>().velocity = shipClass2GO.GetComponent<Rigidbody2D>().velocity;
        SniperClass3.SetActive(true);
        if (choice == 1) {
            if (lvlShip == 1)
                currentShip = SniperClass3.transform.GetChild(1).gameObject;
            else if (lvlShip == 2)
                currentShip = SniperClass3.transform.GetChild(2).gameObject;
            else if (lvlShip == 3)
                currentShip = SniperClass3.transform.GetChild(3).gameObject;
        } else if (choice == 2) {
            if (lvlShip == 1)
                currentShip = SniperClass3.transform.GetChild(4).gameObject;
            else if (lvlShip == 2)
                currentShip = SniperClass3.transform.GetChild(5).gameObject;
            else if (lvlShip == 3)
                currentShip = SniperClass3.transform.GetChild(6).gameObject;
        } else if (choice == 3) {
            if (lvlShip == 1)
                currentShip = SniperClass3.transform.GetChild(7).gameObject;
            else if (lvlShip == 2)
                currentShip = SniperClass3.transform.GetChild(8).gameObject;
            else if (lvlShip == 3)
                currentShip = SniperClass3.transform.GetChild(9).gameObject;
        }
        if (currentShip)
            currentShip.SetActive(true);
        playerHealthBar.attachedTo = currentShip.transform;
        playerHealthBar.topOffset = 125;
        // Debug.Log(gameObject.transform.GetChild(0).gameObject.GetActive());
    }

    public void LevelUpShipSpeedyClass3(int choice) {
        GameObject currentShip = null;
        lvlClass3 = choice;
        shipClass2GO.SetActive(false);
        SpeedyClass3.transform.position = shipClass2GO.transform.position;
        SpeedyClass3.transform.rotation = shipClass2GO.transform.rotation;
        SpeedyClass3.GetComponent<Rigidbody2D>().velocity = shipClass2GO.GetComponent<Rigidbody2D>().velocity;
        SpeedyClass3.SetActive(true);
        if (choice == 1) {
            if (lvlShip == 1)
                currentShip = SpeedyClass3.transform.GetChild(1).gameObject;
            else if (lvlShip == 2)
                currentShip = SpeedyClass3.transform.GetChild(2).gameObject;
            else if (lvlShip == 3)
                currentShip = SpeedyClass3.transform.GetChild(3).gameObject;
        } else if (choice == 2) {
            if (lvlShip == 1)
                currentShip = SpeedyClass3.transform.GetChild(4).gameObject;
            else if (lvlShip == 2)
                currentShip = SpeedyClass3.transform.GetChild(5).gameObject;
            else if (lvlShip == 3)
                currentShip = SpeedyClass3.transform.GetChild(6).gameObject;
        } else if (choice == 3) {
            if (lvlShip == 1)
                currentShip = SpeedyClass3.transform.GetChild(7).gameObject;
            else if (lvlShip == 2)
                currentShip = SpeedyClass3.transform.GetChild(8).gameObject;
            else if (lvlShip == 3)
                currentShip = SpeedyClass3.transform.GetChild(9).gameObject;
        }
        if (currentShip)
            currentShip.SetActive(true);
        playerHealthBar.attachedTo = currentShip.transform;
        playerHealthBar.topOffset = 125;
        // Debug.Log(gameObject.transform.GetChild(0).gameObject.GetActive());
    }

    public void LevelUpShipBetweenClass(int lvl) {
        if (shipClass2 == "lvl1") {
            if (lvlShip == 1) {
                intialShip.transform.GetChild(1).gameObject.SetActive(false);
                intialShip.transform.GetChild(2).gameObject.SetActive(true);
            } else if (lvlShip == 2) {
                intialShip.transform.GetChild(2).gameObject.SetActive(false);
                intialShip.transform.GetChild(3).gameObject.SetActive(true);
            }
        } else if (shipClass2 == "destroyer" && lvlClass3 == -1) {
            if (lvlShip == 1) {
                shipClass2GO.transform.GetChild(1).gameObject.SetActive(false);
                shipClass2GO.transform.GetChild(2).gameObject.SetActive(true);
            } else if (lvlShip == 2) {
                 shipClass2GO.transform.GetChild(2).gameObject.SetActive(false);
                shipClass2GO.transform.GetChild(3).gameObject.SetActive(true);
            }
        } else if (shipClass2 == "sniper" && lvlClass3 == -1) {
            if (lvlShip == 1) {
                shipClass2GO.transform.GetChild(1).gameObject.SetActive(false);
                shipClass2GO.transform.GetChild(2).gameObject.SetActive(true);
            } else if (lvlShip == 2) {
                 shipClass2GO.transform.GetChild(2).gameObject.SetActive(false);
                shipClass2GO.transform.GetChild(3).gameObject.SetActive(true);
            }
        } else if (shipClass2 == "speedy" && lvlClass3 == -1) {
            if (lvlShip == 1) {
                shipClass2GO.transform.GetChild(1).gameObject.SetActive(false);
                shipClass2GO.transform.GetChild(2).gameObject.SetActive(true);
            } else if (lvlShip == 2) {
                 shipClass2GO.transform.GetChild(2).gameObject.SetActive(false);
                shipClass2GO.transform.GetChild(3).gameObject.SetActive(true);
            }
        } else if (lvlClass3 != -1) {
            if (shipClass2 == "destroyer") {
                if (lvlClass3 == 1) {
                    if (lvlShip == 1) {
                        DestroyerClass3.transform.GetChild(1).gameObject.SetActive(false);
                        DestroyerClass3.transform.GetChild(2).gameObject.SetActive(true);
                    } else if (lvlShip == 2) {
                        DestroyerClass3.transform.GetChild(2).gameObject.SetActive(false);
                        DestroyerClass3.transform.GetChild(3).gameObject.SetActive(true);
                    }
                } else if (lvlClass3 == 2) {
                   if (lvlShip == 1) {
                        DestroyerClass3.transform.GetChild(4).gameObject.SetActive(false);
                        DestroyerClass3.transform.GetChild(5).gameObject.SetActive(true);
                    } else if (lvlShip == 2) {
                        DestroyerClass3.transform.GetChild(5).gameObject.SetActive(false);
                        DestroyerClass3.transform.GetChild(6).gameObject.SetActive(true);
                    }
                } else if (lvlClass3 == 3) {
                   if (lvlShip == 1) {
                        DestroyerClass3.transform.GetChild(7).gameObject.SetActive(false);
                        DestroyerClass3.transform.GetChild(8).gameObject.SetActive(true);
                    } else if (lvlShip == 2) {
                        DestroyerClass3.transform.GetChild(8).gameObject.SetActive(false);
                        DestroyerClass3.transform.GetChild(9).gameObject.SetActive(true);
                    }
                }
            } else if (shipClass2 == "sniper") {
                if (lvlClass3 == 1) {
                    if (lvlShip == 1) {
                        SniperClass3.transform.GetChild(1).gameObject.SetActive(false);
                        SniperClass3.transform.GetChild(2).gameObject.SetActive(true);
                    } else if (lvlShip == 2) {
                        SniperClass3.transform.GetChild(2).gameObject.SetActive(false);
                        SniperClass3.transform.GetChild(3).gameObject.SetActive(true);
                    }
                } else if (lvlClass3 == 2) {
                    if (lvlShip == 1) {
                        SniperClass3.transform.GetChild(4).gameObject.SetActive(false);
                        SniperClass3.transform.GetChild(5).gameObject.SetActive(true);
                    } else if (lvlShip == 2) {
                        SniperClass3.transform.GetChild(5).gameObject.SetActive(false);
                        SniperClass3.transform.GetChild(6).gameObject.SetActive(true);
                    }
                } else if (lvlClass3 == 3) {
                    if (lvlShip == 1) {
                        SniperClass3.transform.GetChild(7).gameObject.SetActive(false);
                        SniperClass3.transform.GetChild(8).gameObject.SetActive(true);
                    } else if (lvlShip == 2) {
                        SniperClass3.transform.GetChild(8).gameObject.SetActive(false);
                        SniperClass3.transform.GetChild(9).gameObject.SetActive(true);
                    }
                }
            } else if (shipClass2 == "speedy") {
                if (lvlClass3 == 1) {
                    if (lvlShip == 1) {
                        SpeedyClass3.transform.GetChild(1).gameObject.SetActive(false);
                        SpeedyClass3.transform.GetChild(2).gameObject.SetActive(true);
                    } else if (lvlShip == 2) {
                        SpeedyClass3.transform.GetChild(2).gameObject.SetActive(false);
                        SpeedyClass3.transform.GetChild(3).gameObject.SetActive(true);
                    }
                } else if (lvlClass3 == 2) {
                    if (lvlShip == 1) {
                        SpeedyClass3.transform.GetChild(4).gameObject.SetActive(false);
                        SpeedyClass3.transform.GetChild(5).gameObject.SetActive(true);
                    } else if (lvlShip == 2) {
                        SpeedyClass3.transform.GetChild(5).gameObject.SetActive(false);
                        SpeedyClass3.transform.GetChild(6).gameObject.SetActive(true);
                    }
                } else if (lvlClass3 == 3) {
                    if (lvlShip == 1) {
                        SpeedyClass3.transform.GetChild(7).gameObject.SetActive(false);
                        SpeedyClass3.transform.GetChild(8).gameObject.SetActive(true);
                    } else if (lvlShip == 2) {
                        SpeedyClass3.transform.GetChild(8).gameObject.SetActive(false);
                        SpeedyClass3.transform.GetChild(9).gameObject.SetActive(true);
                    }
                }
            }
        }
        lvlShip += 1;
    }
}
