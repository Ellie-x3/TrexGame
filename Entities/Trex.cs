using System.ComponentModel.DataAnnotations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using TrexGame.Graphics.Animations;
using TrexGame.StateMachine;
using System;

namespace TrexGame.Entities {
    internal class Trex : IGameEntity {

        private const float JUMP_VELOCITY = -480f;
        private const float MIN_JUMP = -240f;

        //Properties
        public TrexState state { get; private set; }
        public Vector2 Position { get; set; } = new Vector2(1, 88);
        public bool IsAlive { get; private set; }
        public float Speed { get; private set; }
        public int DrawOrder { get; set; }

        private Animation animation;
        private SoundEffect jumpSfx;
        private Input.InputController input;
        private float verticalVelocity;
        private Vector2 startPosition;

        public Trex(SpriteBatch s, SoundEffect sfx) {
            state = TrexState.Idle;
            startPosition = Position;
            animation = new Animation(s);
            animation.SetAnimation<Idle>();     
            input = new Input.InputController(this);
            jumpSfx = sfx;  
        }

        public void Draw(SpriteBatch spriteBatch) {
            animation.Draw(Position);
        }

        public void Update(GameTime gameTime) {   
            input.ProcessControls(gameTime);  

            animation.Update(gameTime);     
            switch(state){
                case TrexState.Idle:
                    break;
                case TrexState.Falling:
                case TrexState.Jumping:
                    Position = new Vector2(Position.X, Position.Y + verticalVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
                    verticalVelocity += Globals.Gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    
                    if(Position.Y >= startPosition.Y){
                        verticalVelocity = 0;
                        Position = startPosition;
                        state = TrexState.Idle;
                        break;
                    }

                    if(verticalVelocity > 0)
                        state = TrexState.Falling;

                    break;
            }   
            
        }

        public bool BeginJump(){
            if(state == TrexState.Jumping || state == TrexState.Falling)
                return false;

            state = TrexState.Jumping;
            verticalVelocity = JUMP_VELOCITY;
            jumpSfx.Play();
            return true;
        }

        public bool CancelJump(){
            if(state != TrexState.Jumping)
                return false;

            state = TrexState.Falling;
            verticalVelocity = verticalVelocity < MIN_JUMP ? MIN_JUMP : 0;

            return true;
        }
    }
}
