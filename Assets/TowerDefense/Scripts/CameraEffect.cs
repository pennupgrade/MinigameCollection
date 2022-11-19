using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraEffect : MonoBehaviour
{
    public Shader shader;
    private Material material;

    public void Start()
    {
        material = new Material(shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (material == null || !GameManager.Instance.timeSlowed)
        {
            Graphics.Blit(source, destination);
            return;
        }

        Graphics.Blit(source, destination, material);
    }
}