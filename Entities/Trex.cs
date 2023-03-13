using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using TrexGame.Graphics;
using TrexGame.Graphics.Animations;
using TrexGame.StateMachine;

namespace TrexGame.Entities {
    internal class Trex : IGameEntity {
        private const int TREX_DEFAULT_POSX = 848;
        private const int TREX_DEFAULT_POSY = 0;
        private const int TREX_DEFAULT_WIDTH = 44;
        private const int TREX_DEFAULT_HEIGHT = 52;

        //Properties
        public TrexState state { get; private set; }
        public Vector2 Position { get; set; } = new Vector2(1, 82);
        public bool IsAlive { get; private set; }
        public float Speed { get; private set; }
        public int DrawOrder { get; set; }

        private Animation<Idle> IdleAnimation;

        public Trex(SpriteBatch s, ContentManager c) {
            state = TrexState.Idle;
            
            IdleAnimation = new Animation<Idle>(s, c);        
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (state == TrexState.Idle) {    
                IdleAnimation.Draw(new Vector2(400, 50));
            }
        }

        public void Update(GameTime gameTime) {      
            if (state == TrexState.Idle) {
                IdleAnimation.Update(gameTime);
            }
        }
    }
}
