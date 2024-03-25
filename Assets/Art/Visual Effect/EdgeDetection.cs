using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EdgeDetection : MonoBehaviour
{
    [System.NonSerialized]
    public MaterialPropertyBlock block;
    [System.NonSerialized]
    public MeshFilter meshFilter;

    public Material mat;
    public Camera _camera;

    public bool enable;
    public Color edgeColour;
    public float sampleDistance;
    public float normalSensitivity;
    public float depthSensitivity;

    private void Start()
    {
        // _camera = GetComponent<Camera>();
        Debug.Log(_camera);
        _camera.depthTextureMode = DepthTextureMode.DepthNormals;
        block = new MaterialPropertyBlock();
    }

    private void Update()
    {
        SetInfo();
        if (enable)
        {
            DrawObject(this.meshFilter, block);
        }    
    }

    void SetInfo()
    {
        block = new MaterialPropertyBlock();
        meshFilter = GetComponent<MeshFilter>();
        block.SetColor("_EdgeColour", edgeColour);
        block.SetFloat("_SampleDistance", sampleDistance);
        block.SetFloat("_NormalSensitivity", normalSensitivity);
        block.SetFloat("_DepthSensitivity", depthSensitivity);
    }

    void DrawObject(MeshFilter meshFilter, MaterialPropertyBlock block)
    {
        Matrix4x4 drawMatrix = meshFilter.transform.localToWorldMatrix;

        Graphics.DrawMesh(meshFilter.sharedMesh, drawMatrix, mat, 0, null, 0, block);
    }
}
