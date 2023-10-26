namespace CatWorld;

using Godot;
using System;

public partial class PlayerCamera : CharacterBody2D
{
    public const float Speed = 60.0f;
    public const float FrictionFactor = 0.9f;
    public float Tan30Degrees = (float)Math.Tan(Mathf.DegToRad(30));

    public override void _PhysicsProcess(double delta)
    {
        Vector2 motion = new(
            Input.GetAxis("left", "right"),
            Input.GetAxis("up", "down")
        );
        // motion.Y *= Tan30Degrees;
        Velocity += motion.Normalized() * Speed;
        Velocity *= FrictionFactor;
        MoveAndSlide();
        // GD.Print(Position);

    }

}
