using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostColliders : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemyController;
    private bool porcentaje = false;
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            StartCoroutine(enemyController.Wait());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            if(other.GetComponent<PlayerMoviment>().actualState != "Hidden")
            {
                porcentaje = Random.Range(0, 100) <= 50;
            }
        }
    }  

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            if(other.GetComponent<PlayerMoviment>().actualState != "Hidden")
            {
                if (!enemyController.isActive && porcentaje)
                {
                    enemyController.la1314(other.gameObject);
                    porcentaje = false;
                }
                else if (!enemyController.isActive)
                {
                    enemyController.Chasing();
                }
            }
        }
        if (other.gameObject.tag == "saltDrop")
        {
            enemyController.Stopped();
            Destroy(other.gameObject);
        }
    }
}
