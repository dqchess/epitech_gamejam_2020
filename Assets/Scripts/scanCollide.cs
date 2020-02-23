using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class scanCollide : MonoBehaviour
{
    // Start is called before the first frame update
    Seeker seeker;
    AIDestinationSetter target;
    public Collider2D colliding;
    public GameObject parentShip;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        target = GetComponent<AIDestinationSetter>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        AstarPath.active.UpdateGraphs(colliding.bounds);
        if (!target.target.gameObject.activeSelf) {
            GetPlayer();
        }
    }

    public void GetPlayer()
    {
        for (int i = 0; i < parentShip.transform.childCount; i++) {
            if (parentShip.transform.GetChild(i).gameObject.activeSelf == true) {
                if (target)
                    target.target = parentShip.transform.GetChild(i);
            }
        }
    }

    // Update is called once per frame
}
