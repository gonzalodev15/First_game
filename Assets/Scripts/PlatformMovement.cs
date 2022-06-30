using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public GameObject Player;
    public GameObject PlayerMaintainer;
    // Start is called before the first frame update

    public float speed = 1.0f;
    public float journeyLenght = 1.0f;
    private float startTime;
    public bool loop = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!loop)
        {
            float distCovered = (Time.time - startTime) * speed;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, distCovered/journeyLenght);
        }

        if (loop)
        {
            float distCovered = Mathf.PingPong(Time.time - startTime, journeyLenght / speed);
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, distCovered / journeyLenght);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject == Player)
        {
            //other.gameObject.transform.SetParent(PlayerMaintainer.transform, true);
            Player.transform.SetParent(PlayerMaintainer.transform, true);

            Player.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
