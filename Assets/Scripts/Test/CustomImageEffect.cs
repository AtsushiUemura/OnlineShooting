using UnityEngine;

public class CustomImageEffect : MonoBehaviour {
    public Material material;
    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        Graphics.Blit(source, destination, material);
    }
}