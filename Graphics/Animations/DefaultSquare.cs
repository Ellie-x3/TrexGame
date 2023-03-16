using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

public class DefaultSquare : AAnimation
{
    public DefaultSquare(SpriteBatch spriteBatch) : base(spriteBatch){
        texture = "Textures\\defaultTexture";
        
        if(Globals.Content == null) 
            throw new NullReferenceException();

        text = Globals.Content.Load<Texture2D>(texture);
        frames = new List<Frame>{
            new Frame(new Sprite(text, 0, 0, 16, 16), 0),
        };
    }
}
