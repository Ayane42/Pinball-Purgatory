using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipperL : MonoBehaviour
{
    public HingeJoint2D hingeJoint;
    public JointMotor2D jointMotor;

    private bool isKeyPress = false;
    public float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
        jointMotor = hingeJoint.motor;
        hingeJoint.useMotor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isKeyPress = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            // Enable the Hinge Joint 2D component to make it active.
            isKeyPress = false;
        }
        hingeJoint.motor = jointMotor;
    }

    void FixedUpdate()
    {
        if (isKeyPress)
        {
            // Enable the Hinge Joint 2D component to make it active.
            jointMotor.motorSpeed = speed;

        }
        else
        {
            // Enable the Hinge Joint 2D component to make it active.
            jointMotor.motorSpeed = -speed;
        }
        hingeJoint.motor = jointMotor;
    }

    void LimitBreak()
    {
        hingeJoint.useLimits = false;
    }

    void LimitEnable()
    {
        hingeJoint.useLimits = true;
    }
}
