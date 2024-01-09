using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace DoodleAdventures;

public class Block: IGameObject
{
    public Rectangle BoundingBox { get; set; }
    public Vector2 Position;
    public bool Passable { get; set; }
    public Color Color { get; set; }
    public Texture2D Texture { get; set; }

    public Block(Vector2 position, Texture2D t2, Vector2 tile, int tilesize)
    {
        BoundingBox = new Rectangle((int) tile.Y, (int) tile.X, tilesize, tilesize);
        Position = position;
        Passable = false;
        Color = Color.White;
        Texture = t2;
    }
    
    public void Update(GameTime gameTime)
    {
        //throw new System.NotImplementedException();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        int scale = 1;
        spriteBatch.Draw(Texture,Position*scale,BoundingBox,Color,0f,new Vector2(0,0),new Vector2(scale,scale),SpriteEffects.None,0f);
    }
}