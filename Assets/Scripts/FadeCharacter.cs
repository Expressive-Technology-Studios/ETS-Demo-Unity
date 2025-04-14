using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class FadeCharacter : MonoBehaviour
{
    [SerializeField] float _fadeAmount;
    [SerializeField] float _fadeDelay;

    private void Awake()
    {
        var meshRenderer = GetComponent<SkinnedMeshRenderer>();
        var materials = meshRenderer.materials;

        foreach (var material in materials)
        {
            StartCoroutine(FadeOut(material));

        }
    }

    IEnumerator FadeOut(Material material)
    {
        while (material.color.a > 0.001f)
        {
            var alpha = material.color.a - _fadeAmount;
            Color color = new Color(material.color.r, material.color.g, material.color.b, alpha);
            material.color = color;
            yield return new WaitForSeconds(_fadeDelay);
        }
        Debug.Log("All Gone!");
        Destroy(this.gameObject);
    }
}
