using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

public class Animation {
    //Constructor

    //List Frames
    private List<Frame> _frames = new List<Frame>();

    //Bool IsPlaying private
    public bool IsPlaying { get; private set; }

    //Float AnimationProgress private setter
    public float AnimationProgress { get; private set; }

    //Looping
    public bool Loop { get; set; } = true;

    //Get current frame
    public Frame CurrentFrame {
        get {
            return _frames
                .Where(f => f.TimeStamp <= AnimationProgress)
                .MaxBy(f => f.TimeStamp);
        }
    }

    //Get total frames
    public int TotalFrames {
        get {
            return _frames.Count - 1;
        }
    }

    public float Duration {
        get {
            if (!_frames.Any())
                return 0;
            return _frames.Max(f => f.TimeStamp);
        }
    }

    //AddFrame(sprite, timestamp)
    public void AddFrame(Sprite s, float t) {
         Frame frame = new Frame(s, t);
        _frames.Add(frame);
    }

    //Update Method
    public void Update(GameTime gt) {
        if (!IsPlaying)
            return;

        AnimationProgress += (float)gt.ElapsedGameTime.TotalSeconds;

        if (AnimationProgress > Duration)
            if(Loop)
                AnimationProgress -= Duration;
            else Stop();   
            
    }

    public void Draw(SpriteBatch s, Vector2 pos) {
        Frame frame = CurrentFrame;

        if (frame != null)
            frame.SpriteFrame.Draw(s, pos);
    }

    //Play Method
    public void Play() {
        IsPlaying = true;
    }

    //Stop Method
    public void Stop() {
        IsPlaying = false;
        AnimationProgress = 0f;
    }

    //GetFrame(Frame) [Indexer]
    public Frame this[int i] {
        get => GetFrame(i);
    }

    public Frame GetFrame(int i) {
        if (i < 0 || i >= _frames.Count) {
            throw new ArgumentOutOfRangeException(nameof(i), "Index is out of range in the current animation");
        }

        return _frames[i];
    }
}