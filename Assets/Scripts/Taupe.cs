using UnityEngine;

public class Taupe : MonoBehaviour
{
    [SerializeField] float interval = 3.0f;
    [SerializeField] float life = 5.0f;
    [SerializeField] float spawnChance = 25.0f;

    float timeLeftLife;
    float timeLeftSpawn;
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
        GameObject taupeCorps = GameObject.Find(name + "/Diglett Body");
        GameObject taupeNez = GameObject.Find(name + "/Diglett Nose");
        taupeCorps.transform.position += new Vector3(0, 1, 0);
        taupeNez.transform.position += new Vector3(0, 1, 0);
    }

    void despawn()
    {
        spawned = false;
        GameObject taupeCorps = GameObject.Find(name + "/Diglett Body");
        GameObject taupeNez = GameObject.Find(name + "/Diglett Nose");
        taupeCorps.transform.position += new Vector3(0, -1, 0);
        taupeNez.transform.position += new Vector3(0, -1, 0);
    }
}
