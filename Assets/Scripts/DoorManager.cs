using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField]
    private string nameDoor;
    

    void Start()
    {
        if (nameDoor == "KeyExit")
        {
            GetComponent<Animator>().SetBool("Start", true);
            Debug.Log("Start");
            StartCoroutine(Anim());
        }
    }

    IEnumerator Anim()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<Animator>().SetBool("Start", false);
    }

    public bool TryOpen(string keyName)
    {
        if (keyName == nameDoor)
        {
            OpenDoor();
            return true;
        }
        else
        {
            GetComponent<Animator>().SetBool("TryOpen", true);
            StartCoroutine(ResetTryOpen());
        }
        return false;
    }

    IEnumerator ResetTryOpen()
    {
        yield return new WaitForSeconds(.75f);
        GetComponent<Animator>().SetBool("TryOpen", false);
    }

    public void OpenDoor()
    {
        GetComponent<Animator>().SetBool("Key", true);
    }

    public void CloseDoor()
    {
        GetComponent<Animator>().SetBool("Key", false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            other.GetComponent<PlayerMoviment>().canvas.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (var item in other.GetComponent<PlayerMoviment>().keys)
                {
                    if (TryOpen(item))
                    {
                        other.GetComponent<PlayerMoviment>().canvas.gameObject.SetActive(false);
                        break;
                    }
                }
            }
        }
    }
}
