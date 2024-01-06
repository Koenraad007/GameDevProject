using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoodleAdventures;

public class Hero : IGameObject
{
    private Texture2D _head, _torso, _armR, _armL, _legR, _legL;
    private Vector2 _position;
    private int _speed;
    private short _rotation;
    private float _rightArmRotation, _leftArmRotation;

    public Hero(Texture2D head, Texture2D torso, Texture2D armR, Texture2D armL, Texture2D legR, Texture2D legL)
    {
        _head = head;
        _torso = torso;
        _armR = armR;
        _armL = armL;
        _legR = legR;
        _legL = legL;

        _position = new Vector2(100, 100);
        _speed = 1;
        _rotation = 0;

        _rightArmRotation = 1.3f;
        _leftArmRotation = -1.3f;
    }

    public void Update(GameTime gameTime)
    {
        Move();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_torso, _position, Color.White);
        spriteBatch.Draw(_head,_position+new Vector2(0,-40),Color.White);
        spriteBatch.Draw(_armL, _position+new Vector2(0,0), new Rectangle(0,0,40,20),Color.White, _leftArmRotation, new Vector2(40,10), 1f, SpriteEffects.None, 0f);
        spriteBatch.Draw(_armR, _position+new Vector2(40,0),new Rectangle(0,0,40,20),Color.White, _rightArmRotation, new Vector2(0,10), 1f, SpriteEffects.None, 0f);
        spriteBatch.Draw(_legL, _position+new Vector2(0,40),Color.White);
        spriteBatch.Draw(_legR, _position+new Vector2(20,40),Color.White);
        
    }

    private void Move()
    {
        KeyboardState state = Keyboard.GetState();
        var direction = 0;
        if (state.IsKeyDown(Keys.Left)) direction--;
        if (state.IsKeyDown(Keys.Right)) direction++;
        direction *= _speed;
        _position.X += direction;
    }
}