using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using TrexGame.Graphics.Animations;
using TrexGame.StateMachine;

namespace TrexGame.Entities;

internal class RedGuy{
    private Animation animation;

    public RedGuy(SpriteBatch batch){
        animation = new Animation(batch);
        animation.SetAnimation<DefaultSquare>();
    }

    public void Draw(SpriteBatch batch){
        animation.Draw(new Vector2(100,100));
    }

    public void Update(GameTime gameTime){
        animation.Update(gameTime);
    }
}

