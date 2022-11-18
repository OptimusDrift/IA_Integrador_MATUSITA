using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [SerializeField]
    private string nameObject;
    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "player")
        {
            other.GetComponent<PlayerMoviment>().canvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<PlayerMoviment>().canvas.gameObject.SetActive(false);
                other.GetComponent<PlayerMoviment>().text.text = "Press E to pick up";
                other.GetComponent<PlayerMoviment>().AddObject(nameObject);

                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "player")
        {
            other.GetComponent<PlayerMoviment>().canvas.gameObject.SetActive(false);
        }
    }
}
