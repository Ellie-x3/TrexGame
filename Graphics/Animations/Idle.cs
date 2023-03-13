using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations{

    public class Idle : IAnimation {

        public SpriteBatch spriteBatch { get; }

        public string texture {get; set;}
        public List<Frame> frames { get; set; }
        public List<Frame> GetFrames{ get {return frames;}}
        private readonly IAnimationController _animationController;

        public Idle(SpriteBatch s){
            texture = "Textures\\TrexSpriteSheet";
            spriteBatch = s;
            
            if(Globals.Content == null) 
                throw new NullReferenceException();

            Texture2D text = Globals.Content.Load<Texture2D>(texture);
            frames = new List<Frame>{
                new Frame(new Sprite(text, 848, 0, 44, 52), 0),
                new Frame(new Sprite(text, 848 + 44, 0, 44, 52), 1 / 20f),
                new Frame(new Sprite(text, 848, 0, 44, 52), 1 / 20f * 2)
            };

            _animationController = new AnimationController(this, spriteBatch);
        }

        public void Update(GameTime gt){
            _animationController.Update(gt);
        }

        public void Draw(Vector2 pos){
            _animationController.Draw(pos);
        }
    }
}
