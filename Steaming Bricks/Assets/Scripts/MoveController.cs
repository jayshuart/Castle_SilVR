using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using UnityEngine.XR;

public class MoveController : MonoBehaviour {

    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;

    [SerializeField] private float scaler;
    [SerializeField] private float verticalDrop;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        //RIGHT HAND
        //get pos and rot
        Vector3 rightPosition = InputTracking.GetLocalPosition(XRNode.RightHand);
        //rightPosition = new Vector3(rightPosition.x - 1.0f, rightPosition.y - 1.0f, rightPosition.z - 1.0f);
        rightPosition = rightPosition * scaler;
        rightPosition.y -= verticalDrop;

        Quaternion rightRotation = InputTracking.GetLocalRotation(XRNode.RightHand);

        //set pos and rot
        rightHand.transform.position =  rightPosition;
        rightHand.transform.rotation = rightRotation;

        //LEFT HAND
        //get pos and rot
        Vector3 leftPosition = InputTracking.GetLocalPosition(XRNode.LeftHand);
        leftPosition = leftPosition * scaler;
        leftPosition.y -= verticalDrop;

        Quaternion leftRotation = InputTracking.GetLocalRotation(XRNode.LeftHand);

        //set pos and rot
        leftHand.transform.position = leftPosition;
        leftHand.transform.rotation = leftRotation;


    }

    private Vector3 TrackMovement(GameObject handGO, XRNode handNode)
    {
        //get XR node position values
        Vector3 nodePos = InputTracking.GetLocalPosition(handNode);

        //calc vector3 to be added to objs pos
        float x = 0;
        float y = 0;
        float z = 0;

        //x w/ deadzone
        if (nodePos.x > .2f)
        {
            x += .5f;
        }
        else if (nodePos.x < -.2f)
        {
            x -= .5f;
        }

        //y w/ deadzone
        if (nodePos.y > .2f)
        {
            y += .5f;
        }
        else if (nodePos.y < -.2f)
        {
            y -= .5f;
        }

        return nodePos;
    }

}