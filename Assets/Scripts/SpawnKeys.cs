using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKeys : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> key;
    [SerializeField]
    private List<GameObject> keySpawn0;
    [SerializeField]
    private List<GameObject> keySpawn1;
    [SerializeField]
    private List<GameObject> keySpawn2;
    [SerializeField]
    private List<GameObject> keySpawn3;

    void Start()
    {
        key[0].transform.position = keySpawn0[Random.Range(0, keySpawn0.Count-1)].transform.position;
        key[1].transform.position = keySpawn1[Random.Range(0, keySpawn1.Count-1)].transform.position;
        key[2].transform.position = keySpawn2[Random.Range(0, keySpawn2.Count-1)].transform.position;
        key[3].transform.position = keySpawn3[Random.Range(0, keySpawn3.Count-1)].transform.position;
    }
}
