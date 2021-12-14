using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class UnderwaterEffect : MonoBehaviour
{
    [Header("Shader Variable")]
    public Material mat;
    [Range(0.001f, 0.1f)]
    public float pixelOffset;
    [Range(0.1f, 20f)]
    public float noiseScale;
    [Range(0.1f, 20f)]
    public float noiseFrequency;
    [Range(0.1f, 30f)]
    public float noiseSpeed;

    public float depthStart, depthDistance;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("_NoiseScale", noiseScale);
        mat.SetFloat("_NoiseFrequency", noiseFrequency);
        mat.SetFloat("_NoiseSpeed", noiseSpeed);
        mat.SetFloat("_PixelOffset", pixelOffset);
        mat.SetFloat("_DepthStart", depthStart);
        mat.SetFloat("_DepthDistance", depthDistance);

    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, mat);
    }
}
