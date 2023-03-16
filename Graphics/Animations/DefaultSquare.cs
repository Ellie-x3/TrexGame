using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

public class DefaultSquare : IAnimation
{
    public string texture {get; set;}
    public List<Frame> frames { get; set; }
    public List<Frame> GetFrames{ get {return frames;}}
    public int TotalFrames {get {return frames.Count;}}
    Texture2D text;

    public DefaultSquare(){
        texture = "Textures\\defaultTexture";
        
        if(Globals.Content == null) 
            throw new NullReferenceException();

        text = Globals.Content.Load<Texture2D>(texture);
        frames = new List<Frame>{
            new Frame(new Sprite(text, 0, 0, 16, 16), 0),
        };
    }

    public void Update(GameTime gameTime){

    }
}
