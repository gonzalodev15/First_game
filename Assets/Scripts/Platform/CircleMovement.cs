using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    float timeCounter = 0;

    public float speed;
    float width;
    float height;
    public GameObject Player;
    public GameObject PlayerMaintainer;

    // Start is called before the first frame update
    void Start()
    {
        width = 1.5f;
        height = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;
        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 myScale = transform.localScale;
        PlayerMaintainer.transform.localScale = new Vector3(1f / myScale.x, 1f / myScale.y,
                1f / myScale.z);

        PlayerMaintainer.transform.SetParent(transform, false);

        collision.transform.SetParent(PlayerMaintainer.transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.SetParent(null);
    }
}
