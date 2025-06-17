using UnityEngine;
using System.Collections.Generic;

public class ChasseTaupe : MonoBehaviour
{
    [SerializeField] public List<GameObject> Taupes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < Taupes.Count; i++)
        {
            GameObject taupe = Taupes[i];
            if (taupe != null)
            {
                string name = taupe.name;
                GameObject taupeCorps = GameObject.Find(name+"/Diglett Body");
                GameObject taupeNez = GameObject.Find(name + "/Diglett Nose");
                taupeCorps.transform.position += new Vector3(0,-1,0);
                taupeNez.transform.position += new Vector3(0,-1,0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
