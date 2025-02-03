using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipperL : MonoBehaviour
{
    private HingeJoint2D hingeJoint;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Enable the Hinge Joint 2D component to make it active.
            hingeJoint.useMotor = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            // Enable the Hinge Joint 2D component to make it active.
            hingeJoint.useMotor = false;
        }
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
