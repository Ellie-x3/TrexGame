using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Diagnostics;
using System;

namespace TrexGame.Graphics.Animations;

public class Frame {
    //Sprite
    private Sprite _sprite;
    public bool IsRandom { get; } = false;

    public Sprite SpriteFrame {
        get => _sprite;
        set {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "Sprite cannot be null");
            _sprite = value;
        }
    }

    public float TimeStamp { get; set; }

    public Frame(Sprite s, float t) {
        TimeStamp = t;
        SpriteFrame = s;
    }
}               
