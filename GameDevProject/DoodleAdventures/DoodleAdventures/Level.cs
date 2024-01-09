using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        List<Block> blocks = new List<Block>();

        int[,] gameB = new int[8,8];
        try
        {
            using (var sr = new StreamReader(levelFilePath))
            {
                for (int i = 0; i < 8; i++)
                {
                    Char[] tiles = sr.ReadLine().ToCharArray();
                    for (int j = 0; j < 8; j++)
                    {
                        gameB[i, j] = tiles[j]-'0';
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        Console.WriteLine(gameB.ToString());
        
        for (int i = 0; i < gameB.GetLength(0); i++)
        {
            for (int j = 0; j < gameB.GetLength(1); j++)
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
}