using Godot;

public partial class Player : CharacterBody2D
{
	const float TileSize = 16;
	Vector2 targetPosition;
	bool isMoving = false;

	[Export] public float walkingSpeed = 50.0f;  // Velocidade de movimento por segundo
	[Export] public float RunningSpeed = 250.0f;
	[Export] public AnimationTree animation;

	private AnimationNodeStateMachinePlayback animationState;

	public override void _Ready()
	{
		targetPosition = GlobalPosition.Snapped(new Vector2(TileSize, TileSize));
		animation = GetNode<AnimationTree>("AnimationTree");
		animation.Active = true;
		animationState = (AnimationNodeStateMachinePlayback)animation.Get("parameters/playback");
	}

	public override void _PhysicsProcess(double delta)
	{
		if (isMoving)
		{
			MoveTowardsTarget(delta);
			animationState.Travel("Walk");
		}

		else
		{
			GetInputAndMove();
			if (!isMoving)
			{
                animationState.Travel("Idle");
            }
		}
		}

		private void GetInputAndMove()
		{
			Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
			if (direction.Y != 0) direction.X = 0;
			if (direction.X != 0) direction.Y = 0;

			if (direction != Vector2.Zero)
			{
			// Calcula a nova posição alvo no grid

				animation.Set("parameters/Idle/blend_position", direction);
				animation.Set("parameters/Walk/blend_position", direction);
				targetPosition = GlobalPosition + direction * TileSize;
				targetPosition = targetPosition.Snapped(new Vector2(TileSize, TileSize));

				isMoving = true;
			}
		else
		{
			animationState.Travel("Idle");
		}
		}

		private void MoveTowardsTarget(double delta)
		{
			Vector2 velocity = (targetPosition - GlobalPosition).Normalized() * walkingSpeed;

			// Tenta mover e verifica colisão
			var collision = MoveAndCollide(velocity * (float)delta);
			if (collision != null)
			{
				// Interrompe o movimento em caso de colisão
				isMoving = false;
				return;
			}

			// Se o personagem chegou perto o suficiente do alvo, ajuste a posição final
			if (GlobalPosition.DistanceTo(targetPosition) < 1.0f)
			{
				GlobalPosition = targetPosition;
				isMoving = false;
			}
		}
	}