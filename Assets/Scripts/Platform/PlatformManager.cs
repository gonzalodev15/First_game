using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platform1;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 1)
        {
            platform1.SetActive(true);
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }
}
