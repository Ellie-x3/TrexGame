using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

public abstract class AAnimation : IAnimation{
    public string texture {get; set;}
    public List<Frame> frames { get; set; }
    public List<Frame> GetFrames{ get {return frames;}}
    public int TotalFrames {get {return frames.Count;}}
    public Texture2D text {get;set;}
    public SpriteBatch batch {get;set;}

    public AAnimation(SpriteBatch spriteBatch){
        batch = spriteBatch;
    }
}
