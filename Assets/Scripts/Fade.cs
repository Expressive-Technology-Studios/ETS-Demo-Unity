/*
 * Fade:
 * Fade gameobjects that have opaque materials.
 *
 * Almost, but needed this resource to finish:  https://youtu.be/vmLIy62Gsnk?si=SAuaZ9t7aKDRAyGl
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField]
    List<Renderer> _renderers;

    [SerializeField]
    float _fadeAmount;

    [SerializeField]
    float _fadeDelay;

    [SerializeField]
    bool _opaqueMaterials;

    [SerializeField]
    bool _retainShadows = true;

    private void Awake()
    {
        if (_renderers.Count == 0)
        {
            _renderers.AddRange(GetComponentsInChildren<Renderer>());
        }
    }

    public void StartFadeOut()
    {
        print("Starting fade");
        FadeAllMaterialsOut();
    }

    public void StartFadeIn()
    {
        FadeAllMaterialsIn();
    }

    private void FadeAllMaterialsOut()
    {
        foreach (var renderer in _renderers)
        {
            var materials = renderer.materials;
            foreach (var material in materials)
            {
                if (_opaqueMaterials)
                    ConvertToTransparent(material);
                StartCoroutine(FadeOut(material));
            }
            Debug.Log("Starting next object...");
        }
    }

    private void FadeAllMaterialsIn()
    {
        foreach (var renderer in _renderers)
        {
            var materials = renderer.materials;
            foreach (var material in materials)
            {
                StartCoroutine(FadeIn(material));
            }
            Debug.Log("Starting next object...");
        }
    }

    private void ConvertToTransparent(Material material)
    {
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.SetInt("_Surface", 1);

        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

        material.SetShaderPassEnabled("DepthOnly", false);
        material.SetShaderPassEnabled("SHADOWCASTER", _retainShadows);

        material.SetOverrideTag("RenderType", "Transparent");

        material.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
        material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
    }

    private void ConvertToOpaque(Material material)
    {
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        material.SetInt("_ZWrite", 1);
        material.SetInt("_Surface", 0);

        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Geometry;

        material.SetShaderPassEnabled("DepthOnly", true);
        material.SetShaderPassEnabled("SHADOWCASTER", true);

        material.SetOverrideTag("RenderType", "Opaque");

        material.DisableKeyword("_SURFACE_TYPE_TRANSPARENT");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
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
        // For a more generic use, would not want to delete the gameobject here.
        //Destroy(this.gameObject);
    }

    IEnumerator FadeIn(Material material)
    {
        while (material.color.a < 0.99f)
        {
            var alpha = material.color.a + _fadeAmount;
            Color color = new Color(material.color.r, material.color.g, material.color.b, alpha);
            material.color = color;
            yield return new WaitForSeconds(_fadeDelay);
        }
        Debug.Log("All Back!");

        if (_opaqueMaterials)
            ConvertToOpaque(material);
        //Destroy(this.gameObject);
    }
}
