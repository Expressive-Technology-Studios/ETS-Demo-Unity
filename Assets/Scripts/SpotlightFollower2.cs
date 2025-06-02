using UnityEngine;

public class SpotlightFollower : MonoBehaviour
{
    public Transform spotlightToFollow; // Assign the spotlight GameObject with SmoothLookAt in the Inspector
    public bool followPosition = false; // Optional: set true if you want the asset to follow position too

    void Update()
    {
        if (spotlightToFollow != null)
        {
            // Match the rotation of the real spotlight
            transform.rotation = spotlightToFollow.rotation;

            if (followPosition)
            {
                // Optional: match the position too
                transform.position = spotlightToFollow.position;
            }
        }
    }
}
