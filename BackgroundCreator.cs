using UnityEngine;

public class BackgroundCreator
{
    private Sprite innerBackground;
    private Sprite outerBackground;
    private Sprite border;
    private Vector2Int size;
    private Camera mainCamera;

   
    public void SetBackground()
    {
        int height = Mathf.CeilToInt(mainCamera.orthographicSize) * 2 + 2;
        int width = Mathf.CeilToInt(height / 2 * mainCamera.aspect) * 2 + 2;

        //Debug.Log($"heigth: {height}, width: {width}");

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                CreateBGObject(innerBackground, new Vector3(i, j));
            }
        }

        for (int i = 0; i < size.x; i++)
        {
            CreateBGObject(border, new Vector3(i, -1)).transform.rotation = Quaternion.Euler(0, 0, 90);
            CreateBGObject(border, new Vector3(i, size.y)).transform.rotation = Quaternion.Euler(0, 0, 270);
        }

        for (int j = 0; j < size.y; j++)
        {
            CreateBGObject(border, new Vector3(-1, j)).transform.rotation = Quaternion.Euler(0, 0, 0);
            CreateBGObject(border, new Vector3(size.x, j)).transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        for (int i = 0; i <= 1; i++)
            for (int j = 0; j <= 1; j++)
                CreateBGObject(outerBackground, new Vector2(-1 + i * (size.x + 1), -1 + j * (size.y + 1)));


        var halfWidth = Mathf.CeilToInt(width / 2f);
        var halfHeight = Mathf.CeilToInt(height / 2f);
        var offset = new Vector2(Mathf.CeilToInt(size.x / 2f), Mathf.CeilToInt(size.y / 2f));
        for (int i = -halfWidth; i < halfWidth; i++)
            for (int j = -halfHeight; j < halfHeight; j++)
            {
                var v = new Vector2(i, j) + offset;
                if (v.x >= -1 && v.y >= -1 && v.x <= size.x && v.y <= size.y)
                    continue;
                CreateBGObject(outerBackground, v);
            }
    }

    private GameObject CreateBGObject(Sprite sprite, Vector2 position)
    {
        var a = new GameObject("BG");
        var sr = a.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;
        a.GetComponent<SpriteRenderer>().sortingOrder = -5;
        a.transform.position = position;

        return a;
    }

    public BackgroundCreator(Sprite _innerBackground, Sprite _outerBackground, Sprite _border, Vector2Int _size, Camera _mainCamera)
    {
        innerBackground = _innerBackground;
        outerBackground = _outerBackground;
        border = _border;
        size = _size;
        mainCamera = _mainCamera;
    }

}
