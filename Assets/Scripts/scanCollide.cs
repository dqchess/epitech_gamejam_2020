using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class scanCollide : MonoBehaviour
{
    // Start is called before the first frame update
    Seeker seeker;
    AIDestinationSetter target;
    DamageableObj salut;
    public Collider2D colliding;
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
    }

    // Update is called once per frame
}
