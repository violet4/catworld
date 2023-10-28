namespace CatWorld;

using Godot;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public partial class PlayerCamera : CharacterBody2D {
    private Label PlayerPositionLabel;
    public const float Speed = 60.0f;
    public const float FrictionFactor = 0.9f;
    public float Tan30Degrees = (float)Math.Tan(Mathf.DegToRad(30));
    private Node2D parent;

    [JsonPropertyName("X")]
    public float X {get {return Position.X;} set {Position = new(value, Position.Y);}}
    [JsonPropertyName("Y")]
    public float Y {get {return Position.Y;} set {Position = new(Position.X, value);}}

    public override void _Ready() {
        PlayerPositionLabel = (Label)GetNode("PlayerPositionLabel");
        parent = (Node2D)GetParent();
    }
    public override void _Process(double delta) {
        // if (!parent.Visible) return;
    }
    public override void _PhysicsProcess(double delta) {
        if (!parent.Visible) return;
        Vector2 motion = new(
            Input.GetAxis("left", "right"),
            Input.GetAxis("up", "down")
        );
        // motion.Y *= Tan30Degrees;
        Velocity += motion.Normalized() * Speed;
        if (Input.IsActionPressed("run")) {
            Velocity *= new Vector2(1.1f,1.1f);
        }
        Velocity *= FrictionFactor;
        MoveAndSlide();
        PlayerPositionLabel.Text = Position.X+", "+Position.Y+", running: "+Input.IsActionPressed("run");
        // GD.Print(Position);

    }

}
