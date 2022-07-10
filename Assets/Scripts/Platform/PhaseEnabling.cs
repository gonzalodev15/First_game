using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseEnabling : MonoBehaviour
{
    public GameObject Platform1;
    public GameObject Platform2;
    public GameObject Platform3;
    public GameObject Platform4;
    public GameObject Platform5;
    public GameObject Platform6;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Platform1.SetActive(true);
            Platform2.SetActive(true);
            Platform3.SetActive(true);
            Platform4.SetActive(true);
            Platform5.SetActive(true);
            Platform6.SetActive(true);
            Enemy1.SetActive(true);
            Enemy2.SetActive(true);
            Enemy3.SetActive(true);
        }
    }
}
