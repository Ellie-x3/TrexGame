using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

public interface IAnimation {
    string texture {get; set;}
    List<Frame> frames { get; set; }
    List<Frame> GetFrames{ get {return frames;}}
    int TotalFrames {get {return frames.Count;}}
    void Update(GameTime gameTime);
}

