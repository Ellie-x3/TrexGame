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
    bool ShouldLoop{get;set;}

    List<Frame> frames {get;set;}
    IAnimation animation {get;set;}

    void Update(GameTime gt);
    void Draw(Vector2 pos);
    void Play();
    void Stop();
}

public sealed class AnimationController : IAnimationController {
       
    private static Dictionary<IAnimation, AnimationController> activeInstances = new Dictionary<IAnimation, AnimationController>();
    private IAnimation _animation;

    public SpriteBatch spriteBatch {get;}
    public ContentManager content {get;}
    public IAnimation animation {
        get {
            return _animation;
        }

        set {
            _animation = value;
            frames = _animation.frames;
        }
    }
    
    public bool IsPlaying { get; set; } = true;
    public float AnimationProgress { get; set; }
    public bool ShouldLoop {get; set;} = true;
    public bool IsCurrentAnimationFinished {get; private set;}
    public List<Frame> frames {get; set;}
    private static int count = 0;

    public EventHandler animationCompleted;

    private AnimationController(IAnimation anim, SpriteBatch s){
        _animation = anim;
        frames = _animation.GetFrames;
        spriteBatch = s;
        Console.WriteLine(++count);
    }

    public static AnimationController GetInstance(IAnimation anim, SpriteBatch s) {
        if(!activeInstances.ContainsKey(anim)){
            activeInstances[anim] = new AnimationController(anim, s);
            Console.WriteLine("Creating");
        }
            
        return activeInstances[anim];
    }

    public Frame CurrentFrame {
        get {
            return frames
            .Where(f => f.TimeStamp <= AnimationProgress)
            .MaxBy(f => f.TimeStamp);
        }
    }

    public float Duration {
        get {
            if(!frames.Any())
                return 0;

            return frames.Max(f => f.TimeStamp);
        }
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

    public void Clear(){
        Stop();
        frames.Clear(); 
    }

    public void Update(GameTime gt)
    {
        if (!IsPlaying)
            return;

        AnimationProgress += (float)gt.ElapsedGameTime.TotalSeconds;

        if(AnimationProgress > Duration){
          AnimationProgress = 0;

            frames = _animation.GetFrames;

            if(animationCompleted != null)
                animationCompleted(this, EventArgs.Empty);
        }
    }
}
