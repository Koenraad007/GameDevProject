using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoodleAdventures;

public class Hero : IGameObject
{
    private Texture2D _head, _torso, _armR, _armL, _legR, _legL;
    private Vector2 _position;
    private Vector2 _acceleration;
    private short _rotation, _armRotationDirection;
    private float _rightArmRotation, _leftArmRotation;
    private double _secondCtr = 0;

    public Hero(Texture2D head, Texture2D torso, Texture2D armR, Texture2D armL, Texture2D legR, Texture2D legL)
    {
        _head = head;
        _torso = torso;
        _armR = armR;
        _armL = armL;
        _legR = legR;
        _legL = legL;

        _position = new Vector2(100, 100);
        _acceleration = Vector2.Zero;
        _rotation = 0;

        _rightArmRotation = 1.3f;
        _leftArmRotation = -1.3f;
        _armRotationDirection = 1;
    }

    public void Update(GameTime gameTime)
    {

        _secondCtr += gameTime.ElapsedGameTime.TotalSeconds;
        int fps = 30;

        if (_secondCtr >= 1d/fps)
        {
            if (_rightArmRotation is < 1.3f or > 1.8f) _armRotationDirection *= -1;
            _rightArmRotation += 0.01f * _armRotationDirection;
            Move();
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_head,_position+new Vector2(0,-40),Color.White);
        spriteBatch.Draw(_armL, _position+new Vector2(0,0), new Rectangle(0,0,40,20),Color.White, _rightArmRotation*(-1), new Vector2(40,10), 1f, SpriteEffects.None, 0f);
        spriteBatch.Draw(_torso, _position, Color.White);
        spriteBatch.Draw(_armR, _position+new Vector2(40,0),new Rectangle(0,0,40,20),Color.White, _rightArmRotation, new Vector2(0,10), 1f, SpriteEffects.None, 0f);
        spriteBatch.Draw(_legL, _position+new Vector2(0,40),Color.White);
        spriteBatch.Draw(_legR, _position+new Vector2(20,40),Color.White);
        
    }

    private void Move()
    {
        var state = Keyboard.GetState();
        var speed = Vector2.Zero;
        const short maxSpeed = 10;
        var gravity = new Vector2(0, 10);
        
        // speed up
        if (state.IsKeyDown(Keys.Left) && _acceleration.X > maxSpeed*(-1)) _acceleration.X--;
        if (state.IsKeyDown(Keys.Right) && _acceleration.X < maxSpeed) _acceleration.X++;
        if (state.IsKeyDown(Keys.Up) && ((_position.Y + 80) > 470)) _acceleration.Y = -30;
        // slow down
        if (state.IsKeyUp(Keys.Left) && _acceleration.X < 0) _acceleration.X++;
        if (state.IsKeyUp(Keys.Right) && _acceleration.X > 0) _acceleration.X--;
        if (_acceleration.Y < 0) _acceleration.Y++;     // if the hero isn't jumping anymore (after pressing Up once), decrease the acceleration on the y-axis

        speed += _acceleration + gravity;
        
        // check if the sprite doesn't touch the border
        if (_position.X+speed.X >= 0 && _position.X+40+speed.X <= 640) _position.X += speed.X;
        if (_position.Y + 80 + speed.Y <= 480) _position.Y += speed.Y;
    }
}