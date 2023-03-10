using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace TrexGame.Entities {
    internal interface IGameEntity {
        int DrawOrder { get; }

        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
