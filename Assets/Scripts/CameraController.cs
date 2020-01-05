using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject BallObject;

    private Vector3 offsetPosition;

    private Vector3 PositionOffset;

    float RotationSpeed = 5.0f;

    public CanvasScript CanvasSc;
    public BallController BCScript;

    private void Start()
    {
        offsetPosition = transform.position - BallObject.transform.position;
        transform.LookAt(BallObject.transform.position);

        CanvasSc = GameObject.Find("Canvas").GetComponent<CanvasScript>();
        BCScript = GameObject.Find("Ball").GetComponent<BallController>();
    }

    void LateUpdate()
    {
        if(CanvasSc.GameOver == false)
        {
            if(BCScript.GameOver == false)
            {
                Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

                offsetPosition = camTurnAngle * offsetPosition;

                Vector3 newPos = BallObject.transform.position + offsetPosition;

                transform.position = Vector3.Slerp(transform.position, newPos, 3f);

                transform.LookAt(BallObject.transform.position);
            }
        }
    }
}
