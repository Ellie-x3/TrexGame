using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TrexGame.Entities;
namespace TrexGame.Input;

internal class InputController{

    private Trex _trex;
    private KeyboardState prevKeyboardState;

    public InputController(Trex t){
       _trex = t;
    }

    public void ProcessControls(GameTime gameTime){
        KeyboardState kbState = Keyboard.GetState();
        if(!prevKeyboardState.IsKeyDown(Keys.Up) && kbState.IsKeyDown(Keys.Up)){
            if(_trex.state != StateMachine.TrexState.Jumping)
                 _trex.BeginJump();
            else
                _trex.ContinueJump();
        }
           

        prevKeyboardState = kbState;
    }
}
