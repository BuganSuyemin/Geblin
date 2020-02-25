using UnityEngine;

public class CameraPlacer 
{
    private Camera mainCamera;
    private Vector2Int size;
    private int margin;

    public CameraPlacer(Camera _mainCamera, Vector2Int _size, int _margin)
    {
        mainCamera = _mainCamera;
        size = _size;
        margin = _margin;
    }

    public void SetCamera()
    {
        mainCamera.transform.position = (Vector3)((Vector2)size / 2) - new Vector3(0.5f, 0.5f, 10f);

        Vector2Int screenSize = new Vector2Int(Screen.width, Screen.height);
        Vector2Int actualSize = screenSize - new Vector2Int(margin, margin);

        Vector2 pixelPerUnit = new Vector2((float)actualSize.x / size.x, (float)actualSize.y / size.y);
        float maxPixelPerUnit = pixelPerUnit.x > pixelPerUnit.y ? pixelPerUnit.x : pixelPerUnit.y;

        if (pixelPerUnit.x > pixelPerUnit.y)
            mainCamera.orthographicSize = (size.y + margin / maxPixelPerUnit) / 2f;
        else
        {
            //Debug.Log("pixelPerUnit y = " + maxPixelPerUnit);
            SetCameraWidth((size.x + margin / maxPixelPerUnit) / 2f);
        }//mainCamera.orthographicSize = size.x / 2f * screenSize.y / screenSize.x + margin / density.x;
    }

    private void SetCameraWidth(float width)
    {
        mainCamera.orthographicSize = width / mainCamera.aspect;
    }
}
