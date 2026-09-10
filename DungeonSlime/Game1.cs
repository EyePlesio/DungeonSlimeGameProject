using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;
using MonoGameLibrary.Input;


namespace DungeonSlime;

public class Game1 : Core
{
    // Defines the slime animated sprite.
    private AnimatedSprite _slime;

    // Defines the bat animated sprite.
    private AnimatedSprite _bat;

    // Tracks the position of the slime.
    private Vector2 _slimePosition;

    // Speed multiplier when moving.
    private const float MOVEMENT_SPEED = 5.0f;

    // // Defines the slime sprite.
    // private Sprite _slime;

    // // Defines the bat sprite.
    // private Sprite _bat;

    //   // texture region that defines the slime sprite in the atlas.
    //   private TextureRegion _slime;
  
    //   // texture region that defines the bat sprite in the atlas.
    //   private TextureRegion _bat;

    // // The MonoGame logo texture
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
        // // Load the atlas texture using the content manager
        // Texture2D atlasTexture = Content.Load<Texture2D>("images/atlas");

        // //  Create a TextureAtlas instance from the atlas
        // TextureAtlas atlas = new TextureAtlas(atlasTexture);

        // // add the slime region to the atlas.
        // atlas.AddRegion("slime", 0, 0, 20, 20);

        // // add the bat region to the atlas.
        // atlas.AddRegion("bat", 20, 0, 20, 20);

        // Create the texture atlas from the XML configuration file
        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");

        // Create the slime animated sprite from the atlas.
        _slime = atlas.CreateAnimatedSprite("slime-animation");
        _slime.Scale = new Vector2(4.0f, 4.0f);

        // Create the bat animated sprite from the atlas.
        _bat = atlas.CreateAnimatedSprite("bat-animation");
        _bat.Scale = new Vector2(4.0f, 4.0f);
        
        // // Create the slime sprite from the atlas.
        // _slime = atlas.CreateSprite("slime");
        // _slime.Scale = new Vector2(4.0f, 4.0f);

        // // Create the bat sprite from the atlas.
        // _bat = atlas.CreateSprite("bat");
        // _bat.Scale = new Vector2(4.0f, 4.0f);

        // // retrieve the slime region from the atlas.
        // _slime = atlas.GetRegion("slime");

        // // retrieve the bat region from the atlas.
        // _bat = atlas.GetRegion("bat");                                                       // _logo = Content.Load<Texture2D>("images/logo");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        // Update the InputManager inside base.Update() right away.
        base.Update(gameTime);

        // Update the slime animated sprite.
        _slime.Update(gameTime);

        // Update the bat animated sprite.
        _bat.Update(gameTime);
        
         // Check for keyboard input and handle it.
        CheckKeyboardInput();

        // Check for gamepad input and handle it.
        CheckGamePadInput();

        // TODO: Add your update logic here

        
    }

private void CheckKeyboardInput()
    {
        // If the space key is held down, the movement speed increases by 1.5
        float speed = MOVEMENT_SPEED;
        if (Input.Keyboard.IsKeyDown(Keys.Space))
        {
            speed *= 1.5f;
        }

        // If the W or Up keys are down, move the slime up on the screen.
        if (Input.Keyboard.IsKeyDown(Keys.W) || Input.Keyboard.IsKeyDown(Keys.Up))
        {
            _slimePosition.Y -= speed;
        }

        // if the S or Down keys are down, move the slime down on the screen.
        if (Input.Keyboard.IsKeyDown(Keys.S) || Input.Keyboard.IsKeyDown(Keys.Down))
        {
            _slimePosition.Y += speed;
        }

        // If the A or Left keys are down, move the slime left on the screen.
        if (Input.Keyboard.IsKeyDown(Keys.A) || Input.Keyboard.IsKeyDown(Keys.Left))
        {
            _slimePosition.X -= speed;
        }

        // If the D or Right keys are down, move the slime right on the screen.
        if (Input.Keyboard.IsKeyDown(Keys.D) || Input.Keyboard.IsKeyDown(Keys.Right))
        {
            _slimePosition.X += speed;
        }
    }

    private void CheckGamePadInput()
    {
        GamePadInfo gamePadOne = Input.GamePads[(int)PlayerIndex.One];

        // If the A button is held down, the movement speed increases by 1.5
        // and the gamepad vibrates as feedback to the player.
        float speed = MOVEMENT_SPEED;
        if (gamePadOne.IsButtonDown(Buttons.A))
        {
            speed *= 1.5f;
            GamePad.SetVibration(PlayerIndex.One, 1.0f, 1.0f);
        }
        else
        {
            GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
        }

        // Check thumbstick first since it has priority over which gamepad input
        // is movement.  It has priority since the thumbstick values provide a
        // more granular analog value that can be used for movement.
        if (gamePadOne.LeftThumbStick != Vector2.Zero)
        {
            _slimePosition.X += gamePadOne.LeftThumbStick.X * speed;
            _slimePosition.Y -= gamePadOne.LeftThumbStick.Y * speed;
        }
        else
        {
            // If DPadUp is down, move the slime up on the screen.
            if (gamePadOne.IsButtonDown(Buttons.DPadUp))
            {
                _slimePosition.Y -= speed;
            }

            // If DPadDown is down, move the slime down on the screen.
            if (gamePadOne.IsButtonDown(Buttons.DPadDown))
            {
                _slimePosition.Y += speed;
            }

            // If DPapLeft is down, move the slime left on the screen.
            if (gamePadOne.IsButtonDown(Buttons.DPadLeft))
            {
                _slimePosition.X -= speed;
            }

            // If DPadRight is down, move the slime right on the screen.
            if (gamePadOne.IsButtonDown(Buttons.DPadRight))
            {
                _slimePosition.X += speed;
            }
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        // Clear the back buffer.
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw the slime sprite.
        _slime.Draw(SpriteBatch, _slimePosition);

        // Draw the bat sprite 10px to the right of the slime.
        _bat.Draw(SpriteBatch, new Vector2(_slime.Width + 10, 0));

        // // Draw the slime texture region at a scale of 4.0
        // _slime.Draw(SpriteBatch, Vector2.Zero, Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 0.0f);

        // // Draw the bat texture region 10px to the right of the slime at a scale of 4.0
        // _bat.Draw(SpriteBatch, new Vector2(_slime.Width * 4.0f + 10, 0), Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 1.0f);

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
