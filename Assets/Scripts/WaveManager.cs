using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using Robot;

public class WaveManager : MonoBehaviour
{
    private static readonly float BASE_COOLDOWN          = 1F; //5
    private static readonly float BASE_SCATTER_DURATION  = 5F; //40
    private static readonly float BASE_SCATTER_AMOUNT    = 10F;
    
    public GameObject attackerPrefab;
    public GameObject player;
    //-----------------------------------------------
    public int wave = 1;
    public float cooldown;
    public float scatterDuration;
    public float scatterAmount;
    private List<Attacker> minions;

    void Start()
    {
        minions = new List<Attacker>();
        cooldown = BASE_COOLDOWN;
        scatterDuration = BASE_SCATTER_DURATION;
        scatterAmount = BASE_SCATTER_AMOUNT;
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
            float[] pattern = GenerateSpawnPattern((int) scatterAmount, (int) scatterDuration);
            float elapsed = 0;
            foreach (float pointInTime in pattern) {
                float duration = pointInTime - elapsed;
                elapsed += duration;

                Debug.Log("Elapsed: " + elapsed + "; P.I.T:" + pointInTime + " (" + duration + "s)");

                yield return new WaitForSeconds(duration);
                Debug.Log("Waited...");
                Spawn(player.transform.position, 3F);
                Debug.Log("Spawned...");
            }
        }
    }

    void Strengthen()
    {
        //Different parameters grow using different growth functions.
        scatterAmount   = (float) (BASE_SCATTER_AMOUNT * Math.Exp(0.04D * wave));
        scatterDuration = (float) (BASE_SCATTER_DURATION * Math.Exp(-0.02D * wave));
        cooldown        = (float) (BASE_COOLDOWN * Math.Exp(-0.005D * wave));
    }

    public void ReportDeath(GameObject entity)
    {
        Attacker attacker = entity.GetComponent<Attacker>();
        if (attacker != null) {
            if (minions.Contains(attacker)) {

                //TODO REMOVE
                Debug.Log("*pew* Ded.");
                GameObject scoreField = GameObject.FindGameObjectsWithTag("Score")[0];
                ScoreModel view = scoreField.GetComponent<ScoreModel>();
                view.Increment(20);
                //TODO REMOVE
                
                Destroy(entity);
                minions.Remove(attacker);
            }
        }
    }

    void Spawn(Vector3 center, float range)
    {
        //Generate normalized vector from random angle
        //and stretch it to match specified range.
        float angle = UnityEngine.Random.Range(0F, (float)(Math.PI * 2));
        Vector3 surrounding = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);
        surrounding *= range;
        surrounding += center;

        //Instantiate prefab at this position.
        GameObject entity = Instantiate(attackerPrefab, surrounding, Quaternion.identity);
        Attacker attacker = entity.GetComponent<Attacker>();
        attacker.target = player.GetComponent<Damagable>();
        entity.GetComponent<AIDestinationSetter>().target = player.transform;
        minions.Add(attacker);
    }

    //This function generates #amount descrete points in time in a
    //time intervall between 0 and #duration using 100ms timesteps
    //in ascending order.
    float[] GenerateSpawnPattern(int amount, int duration)
    {
        float[] output = new float[amount];
        int upperBound = duration * 10;

        System.Random generator = new System.Random();
        for (int i = 0; i < amount; i++) {
            output[i] = generator.Next(1, upperBound + 1) / 10F;
        }

        Array.Sort(output);
        Debug.Log("Generation: " + amount + " points in time");
        for (int i = 0; i < amount; i++) {
            Debug.Log(output[i]);
        }
        return output;
    }
}
