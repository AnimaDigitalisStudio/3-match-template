using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    public Row[] rows;
    public Tile[,] Tiles { get; private set; }
    public int Width => Tiles.GetLength( dimension: 0 );
    public int Height => Tiles.GetLength( dimension: 1);
    private void Awake() => Instance = this;
    private readonly List<Tile> _selection = new List<Tile>();

    private void Start()
    {
        Tiles = new Tile[rows.Max(row => row.tiles.Length), rows.Length];

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x< Width; x++)
            {
                var tile = rows[y].tiles[x];

                tile.x = x;
                tile.y = y;

                Tiles[x, y] = tile;
                tile.Item =ItemDatabase.Items[Random.Range(0, ItemDatabase.Items.Length)];

            }
        }
    }

    public void Select(Tile tile)
    {
        if (!_selection.Contains(tile)) _selection.Add(tile);

        if (_selection.Count < 2) return;

        Debug.Log($"Selected tales at ({_selection[0].x}, {_selection[0].y}) and ({_selection[1].x}, {_selection[1].y})");

        _selection.Clear();
    }

    public void Swap(Tile tile1, Tile tile2)
    {
        
    }
}
