using UnityEngine;

public class LightingTestScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Light spotLight;              // reference to spotlight
    public float switchInterval = 3f;    // seconds btwn color switches

    private float timer = 0f;
    private bool isRed;

    void Start()
    {
        if (spotLight == null)
        {
            spotLight = GetComponent<Light>(); // Auto-assign if not set
        }

        if (spotLight != null)
        {
            spotLight.color = Color.red; // start on red
            isRed = true;
        }
    }

    void Update()
    {
        if (spotLight == null) return;

        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {

            if(isRed)
            {
                spotLight.color = Color.green;
            }
            else
            {
                spotLight.color = Color.red;
            }
            isRed = !isRed;
            timer = 0f;
        }
    }

}
