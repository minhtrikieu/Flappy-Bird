using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUpdate : MonoBehaviour
{
    public GameObject text;
    
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<BirdMove>().checknSkillAcquired() == true)
        {
            // var textTemp = Instantiate(text, text.position);
            //gameObject.GetComponent<Canvas>().GetComponentInChildren
            text.SetActive(true);
            StartCoroutine(LateCall());
        }
       
    }
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(5f);
        text.SetActive(false);
    }
}
