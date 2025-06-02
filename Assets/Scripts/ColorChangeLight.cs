using UnityEngine;

public class ColorChangingSpotlight : MonoBehaviour
{
    public Light spotlight; // Drag the spotlight object here in the inspector
    public Color targetColor; // The color you want to change to
    public float transitionSpeed = 1.0f; // How fast the color changes

    private Color currentColor; // The current color of the spotlight

    void Start()
    {
        // Initialize the currentColor with the spotlight's initial color
        if (spotlight != null)
        {
            currentColor = spotlight.color;
        }
        else
        {
            Debug.LogWarning("Spotlight not assigned. Make sure to assign a spotlight in the inspector.");
        }
    }

    void Update()
    {
        // If a target color is set and the current color is different, smoothly transition
        if (spotlight != null && currentColor != targetColor)
        {
            currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * transitionSpeed);

            // Update the spotlight's color
            spotlight.color = currentColor;
        }
    }

    // Function to set the target color
    public void SetTargetColor(Color newTargetColor)
    {
        targetColor = newTargetColor;
    }
}