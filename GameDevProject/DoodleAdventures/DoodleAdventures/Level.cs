using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace DoodleAdventures;

public class Level
{
    public Texture2D TileSet;
    public int TileSetSize;

    public Level(Texture2D tileSet, int tileSetSize)
    {
        TileSet = tileSet;
        TileSetSize = tileSetSize;
    }

    public List<Block> CreateBlocks(String levelFilePath)
    {
        var blocks = new List<Block>();

        var gameB = readLevelFromFile(levelFilePath);

        for (var i = 0; i < gameB.GetLength(0); i++)
        {
            for (var j = 0; j < gameB.GetLength(1); j++)
            {
                (int x, int y) tile = (0, 0);

                switch (gameB[i, j])
                {
                    case 1:
                        tile = (0, 0);
                        break;
                    case 2:
                        tile = (0, 1);
                        break;
                    case 3:
                        tile = (0, 2);
                        break;
                    case 4:
                        tile = (1, 0);
                        break;
                    case 5:
                        tile = (1, 1);
                        break;
                    case 6:
                        tile = (1, 2);
                        break;
                    case 7:
                        tile = (2, 0);
                        break;
                    case 8:
                        tile = (2, 1);
                        break;
                    case 9:
                        tile = (2, 2);
                        break;
                    default:
                        break;
                }

                blocks.Add(new Block(new Vector2(j, i) * TileSetSize, TileSet,
                    new Vector2(tile.x, tile.y) * TileSetSize, TileSetSize));
            }
        }

        return blocks;
    }

    private int[,] readLevelFromFile(string levelFilePath)
    {
        int rows = 0;
        int cols = 0;
        using (var reader = File.OpenText(levelFilePath))
        {
            cols = reader.ReadLine().Length;
            rows++;
            while (reader.ReadLine() != null)
            {
                rows++;
            }
        }

        int[,] intMatrix = new int[rows, cols];

        try
        {
            using var sr = new StreamReader(levelFilePath);
            for (var i = 0; i < rows; i++)
            {
                var tiles = sr.ReadLine()?.ToCharArray();
                for (var j = 0; j < cols; j++)
                {
                    if (tiles != null) intMatrix[i, j] = tiles[j] - '0';
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return intMatrix;
    }
}