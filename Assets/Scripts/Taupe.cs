using UnityEngine;

public class Taupe : MonoBehaviour
{
    [SerializeField] float interval = 3.0f;
    [SerializeField] float lifeTime = 5.0f;
    [SerializeField] float spawnChance = 25.0f;

    float timeLife = 0.0f;
    float timeInterval = 0.0f;
    bool spawned=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject taupeCorps = GameObject.Find(name + "/Diglett Body");
        GameObject taupeNez = GameObject.Find(name + "/Diglett Nose");
        taupeCorps.transform.position += new Vector3(0, -1, 0);
        taupeNez.transform.position += new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawned) timeLife -= Time.deltaTime;
        else {
            bool spawning = Random.Range(0, 100) < spawnChance;
            spawn();
        }
        if (timeLife <= 0) despawn();
    }

    void spawn()
    {
        timeLife = lifeTime;
        spawned = true;
        GameObject taupeCorps = GameObject.Find(name + "/Diglett Body");
        GameObject taupeNez = GameObject.Find(name + "/Diglett Nose");
        taupeCorps.transform.position += new Vector3(0, 1, 0);
        taupeNez.transform.position += new Vector3(0, 1, 0);
    }

    void despawn()
    {
        timeLife = 0.0f;
        timeInterval = interval;
        spawned = false;
        GameObject taupeCorps = GameObject.Find(name + "/Diglett Body");
        GameObject taupeNez = GameObject.Find(name + "/Diglett Nose");
        taupeCorps.transform.position += new Vector3(0, -1, 0);
        taupeNez.transform.position += new Vector3(0, -1, 0);
    }
}
