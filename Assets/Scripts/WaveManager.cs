using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using Robot;
using UnityEngine.UIElements;

public class WaveManager : MonoBehaviour
{
    private static readonly float TIME_PRECISION = 10F;
    private static readonly float BASE_COOLDOWN  = 1F; //5
    private static readonly float BASE_DURATION  = 5F; //40
    private static readonly float BASE_STRENGTH  = 100F;
    public static float MIN_SPAWN_RADIUS = 4F;
    public static float MAX_SPAWN_RADIUS = 7F;
    
    public GameObject[] prefabs;
    public GameObject[] drop_prefabs;
    public List<Attacker> attackers;
    public GameObject player;
    //-----------------------------------------------
    public int wave;
    public float cooldown;
    public float duration;
    public float strength;
    private List<GameObject> minions;

    void Start()
    {
        //Getting "Attacker" component of game objects beforehand
        //to elimite "runtime" overhead during the game and sort
        //them in ascending order regarding their strength.
        attackers = new List<Attacker>();
        foreach (GameObject prefab in prefabs) {
            attackers.Add(prefab.GetComponent<Attacker>());
        }
        attackers.Sort((x, y) => x.GetStrength().CompareTo(y.GetStrength()));

        minions = new List<GameObject>();
        cooldown = BASE_COOLDOWN;
        duration = BASE_DURATION;
        strength = BASE_STRENGTH;
        StartCoroutine(Manage());
    }

    IEnumerator Manage()
    {
        while(true) {
            //If there are still some minions outside, the coroutine waits
            //before proceeding to the next wave until they are all dead.
            if (minions.Count > 0)
            {
                Debug.Log("There are still minions.");
                yield return new WaitUntil(() => (minions.Count == 0));
            }
            
            //At this point, all minions are reported dead.
            //The next wave is strenghened, the cooldown is iniated and
            //the next minions are spawned.
            Debug.Log("Minions gone.");
            
            wave++;
            Strengthen();

            Debug.Log("Strengthened waves.");
            yield return new WaitForSeconds(cooldown);

            Debug.Log("Cooldown expired.");
            List<Tuple<float, Attacker>> pattern = GenerateSpawnPattern();
            float elapsed = 0;
            foreach (Tuple<float, Attacker> pair in pattern) {
                float duration = pair.Item1 - elapsed;
                elapsed += duration;

                Debug.Log("Elapsed: " + elapsed + "; P.I.T:" + pair.Item1 + " (" + duration + "s)");

                yield return new WaitForSeconds(duration);
                Debug.Log("Waited...");
                Spawn(pair.Item2, player.transform.position);
                Debug.Log("Spawned...");
            }
        }
    }

    void Strengthen()
    {
        //Different parameters grow using different growth functions.
        int x = wave - 1;
        cooldown = (float) (BASE_COOLDOWN * Math.Exp(-0.005D * x));
        duration = (float) (BASE_DURATION * Math.Exp(-0.02D * x));
        strength = (float) (BASE_STRENGTH * Math.Exp(0.04D * x));
    }

    public void ReportDeath(GameObject entity)
    {
        if (minions.Contains(entity)) {
            GameObject scoreField = GameObject.FindGameObjectsWithTag("Score")[0];
            ScoreModel view = scoreField.GetComponent<ScoreModel>();
            view.Increment(20);
            generateDrop(entity.transform.position);
            Destroy(entity);
            minions.Remove(entity);
        }
    }

    private void generateDrop(Vector3 position)
    { 
        if (UnityEngine.Random.Range(0, 4) == 1) // 25% drop chance (maybe 20%, too lazy to look up)
        {
            Instantiate(drop_prefabs[UnityEngine.Random.Range(0,drop_prefabs.Length)], position, Quaternion.identity); //random available drop
        }
    }

    void Spawn(Attacker attacker, Vector3 center)
    {
        //Generate normalized vector from random angle and stretch it to match specified range.
        float angle = UnityEngine.Random.Range(0F, (float)(Math.PI * 2));
        float range = UnityEngine.Random.Range(MIN_SPAWN_RADIUS, MAX_SPAWN_RADIUS);

        Vector3 surrounding = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);
        surrounding *= range;
        surrounding += center;

        //Instantiate prefab, register attacker and let it target the player.
        GameObject parent = attacker.transform.gameObject;
        parent.GetComponent<AIDestinationSetter>().target = player.transform;
        attacker.target = player.GetComponent<Damagable>();

        GameObject spawned = Instantiate(parent, surrounding, Quaternion.identity);
        minions.Add(spawned);
    }

    //Each attacker has a minimum and a maximum wave assigned to him.
    //This function gives out a list of robots that can exist during the #wave.
    List<Attacker> GetValidSpawningOptions()
    {
        List<Attacker> options = new List<Attacker>();
        foreach (Attacker attacker in attackers) {
            if ((wave >= attacker.minWave || attacker.minWave < 0) &&
                (wave <= attacker.maxWave || attacker.maxWave < 0)) {
                options.Add(attacker);
                Debug.Log(attacker.strengthRating);
            }
        }

        return options;
    }

    //This function generates descrete points in time in an intervall
    //I = [0; #duration] using sub-second timesteps. They are sorted in
    //ascending order.
    List<Tuple<float, Attacker>> GenerateSpawnPattern()
    {
        List<Attacker> options = GetValidSpawningOptions();
        int pivot = options.Count - 1;
        int upper = (int) (duration * TIME_PRECISION);
        float quota = strength;

        List<Tuple<float, Attacker>> output = new List<Tuple<float, Attacker>>();
        while (quota > 0) {
            Attacker selected = options[pivot];
            float strength = selected.GetStrength();

            if (quota >= strength || pivot == 0) {
                float time = UnityEngine.Random.Range(1, upper) / TIME_PRECISION;
                quota -= strength;
                output.Add(Tuple.Create(time, selected));
            } else {
                pivot--;
            }
        }

        output.Sort((x, y) => x.Item1.CompareTo(y.Item1));
        return output;
    }
}
