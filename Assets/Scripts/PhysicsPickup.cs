using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{

    [SerializeField]
    private LayerMask PickupMask;
    [SerializeField]
    private Camera playerCam;
    [SerializeField]
    private Transform pickUpTarget;

    [SerializeField]
    private float pickupRange;
    [SerializeField]
    private float forceThrow;
    private Rigidbody currentObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentObj)
            {
                currentObj.useGravity = true;
                currentObj = null;
                return;
            }

            Ray CameraRay = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if(Physics.Raycast(CameraRay, out RaycastHit HitInfo, pickupRange, PickupMask))
            {
                currentObj = HitInfo.rigidbody;
                currentObj.useGravity = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentObj)
            {
                currentObj.useGravity = true;

                currentObj.AddForce(pickUpTarget.forward * forceThrow * 10f);
                currentObj = null;
            }
        }
    }

    private void FixedUpdate()
    {
        if (currentObj)
        {
            Vector3 DirectionToPoint = pickUpTarget.position - currentObj.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            currentObj.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }
}
