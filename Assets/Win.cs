using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public bool win = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            win = true;
        }
    }
}
