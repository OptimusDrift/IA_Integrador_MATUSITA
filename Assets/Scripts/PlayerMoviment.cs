using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoviment : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    public Canvas canvas;
    public Text text;
    public string actualState;
    [SerializeField]
    private bool hidde = false;
    private string[] states = { "Idle", "Moving", "Hidden", "Death", "UseItem" };
    public List<string> keys;
    public int saltCount = 0;
    [SerializeField]
    public Text textSalt;
    [SerializeField]
    private GameObject saltToDrop;

    void Start()
    {
        keys = new List<string>();
        actualState = states[0];
        GetComponent<Animator>().SetBool("Start", true);
        StartCoroutine(EndStart());
    }

    IEnumerator EndStart(){
        yield return new WaitForSeconds(8.4f);
        GetComponent<Animator>().SetBool("Start", false);
        GetComponent<Animator>().enabled = false;
    }

    public void ChangeState(string newState)
    {
        actualState = newState;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F))
        {
            DropSalt();
        }
    }

    public void AddObject(string objectName)
    {
        if (objectName != "item")
        {
            keys.Add(objectName);
        }
        else
        {
            saltCount++;
            textSalt.text = "x" + saltCount;
        }
    }

    public void DropSalt()
    {
        if (saltCount > 0)
        {
            Instantiate(saltToDrop, transform.position - new Vector3(0f, .83f, 0f), Quaternion.identity);
            saltCount--;
            textSalt.text = "x" + saltCount;
        }
    }
}
