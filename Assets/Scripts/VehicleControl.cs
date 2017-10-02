using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleControl : MonoBehaviour {

    /*
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    */
    private Rigidbody rb;
    private Vector2 touchDeltaPosition;
    [SerializeField]
    private Vector3 newVelocity;

    public float lateralMoveSpeed = 20.0f;
    public float axialMoveSpeed = 20.0f;
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        axialMoveSpeed = 20.0f;
    }

    public void Update()
    {
        newVelocity = Vector3.zero;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchDeltaPosition = Input.GetTouch(0).deltaPosition;
             newVelocity = new Vector3(touchDeltaPosition.x, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            newVelocity = new Vector3(-lateralMoveSpeed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            newVelocity = new Vector3(lateralMoveSpeed, 0.0f, 0.0f);
        }
        newVelocity += transform.forward * axialMoveSpeed;
        rb.velocity = newVelocity;
            
    }
    public void FixedUpdate()
    {
        /*
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
        */
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
