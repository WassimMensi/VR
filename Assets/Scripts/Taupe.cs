using UnityEngine;
using System.Collections;

public class Taupe : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] float interval = 3.0f;
    [SerializeField] float life = 5.0f;
    [SerializeField] float spawnChance = 25.0f;
    [SerializeField] float animationDuration = 0.5f;

    [Header("Dependencies")]
    [SerializeField] ScoreManager scoreManager;

    float timeLeftLife;
    float timeLeftSpawn;
    float timeLeftSpawnDuration;
    bool spawned=false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeLeftLife = life;
        timeLeftSpawn = interval;
        despawn();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        if (spawned) timeLeftLife -= delta;
        else timeLeftSpawn -= delta;

        if(timeLeftSpawn < 0)
        {
            bool spawning = Random.Range(0, 100) < spawnChance;
            if(spawning) spawn();
            timeLeftSpawn = interval;
        }

        if (timeLeftLife < 0) {
            timeLeftLife = life;
            despawn();
        }
    }

    void spawn()
    {
        spawned = true;
        StartCoroutine(move(new Vector3(0, 1, 0)));
    }

    void despawn()
    {
        spawned = false;
        StartCoroutine(move(new Vector3(0, -1, 0)));
    }

    IEnumerator move(Vector3 translateVector)
    {
        GameObject taupeCorps = GameObject.Find(name + "/Diglett Body");
        GameObject taupeNez = GameObject.Find(name + "/Diglett Nose");
        Vector3 originalCorpsPos = taupeCorps.transform.position;
        Vector3 targetCorpsPos = taupeCorps.transform.position + translateVector;
        Vector3 originalNezPos = taupeNez.transform.position;
        Vector3 targetNezPos = taupeNez.transform.position + translateVector;
        while (timeLeftSpawnDuration < animationDuration)
        {
            timeLeftSpawnDuration += Time.deltaTime;
            float t = timeLeftSpawnDuration / animationDuration;
            yield return new WaitForEndOfFrame();
            taupeCorps.transform.position = Vector3.Lerp(originalCorpsPos, targetCorpsPos, t);
            taupeNez.transform.position = Vector3.Lerp(originalNezPos, targetNezPos, t);
        }
        timeLeftSpawnDuration = 0;
        yield return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("HammerMole")) return;
        if(!spawned) return;
        timeLeftSpawn = interval;
        timeLeftLife = life;
        despawn();
        scoreManager.addScore(1);
    }
}
