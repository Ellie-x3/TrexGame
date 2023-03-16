using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
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

        private Animation animation;
        private SoundEffect jumpSfx;
        private Input.InputController input;

        public Trex(SpriteBatch s, SoundEffect sfx) {
            state = TrexState.Idle;
            Position = new Vector2(1,88);
            animation = new Animation(s);
           // animation.SetAnimation<Idle>();     
            input = new Input.InputController(this);
            jumpSfx = sfx;  
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (state == TrexState.Idle) {  
                  animation.Draw(Position);
            }
        }

        public void Update(GameTime gameTime) {   
            input.ProcessControls(gameTime);  

            if (state == TrexState.Idle) {
                animation.Update(gameTime);        
            }
        }

        public bool BeginJump(){
            if(state == TrexState.Jumping || state == TrexState.Falling)
                return false;

            animation.SetAnimation<Idle>();
            jumpSfx.Play();
            return true;
        }

        public bool ContinueJump(){
            return true;
        }
    }
}
