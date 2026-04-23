using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxSpeed = 0.5f;
    private float textureWidth;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private bool isParallaxActive = true;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        textureWidth = sprite.bounds.size.x;
    }

    void LateUpdate()
    {
        if (!isParallaxActive) return;

        // Parallax movement
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxSpeed, 0f, 0f);
        lastCameraPosition = cameraTransform.position;

        // Infinite repeat
        float cameraX = cameraTransform.position.x;
        float layerX = transform.position.x;

        if (Mathf.Abs(cameraX - layerX) >= textureWidth)
        {
            float offset = (cameraX > layerX) ? textureWidth : -textureWidth;
            transform.position += new Vector3(offset, 0, 0);
        }
    }

    // Call this when player touches the border
    public void DisableParallax()
    {
        isParallaxActive = false;
    }
}
