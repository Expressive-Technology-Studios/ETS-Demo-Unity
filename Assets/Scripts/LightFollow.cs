using UnityEngine;

public class SmoothLookAt : MonoBehaviour
{
    public GameObject target; /*thing to track. set in editor*/
    public float rotationSpeed = 5f; /*speed to rotate at. 5 is really slow by default so mess with it*/
    public bool isTracking = false; /*turn tracking on or off*/

    void Update()
    {
        /*if tracking is on and the target exists (hopefully it should lmao)*/
        if (isTracking && target.transform != null)
        {
            /*3d vector pointing from light to target*/
            Vector3 direction = target.transform.position - transform.position;
            /*quaternion represention the amt of rotation needed to change the look
            vector of the light to direction (above)*/
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // for the time increment update covers, change the rot
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, /*starting rotation*/
                targetRotation, /*target rotation*/
                rotationSpeed * Time.deltaTime /*max rotation per frame*/
            );
        }
    }
}

