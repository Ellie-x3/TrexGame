using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations{

    public class Idle : AAnimation {
        public Idle(SpriteBatch spriteBatch) : base(spriteBatch){
            texture = "Textures\\TrexSpriteSheet";
            
            if(Globals.Content == null) 
                throw new NullReferenceException();

            text = Globals.Content.Load<Texture2D>(texture);
            frames = new List<Frame>{
                new Frame(new Sprite(text, 848, 0, 44, 52), 0),
                new Frame(new Sprite(text, 848 + 44, 0, 44, 52), 1f),
                new Frame(new Sprite(text, 848, 0, 44, 52), 1f + 1/3f)
            };

            AnimationController controller = AnimationController.GetInstance(this, batch);
            controller.animationCompleted += new EventHandler(UpdateFrames);
        }

        public void UpdateFrames(object sender, EventArgs e){
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

