using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

public class Animation<T> where T : IAnimation{

    private T animation;

    public SpriteBatch spriteBatch {get;}
    public ContentManager content {get;}

    public bool IsPlaying {get; private set;}
    public float AnimationProgress {get; private set;}

    public List<Frame> _frames {get; set;}

    public Animation(SpriteBatch s, ContentManager c){
        spriteBatch = s;
        content = c;
        animation = Activator.CreateInstance<T>();
        _frames = animation.GetFrames;
    }

    public Frame CurrentFrame {
        get {
            return _frames
            .Where(f => f.TimeStamp <= AnimationProgress)
            .MaxBy(f => f.TimeStamp);
        }
    }

    public float Duration {
        get {
            if (!_frames.Any()){
                return 0;
            }

            return _frames.Max(f => f.TimeStamp);
        }
    }

    public void Update(GameTime gt) {

    }

    public void Draw(Vector2 pos) {
        Frame frame = CurrentFrame;

        if(frame != null)
            frame.SpriteFrame.Draw(spriteBatch, pos);
    }

    public void Play() {
        IsPlaying = true;
        AnimationProgress = 0;
    }

    public void Stop(){

    }
}