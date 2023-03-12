using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

public class Idle : IAnimation {

    public string texture {get; set;}
    public List<Frame> frames { get; set; }
    public List<Frame> GetFrames{ get {return frames;}}
    public List<int> test {get; set;}

    public Idle(){
        texture = "Textures\\TrexSpriteSheet";
        if(Globals.Content == null)
            throw new NullReferenceException();

        Texture2D text = Globals.Content.Load<Texture2D>(texture);
        frames = new List<Frame>();
        frames.Add(new Frame(new Sprite(text, 848, 0, 44, 52), 0));
            
    }
}