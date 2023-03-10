using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using TrexGame.Entities;
using TrexGame.Graphics;
using TrexGame.Graphics.Animations;

namespace TrexGame;

public class TRexRunnerGame : Game {
    private const string TREX_SPRITESHEET = "Textures\\TrexSpriteSheet";
    private const string TREX_SFX_HIT = "Sounds\\hit";
    private const string TREX_SFX_SCORE_REACHED = "Sounds\\score-reached";
    private const string TREX_SFX_BUTTON_PRESSED = "Sounds\\button-press";

    public const int WINDOW_WIDTH = 600;
    public const int WINDOW_HEIGHT = 150;
    private const int TREX_START_POS_X = 1;
    private const int TREX_START_POS_Y = WINDOW_HEIGHT - 68;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private SoundEffect _sfxHit;
    private SoundEffect _sfxButtonPress;
    private SoundEffect _sfxScoreReached;

    public Texture2D _spriteSheetTexture { get; set; }

    private Trex _trex;

    public TRexRunnerGame() {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        // TODO: Add your initialization logic here

        base.Initialize();
        _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
        _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
        _graphics.ApplyChanges();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _sfxHit = Content.Load<SoundEffect>(TREX_SFX_HIT);
        _sfxScoreReached = Content.Load<SoundEffect>(TREX_SFX_SCORE_REACHED);
        _sfxButtonPress = Content.Load<SoundEffect>(TREX_SFX_BUTTON_PRESSED);
        _spriteSheetTexture = Content.Load<Texture2D>(TREX_SPRITESHEET);
        _trex = new Trex(_spriteBatch, Content);
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
        _trex.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.White);

        _spriteBatch.Begin();
        _trex.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
