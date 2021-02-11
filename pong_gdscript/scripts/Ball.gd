extends KinematicBody2D

const initial_ball_speed : int = 200
var ball_speed : float 
var direction : Vector2 = Vector2.ZERO
const speed_accumulator : int = 50
const max_hit_counter : int = 12
var hit_counter : int = 1

#START BALL POSITION
var start_ball_pos : Vector2

#COLLISION SHAPE OF THE BALL
onready var collision_shape : CollisionShape2D = $CollisionShape2D

func _ready() -> void:
#	collision_shape.set_disabled(true)
	hide()

func start(pos : Vector2) -> void:
	position = pos
	start_ball_pos = pos
	show()
	
	ball_speed = initial_ball_speed
	randomize()
	set_start_direction()
	#collision_shape.disabled = false
	
func start_again() -> void:
	position = start_ball_pos
	randomize()
	set_start_direction()
	
func set_start_direction() -> void:
	var random_x : int = 0

	if (randi()%10 < 5):
		random_x = 1
	else:
		random_x = -1
	direction = Vector2(random_x, rand_range(-1,1))
	direction = direction.normalized() * ball_speed
	
func _physics_process(delta : float) -> void:
	if Input.is_action_pressed("reload_ball_R"):
		start_again()
	
	var collision = move_and_collide(direction * delta)
	if collision != null:
		direction = direction.bounce(collision.normal)
		if collision.collider.is_in_group("platform"):
			var y = direction.y / 2 + collision.collider_velocity.y
		
			direction = Vector2(direction.x, y).normalized() * (ball_speed + hit_counter * speed_accumulator)
			direction = direction.normalized() * ball_speed
		
			if hit_counter < max_hit_counter:
				hit_counter += 1


func _on_Timer_timeout():
	collision_shape.disabled = false
