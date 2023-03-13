using System.Diagnostics;
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

    public Animation(SpriteBatch s, ContentManager c){
        spriteBatch = s;
        animation = (T)Activator.CreateInstance(typeof(T), spriteBatch);
    }

    public void Draw(Vector2 pos) { 
        animation.Draw(pos);
    }

    public void Update(GameTime gt){
        animation.Update(gt);
    }
}