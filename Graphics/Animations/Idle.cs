using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

//x: 40 y: 0
public class Idle : IAnimation {
    private Texture2D idleSpriteSheet { get; set; }
    public Sprite IdleSprite { get; private set; }
    public Animation animation;
    private Random random;
    private int frameCount;

    public SpriteBatch _spriteBatch {get; private set;}

    public Idle(SpriteBatch SpriteBatch, ContentManager Content) {
        _spriteBatch = SpriteBatch;
        idleSpriteSheet = Content.Load<Texture2D>("Textures\\TrexSpriteSheet");
        IdleSprite = new Sprite(idleSpriteSheet, 40, 0, 44, 52);
        animation = new Animation();
        random = new Random();
        
        frameCount = animation.TotalFrames;
        float timeStamp = frameCount + (float)random.NextDouble() * (10f - frameCount);
        
        //animation.Loop = false;
        animation.AddFrame(new Sprite(idleSpriteSheet, 848, 0, 44, 52), 0);
        animation.AddFrame(new Sprite(idleSpriteSheet, 848 + 44, 0, 44, 52), 1/20f);
        animation.AddFrame(new Sprite(idleSpriteSheet, 848, 0, 44, 52), 1/20f * 2f);
        animation.Play();
    }

    public void Draw(Vector2 pos) {
        animation.Draw(_spriteBatch, pos);
    }

    public void Update(GameTime gt) {
        animation.Update(gt);
    }

    public void Play()
    {
        //animation.Play(animation.)
    }
}