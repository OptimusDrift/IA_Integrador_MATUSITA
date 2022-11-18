using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostColliderKiller : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemyController;
        void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            other.GetComponent<PlayerMoviment>().ChangeState("Death");
            Destroy(other.gameObject);
            SceneManager.LoadScene("Menu");
        }
        if (other.gameObject.tag == "waypoint" && enemyController.actualState == "Patrol")
        {
            enemyController.Move();
        }
    }
}
