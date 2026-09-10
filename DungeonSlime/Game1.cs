using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;


namespace DungeonSlime;

public class Game1 : Core
{
  // texture region that defines the slime sprite in the atlas.
  private TextureRegion _slime;
  
  // texture region that defines the bat sprite in the atlas.
  private TextureRegion _bat;                                                                   // The MonoGame logo texture
                                                                                                // private Texture2D _logo;

    public Game1() : base("Dungeon Slime", 1280, 720, false)
    {
        
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Load the atlas texture using the content manager
        Texture2D atlasTexture = Content.Load<Texture2D>("images/atlas");

        //  Create a TextureAtlas instance from the atlas
        TextureAtlas atlas = new TextureAtlas(atlasTexture);

        // add the slime region to the atlas.
        atlas.AddRegion("slime", 0, 0, 20, 20);

        // add the bat region to the atlas.
        atlas.AddRegion("bat", 20, 0, 20, 20);

        // retrieve the slime region from the atlas.
        _slime = atlas.GetRegion("slime");

        // retrieve the bat region from the atlas.
        _bat = atlas.GetRegion("bat");                                                       // _logo = Content.Load<Texture2D>("images/logo");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Clear the back buffer.
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw the slime texture region at a scale of 4.0
        _slime.Draw(SpriteBatch, Vector2.Zero, Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 0.0f);

        // Draw the bat texture region 10px to the right of the slime at a scale of 4.0
        _bat.Draw(SpriteBatch, new Vector2(_slime.Width * 4.0f + 10, 0), Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 1.0f);

        // Always end the sprite batch when finished.
        SpriteBatch.End();

       /* // The bounds of the icon within the texture.
        Rectangle iconSourceRect = new Rectangle(0, 0, 128, 128);

        // the bounds of the word mark within the texture.
        Rectangle wordmarkSourceRect = new Rectangle(150, 34, 458, 58);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack);

        // Draw only the icon portion of the texture.
        SpriteBatch.Draw(
            _logo,                          // texture
            new Vector2(                    // position                   // Alternate way of modifying sprite position when origin is (0,0)
                Window.ClientBounds.Width,                                // (Window.ClientBounds.Width * 0.5f) - (_logo.Width * 0.5f), 
                Window.ClientBounds.Height) * 0.5f,                       // (Window.ClientBounds.Height * 0.5f) - (_logo.Height * 0.5f)),
                iconSourceRect,                       // sourceRectangle
                Color.White,         // color (* 0.0 - 1.0f = opacity)
                0.0f,                       // rotation (MathHelper.ToRadians(90))   
                new Vector2(
                    iconSourceRect.Width,
                    iconSourceRect.Height) * 0.5f,   // origin
                1.0f,                       // scale (new Vector2(1.0f, 1.0f))
                SpriteEffects.None,         // effects (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically,)
                1.0f                        // layerDepth
                );

        // Draw only the word mark portion of the texture.
        SpriteBatch.Draw(
            _logo,                          // texture
            new Vector2(                    // position                   // Alternate way of modifying sprite position when origin is (0,0)
                Window.ClientBounds.Width,                                // (Window.ClientBounds.Width * 0.5f) - (_logo.Width * 0.5f), 
                Window.ClientBounds.Height) * 0.5f,                       // (Window.ClientBounds.Height * 0.5f) - (_logo.Height * 0.5f)),
                wordmarkSourceRect,                       // sourceRectangle
                Color.White,         // color (*0.0 - 1.0f = opacity)
                0.0f,                       // rotation (MathHelper.ToRadians(90))   
                new Vector2(
                    wordmarkSourceRect.Width,
                    wordmarkSourceRect.Height) * 0.5f,   // origin
                1.0f,                       // scale (new Vector2(1.0f, 1.0f))
                SpriteEffects.None,         // effects (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically,)
                0.0f                        // layerDepth
                );

        // Always end the sprite batch when finished.
        SpriteBatch.End(); */

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
