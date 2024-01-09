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
                switch (gameB[i, j])
                {
                    case 1:
                        blocks.Add(new Block(new Vector2((j * TileSetSize), (i * TileSetSize)), TileSet,
                            new Vector2(0 * TileSetSize, 0 * TileSetSize), TileSetSize));
                        break;
                    case 2:
                        blocks.Add(new Block(new Vector2((j * TileSetSize), (i * TileSetSize)), TileSet,
                            new Vector2(0 * TileSetSize, 1 * TileSetSize), TileSetSize));
                        break;
                    case 3:
                        blocks.Add(new Block(new Vector2((j * TileSetSize), (i * TileSetSize)), TileSet,
                            new Vector2(0 * TileSetSize, 2 * TileSetSize), TileSetSize));
                        break;
                    case 4:
                        blocks.Add(new Block(new Vector2((j * TileSetSize), (i * TileSetSize)), TileSet,
                            new Vector2(1 * TileSetSize, 0 * TileSetSize), TileSetSize));
                        break;
                    case 5:
                        blocks.Add(new Block(new Vector2((j * TileSetSize), (i * TileSetSize)), TileSet,
                            new Vector2(1 * TileSetSize, 1 * TileSetSize), TileSetSize));
                        break;
                    case 6:
                        blocks.Add(new Block(new Vector2((j * TileSetSize), (i * TileSetSize)), TileSet,
                            new Vector2(1 * TileSetSize, 2 * TileSetSize), TileSetSize));
                        break;
                    case 7:
                        blocks.Add(new Block(new Vector2((j * TileSetSize), (i * TileSetSize)), TileSet,
                            new Vector2(2 * TileSetSize, 0 * TileSetSize), TileSetSize));
                        break;
                    case 8:
                        blocks.Add(new Block(new Vector2((j * TileSetSize), (i * TileSetSize)), TileSet,
                            new Vector2(2 * TileSetSize, 1 * TileSetSize), TileSetSize));
                        break;
                    case 9:
                        blocks.Add(new Block(new Vector2((j * TileSetSize), (i * TileSetSize)), TileSet,
                            new Vector2(2 * TileSetSize, 2 * TileSetSize), TileSetSize));
                        break;
                    default:
                        break;
                }

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