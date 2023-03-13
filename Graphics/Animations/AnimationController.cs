using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

public interface IAnimationController {
    SpriteBatch spriteBatch {get;}
    ContentManager content {get;}

    bool IsPlaying {get;set;}
    float AnimationProgress{get; set;}

    void Update(GameTime gt);
    void Draw(Vector2 pos);
    void Play();
    void Stop();

}

public class AnimationController : IAnimationController {
    private IAnimation _animation;

    public SpriteBatch spriteBatch {get;}
    public ContentManager content {get;}

    public bool IsPlaying { get; set; } = true;
    public float AnimationProgress { get; set; }

    public Frame CurrentFrame {
        get {
            return _animation.frames
            .Where(f => f.TimeStamp <= AnimationProgress)
            .MaxBy(f => f.TimeStamp);
        }
    }

    public float Duration {
        get {
            if(!_animation.frames.Any())
                return 0;

            return _animation.frames.Max(f => f.TimeStamp);
        }
    }

    public AnimationController(IAnimation anim, SpriteBatch s){
        _animation = anim;
        spriteBatch = s;
    }

    public void Draw(Vector2 pos)
    {
        Frame frame = CurrentFrame;

        if(frame != null)
            frame.SpriteFrame.Draw(spriteBatch, pos);
    }

    public void Play()
    {
        IsPlaying = true;
    }

    public void Stop()
    {
        IsPlaying = false;
        AnimationProgress = 0f;
    }

    public void Update(GameTime gt)
    {
        if (!IsPlaying)
            return;

        AnimationProgress += (float)gt.ElapsedGameTime.TotalSeconds;

        if(AnimationProgress > Duration)
            AnimationProgress -= Duration;
    }
}