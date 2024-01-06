using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoodleAdventures;

public class Hero : IGameObject
{
    private Texture2D _head, _torso, _armR, _armL, _legR, _legL;
    private Vector2 _position;

    public Hero(Texture2D head, Texture2D torso, Texture2D armR, Texture2D armL, Texture2D legR, Texture2D legL)
    {
        _head = head;
        _torso = torso;
        _armR = armR;
        _armL = armL;
        _legR = legR;
        _legL = legL;

        _position = new Vector2(100, 100);
    }

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_torso, _position, Color.White);
        spriteBatch.Draw(_head,_position-new Vector2(0,40),Color.White);
        spriteBatch.Draw(_armL, _position-new Vector2(40,0),Color.White);
        spriteBatch.Draw(_armR, _position+new Vector2(40,0),Color.White);
        spriteBatch.Draw(_legL, _position+new Vector2(0,40),Color.White);
        spriteBatch.Draw(_legR, _position+new Vector2(20,40),Color.White);
    }
}