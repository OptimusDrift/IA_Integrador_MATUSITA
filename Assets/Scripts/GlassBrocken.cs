using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBrocken : MonoBehaviour
{
    [SerializeField]
    private GameObject ghost;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "player")
        {
            ghost.GetComponent<EnemyController>().Chasing();
        }
    }
}
