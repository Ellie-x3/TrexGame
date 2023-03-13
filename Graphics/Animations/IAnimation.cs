using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

public interface IAnimation {
    string texture {get; set;}
    List<Frame> frames { get; set; }
    List<Frame> GetFrames{ get {return frames;}}
    SpriteBatch spriteBatch { get; }

    void Update(GameTime gt);
    void Draw(Vector2 pos);
}

