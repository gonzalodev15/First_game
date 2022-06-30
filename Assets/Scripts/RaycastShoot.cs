using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public int gunDamage = 1;                                            // Set the number of hitpoints that this gun will take away from shot objects with a health script
    public float fireRate = 0.25f;                                        // Number in seconds which controls how often the player can fire
    public float weaponRange = 50f;                                        // Distance in Unity units over which the player can fire
    public float hitForce = 100f;                                        // Amount of force which will be added to objects with a rigidbody shot by the player
    public Transform gunEnd;                                            // Holds a reference to the gun end object, marking the muzzle location of the gun

    private Camera fpsCam;                                                // Holds a reference to the first person camera
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);    // WaitForSeconds object used by our ShotEffect coroutine, determines time laser line will remain visible
    private LineRenderer laserLine;                                        // Reference to the LineRenderer component which will display our laserline
    private float nextFire;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.SetPosition(0, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown ("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = transform.position;
            if (Physics.Raycast(rayOrigin, transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
            } else
            {

            }
        }
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }
}
