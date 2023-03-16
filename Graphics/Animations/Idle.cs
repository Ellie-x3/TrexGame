using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations{

    public class Idle : IAnimation {
        public string texture {get; set;}
        public List<Frame> frames { get; set; }
        public List<Frame> GetFrames{ get {return frames;}}
        public int TotalFrames {get {return frames.Count;}}
        Texture2D text;

        public Idle(){
            texture = "Textures\\TrexSpriteSheet";
            
            if(Globals.Content == null) 
                throw new NullReferenceException();

            text = Globals.Content.Load<Texture2D>(texture);
            frames = new List<Frame>{
                new Frame(new Sprite(text, 848, 0, 44, 52), 0),
                new Frame(new Sprite(text, 848 + 44, 0, 44, 52), 1f),
                new Frame(new Sprite(text, 848, 0, 44, 52), 1f + 1/3f)
            };
        }

        public void Update(GameTime gt){
            Random random = new Random();
            float randomTimeStamp = this.TotalFrames + (float)random.NextDouble() * (10f - this.TotalFrames);
            frames = new List<Frame>{
              new Frame(new Sprite(text, 848, 0, 44, 52), 0),
              new Frame(new Sprite(text, 848+44,0,44,52), randomTimeStamp),
              new Frame(new Sprite(text, 848,0,44,52), randomTimeStamp + 1/3f)
            };
        }
    }
}

