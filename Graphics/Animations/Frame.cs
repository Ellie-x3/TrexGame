using System;

namespace TrexGame.Graphics.Animations;

public class Frame {
    //Sprite
    private Sprite _sprite;

    public Sprite SpriteFrame {
        get => _sprite;
        set {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Sprite cannot be null");
            _sprite = value;
        }
    }

    public float TimeStamp { get; } //immutable

    public Frame(Sprite s, float t) {
        TimeStamp = t;
        SpriteFrame = s;
    }
}