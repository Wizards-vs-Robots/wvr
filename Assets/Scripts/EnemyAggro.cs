using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using Robot;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAggro : MonoBehaviour
{
    public void Start()
    {
        determiner.Add(AggroType.Proximity, () =>
            targetList.OrderBy(t => (t.transform.position - this.transform.position).magnitude).FirstOrDefault());
        
        determiner.Add(AggroType.Random, () =>
            targetList.OrderBy(o => Random.Range(0.0f, 1.0f)).FirstOrDefault());
        calculatedOnce.Add(AggroType.Random);
    }

    public AggroType aggroType = AggroType.Proximity;
    
    private readonly List<GameObject> targetList = new List<GameObject>();
    private Dictionary<AggroType, Func<GameObject>> determiner = new Dictionary<AggroType, Func<GameObject>>();
    private HashSet<AggroType> calculatedOnce = new HashSet<AggroType>();
    private GameObject target;

    public void AddPossibleTarget(params GameObject[] list)
    {
        foreach (var o in list)
        {
            targetList.Add(o);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // calculate only once
        if (calculatedOnce.Contains(aggroType) && target == null)
            target = determiner[aggroType].Invoke();

        // calculate continously
        if (!calculatedOnce.Contains(aggroType))
            target = determiner[aggroType].Invoke();
        
        if(!target) return;

        // color code aggro
        GetComponentInChildren<SpriteRenderer>().color = target.GetComponent<SpriteRenderer>().color; // indicate target by color
        
        GetComponent<Attacker>().target = target.GetComponent<Damagable>();
        GetComponent<AIDestinationSetter>().target = target.transform;
    }
    
    public enum AggroType
    {
        Proximity,
        Random
    }
}
