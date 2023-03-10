using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

public interface IAnimation {
    void Update(GameTime gt);
    void Draw(Vector2 pos);
    void Play();
}

