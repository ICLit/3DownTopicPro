using UnityEngine;

public class SetCameraDepth : MonoBehaviour
{


    private Camera myCamera;
    public Camera camera
    {
        get
        {
            if (myCamera == null)
            {
                myCamera = GetComponent<Camera>();
            }
            return myCamera;
        }
    }

    void OnEnable()
    {
        camera.depthTextureMode |= DepthTextureMode.Depth;
    }

}