using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoodleAdventures;

public interface IGameObject
{
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);
}