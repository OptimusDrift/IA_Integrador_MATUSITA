using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string nameObject;
    private bool isHidden = false;
    private bool inAnim = false;
    private bool inAnim2 = false;

    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "player")
        {
            if (!isHidden)
            {
                other.GetComponent<PlayerMoviment>().canvas.gameObject.SetActive(true);
                other.GetComponent<PlayerMoviment>().text.text = "Press E to hidden";
            }else
            {
                other.GetComponent<PlayerMoviment>().canvas.gameObject.SetActive(true);
                other.GetComponent<PlayerMoviment>().text.text = "Press E to show";
            }
            
            if (Input.GetKeyDown(KeyCode.E) && !isHidden && !inAnim)
            {
                other.GetComponent<PlayerMoviment>().canvas.gameObject.SetActive(false);
                other.GetComponent<PlayerMoviment>().GetComponent<Animator>().enabled = true;
                other.GetComponent<PlayerMoviment>().GetComponent<Animator>().SetBool("hidden", true);
                isHidden = true;
                inAnim = true;
                StartCoroutine(Anim());
            }else if (Input.GetKeyDown(KeyCode.E) && isHidden && !inAnim && !inAnim2)
            {
                other.GetComponent<PlayerMoviment>().canvas.gameObject.SetActive(false);
                other.GetComponent<PlayerMoviment>().GetComponent<Animator>().SetBool("hidden", false);
                StartCoroutine(DesactiveAnimator(other));
                inAnim2 = true;
            }
        }
    }

    IEnumerator DesactiveAnimator(Collider other){
        yield return new WaitForSeconds(2.8f);
        other.GetComponent<PlayerMoviment>().GetComponent<Animator>().enabled = false;
        inAnim = false;
        inAnim2 = false;
        isHidden = false;
    }

    IEnumerator Anim(){
        yield return new WaitForSeconds(2.8f);
        inAnim = false;
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "player")
        {
            other.GetComponent<PlayerMoviment>().canvas.gameObject.SetActive(false);
        }
    }
}
