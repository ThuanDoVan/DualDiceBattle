using UnityEngine;

public class DynamicGenerateSquareBoard : MonoBehaviour
{
    [SerializeField] private int col_number;
    [SerializeField] private int row_number;
    [SerializeField] private GameObject tilePrefabs;
    [SerializeField] private Vector2 tileSize;
    [SerializeField] private float margin;


    [ContextMenu("GenSquareMap")]
    public void DynamicGenSquareMap()
    {
        DestroyAllChildTile();

        for (int i = 0; i < col_number; i++)
        {
            for (int j = 0; j < row_number; j++)
            {
                var localTransformPos = LocalTransformPosition(i, j, tileSize, margin);
                var tile = Instantiate(tilePrefabs, this.transform);
                tile.transform.localPosition = localTransformPos;
                tile.transform.localScale = tileSize;
            }
        }
    }

    private Vector2 LocalTransformPosition(int col, int row, Vector2 tileSize, float margin)
    {
        var pos = new Vector2(col * tileSize.x, row * tileSize.y) + tileSize / 2 +
                  new Vector2(margin * col, margin * row);
        return pos;
    }


    private void DestroyAllChildTile()
    {
        var tempArray = new GameObject[transform.childCount];

        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = transform.GetChild(i).gameObject;
        }

        foreach (var child in tempArray)
        {
            DestroyImmediate(child);
        }
    }
}