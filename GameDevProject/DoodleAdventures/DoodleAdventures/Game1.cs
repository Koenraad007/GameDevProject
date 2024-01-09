using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DoodleAdventures;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background, _tileSet;
    private Hero _hero;
    private Dictionary<string,Texture2D> _heroTextures;
    private List<Block> _blocks;
    private Level lvl1;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 640;
        _graphics.PreferredBackBufferHeight = 480;
        _graphics.ApplyChanges();

        base.Initialize();

        _hero = new Hero(
            _heroTextures["head"], 
            _heroTextures["torso"],
            _heroTextures["armR"],
            _heroTextures["armL"],
            _heroTextures["legR"],
            _heroTextures["legL"]);

        lvl1 = new Level(_tileSet, 32);
        _blocks = lvl1.CreateBlocks("./level1.txt");        // txt files need to be in ./bin/Debug/net6/ -> needs to change
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _background = Content.Load<Texture2D>("sqrd_grid_paper");

        _heroTextures = new Dictionary<string, Texture2D>()
        {
            {"head", Content.Load<Texture2D>("head")},
            {"torso", Content.Load<Texture2D>("torso")},
            {"armR", Content.Load<Texture2D>("right_arm")},
            {"armL", Content.Load<Texture2D>("left_arm")},
            {"legR", Content.Load<Texture2D>("right_leg")},
            {"legL", Content.Load<Texture2D>("left_leg")}
        };

        _tileSet = Content.Load<Texture2D>("tileset32");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        _hero.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_background,Vector2.Zero, new Rectangle(0,0,640,480),Color.White);
        
        foreach (var block in _blocks)
        {
            block.Draw(_spriteBatch);
        }
        
        _hero.Draw(_spriteBatch);
        
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}