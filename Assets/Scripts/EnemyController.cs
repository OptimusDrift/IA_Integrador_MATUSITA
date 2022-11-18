using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    private string[] states = { "Patrol", "Alterado", "Chasing", "Stopped", "13/14" };
    public string actualState = "Patrol";
    [SerializeField]
    private float timeStopped = 3f;
    [SerializeField]
    private float timeAlterado = 3f;
    public bool isActive = false;

    public void Move()
    {
        var x = waypoints[Random.Range(0, waypoints.Length)].position;
        GetComponent<NavMeshAgent>().destination = x;
        GetComponent<Transform>().LookAt(Vector3.Lerp(GetComponent<Transform>().position, x, 0.5f));
    }

    private void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(8.4f);
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (actualState == "Chasing")
        {
            GetComponent<NavMeshAgent>().destination = GameObject
                .FindGameObjectWithTag("player")
                .transform.position;
        }
        //girar objeto durante 3 segundos
        if (actualState == "Alterado")
        {
            GetComponent<NavMeshAgent>().destination = GetComponent<Transform>().position;
            GetComponent<Transform>().Rotate(Vector3.up * 200 * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "waypoint" && actualState == "Patrol")
        {
            Move();
        }
        if (other.gameObject.tag == "waypoint" && actualState == "13/14")
        {
            Chasing();
        }
    }

    public void Chasing()
    {
        actualState = "Chasing";
        isActive = true;
        StartCoroutine(Wait(2));
    }

    public void Stopped(){
        actualState = "Stopped";
        GetComponent<NavMeshAgent>().destination = GetComponent<Transform>().position;
        StartCoroutine(Wait(timeStopped));
    }

    public void Patrol(){
        actualState = "Patrol";
        isActive = false;
        Move();
    }

    public void Alterado(){
        actualState = "Alterado";
        isActive = true;
        StartCoroutine(Wait(timeAlterado));
    }

    public void la1314(GameObject player){
        actualState = "13/14";
        isActive = true;
        Flanqueo(player);
    }

    public void Flanqueo(GameObject player){
        var distancias = new float[waypoints.Length];
        for (int i = 0; i < waypoints.Length; i++)
        {
            distancias[i] = Vector3.Distance(waypoints[i].position, player.transform.position);
        }
        var min = Mathf.Min(distancias);
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (distancias[i] == min)
            {
                GetComponent<NavMeshAgent>().destination = waypoints[i].position;
                GetComponent<Transform>().LookAt(Vector3.Lerp(GetComponent<Transform>().position, waypoints[i].position, 0.5f));
                break;
            }
        }
    }

    public IEnumerator Wait(float time = 1f)
    {
        yield return new WaitForSeconds(time);
        switch (actualState)
        {
            case "Stopped":
                Alterado();
                break;
            case "Chasing":
                Alterado();
                break;
            case "Alterado":
                Patrol();
                break;
            default:
                break;
        }
    }
}
