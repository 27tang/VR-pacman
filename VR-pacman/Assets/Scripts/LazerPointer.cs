using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerPointer : MonoBehaviour {

    public float movementSpeed;

    public GameObject player;

    public Transform cameraRigTransform;
    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask;
    private bool shouldTeleport;



    private SteamVR_TrackedObject trackedObj;
    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;

    private Vector3 hitPoint;


    void Start()
    {
        // 1
        laser = Instantiate(laserPrefab);
        // 2
        laserTransform = laser.transform;
    }

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    private void ShowLaser(RaycastHit hit)
    {
        // 1
        laser.SetActive(true);
        // 2
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        // 3
        laserTransform.LookAt(hitPoint);
        // 4
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance);
    }



    // Update is called once per frame
    void LateUpdate () {
        // 1
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            RaycastHit hit;

            // 2
            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                Vector3 movement = hitPoint - headTransform.position ;
                movement = movement.normalized;
                movement.y = 0;

                player.GetComponent<Rigidbody>().AddForce(movement * movementSpeed);
                Debug.Log("Player Objeect Name: " + player.name);
                Debug.Log("VECTOR DIFFERENCE IS: " + movement);
            }
        }
        else // 3
        {
            laser.SetActive(false);
        }
    }


}
