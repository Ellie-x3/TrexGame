using System.ComponentModel;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrexGame.Graphics.Animations;

public class Animation {
    public SpriteBatch spriteBatch { get; }
    private Dictionary<Type, IAnimation> animations = new Dictionary<Type, IAnimation>();
    public IAnimation animation { get; private set; }
    private AnimationController animationController;

    public Animation(SpriteBatch s) {
        spriteBatch = s;
        animation = GetAnimation<DefaultSquare>();
    }

    public void Draw(Vector2 pos) {
        animationController.Draw(pos);
    }

    public void Update(GameTime gt) {
        animationController.Update(gt);
    }

    public T GetAnimation<T>() where T : class, IAnimation {
        Type type = typeof(T);

        if (animations.ContainsKey(type))
            return animations[type] as T;

        T anim = (T)Activator.CreateInstance(typeof(T), spriteBatch);
        animations.Add(type, anim);

        animationController = AnimationController.GetInstance(anim, spriteBatch);
        return anim;
    }

    public IAnimation SetAnimation<T>() where T : class, IAnimation {
        Type t = typeof(T);
        animation = GetAnimation<T>();
        
        if(animationController.animation == animation)
            return animation;

        Console.WriteLine("Setting Animation");
        animationController.Clear();
        animationController.animation = animation;
        animationController.Play();
        return animation;
    }
}
