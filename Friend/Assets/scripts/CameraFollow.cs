using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float dampTime = 0.2f;
    public float screenEdgeBuffer = 4f;
    public float minSize = 6.5f;

    public Transform[] targets;

    private Camera myCamera;
    private float zoomSpeed;
    private Vector3 moveSpeed;
    private Vector3 desiredPos;


    // Start is called before the first frame update
    private void Awake()
    {
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!(targets == null) && targets.Length > 0)
        {
            Move();

            Zoom();
        }
        
    }


    private void Move()
    {
        FindAveragePos();

        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref moveSpeed, dampTime);
    }

    private void FindAveragePos()
    {
        Vector3 averagePos = new Vector3();

        int numTargets = 0;

        for (int i=0; i < targets.Length; i++)
        {
            if (!targets[i].gameObject.activeSelf)
                continue;

            averagePos += targets[i].position;
            numTargets++;
        }

        if(numTargets > 0)
        {
            averagePos /= numTargets;
        }

        averagePos.z = transform.position.z;

        desiredPos = averagePos;
    }

    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        myCamera.orthographicSize = Mathf.SmoothDamp(myCamera.orthographicSize, requiredSize, ref zoomSpeed, dampTime);
    }

    private float FindRequiredSize()
    {
        // Find the position the camera rig is moving towards in its local space.
        Vector3 desiredLocalPos = transform.InverseTransformPoint(desiredPos);

        // Start the camera's size calculation at zero.
        float size = 0f;

        // Go through all the targets...
        for (int i = 0; i < targets.Length; i++)
        {
            // ... and if they aren't active continue on to the next target.
            if (!targets[i].gameObject.activeSelf)
                continue;

            // Otherwise, find the position of the target in the camera's local space.
            Vector3 targetLocalPos = transform.InverseTransformPoint(targets[i].position);

            // Find the position of the target from the desired position of the camera's local space.
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            // Choose the largest out of the current size and the distance of the tank 'up' or 'down' from the camera.
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

            // Choose the largest out of the current size and the calculated size based on the tank being to the left or right of the camera.
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / myCamera.aspect);
        }

        // Add the edge buffer to the size.
        size += screenEdgeBuffer;

        // Make sure the camera's size isn't below the minimum.
        size = Mathf.Max(size, minSize);

        return size;
    }

    public void SetStartPositionAndSize()
    {
        // Find the desired position.
        FindAveragePos();

        // Set the camera's position to the desired position without damping.
        transform.position = desiredPos;

        // Find and set the required size of the camera.
        myCamera.orthographicSize = FindRequiredSize();
    }
}
