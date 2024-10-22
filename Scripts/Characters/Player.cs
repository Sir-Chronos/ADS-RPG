using Godot;

public partial class Player : CharacterBody2D
{
	const float TileSize = 16;
	Vector2 targetPosition;
	bool isMoving = false;

	[Export] public float walkingSpeed = 100.0f;  // Velocidade de movimento por segundo
	[Export] public float RunningSpeed = 250.0f;

	public override void _Ready()
	{
		targetPosition = GlobalPosition.Snapped(new Vector2(TileSize, TileSize));
	}

	public override void _PhysicsProcess(double delta)
	{
		if (isMoving)
		{
			MoveTowardsTarget(delta);
		}
		else
		{
			GetInputAndMove();
		}
	}

	private void GetInputAndMove()
	{
		Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		if(direction.Y != 0) direction.X = 0;
		if(direction.X != 0) direction.Y = 0;

		if (direction != Vector2.Zero)
		{
			// Calcula a nova posição alvo no grid
			targetPosition = GlobalPosition + direction * TileSize;
			targetPosition = targetPosition.Snapped(new Vector2(TileSize, TileSize));

			isMoving = true;
		}
	}

	private void MoveTowardsTarget(double delta)
	{
		// Move o personagem em direção à posição alvo
		Vector2 velocity = (targetPosition - GlobalPosition).Normalized() * walkingSpeed;
		Velocity = velocity;

		MoveAndSlide();

		// Se o personagem chegou perto o suficiente do alvo, ajuste a posição final
		if (GlobalPosition.DistanceTo(targetPosition) < 1.0f)
		{
			GlobalPosition = targetPosition;
			Velocity = Vector2.Zero;
			isMoving = false;
		}
	}
}
