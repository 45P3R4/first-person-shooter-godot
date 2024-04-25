using Godot;

public partial class Camera : Camera3D
{
	[Export]
	float sensetiveX = 0.005f;

	[Export]
	float sensetiveY = 0.005f;

	Vector3 camRotation;
	Node3D arms;
	Vector3 armsOrigin;

	Vector3 rot = Vector3.Zero;

	float deltaElapsed = 0;

	float motionY = 0;
	float motionX = 0;
	
	public override void _Ready()
	{
		arms = GetNode<Node3D>("Arms");
		armsOrigin = arms.Position;
		camRotation = Rotation;
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion) {
			InputEventMouseMotion mouseMotion = @event as InputEventMouseMotion;
			motionX = mouseMotion.Relative.X;
			motionY = mouseMotion.Relative.Y;
			Player.Body.RotateY(-motionX * sensetiveX);
			RotateX(motionY * sensetiveY);
			camRotation.X = Mathf.Clamp(Rotation.X, Mathf.DegToRad(-90), Mathf.DegToRad(90));
			Rotation = camRotation;
			sway(motionX, motionY);
		}
	}

	//hands rotation
    public override void _Process(double delta)
    {
		
		arms.Rotation = arms.Rotation.Lerp(Vector3.Zero, (float)delta * 5);
		arms.Position = arms.Position.Lerp(armsOrigin, (float)delta * 5);
		
		arms.Position += new Vector3(
			Mathf.Clamp(Player.Body.Velocity.X*0.001f, -0.0005f, 0.01f),
			0,
			0);
    }

	private void sway(float swayX, float swayY) {
		GD.Print(swayY);
		swayY = Mathf.Clamp(swayY, -7, 7);
		swayX = Mathf.Clamp(swayX, -7, 7);
		arms.Rotation += new Vector3(swayY * 0.001f, 0, swayX * 0.001f);
		arms.Position += new Vector3(swayY * 0.0005f, 0, swayX * 0.0005f);
	}
}