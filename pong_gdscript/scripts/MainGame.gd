extends Node

#Players(platforms) / ball spawn
onready var first_player : Area2D = $Player1
onready var second_player : Area2D = $Player2
onready var first_pos : Position2D = $FirstPlatformPos
onready var second_pos : Position2D = $SecPlatformPos
onready var ball : KinematicBody2D = $Ball
onready var ball_position : Position2D= $BallPos
onready var first_player_kinematic : KinematicBody2D = $FirstPlatformKinematic
onready var second_player_kinematic : KinematicBody2D = $SecondPlatformKinematic2

#SCORE
onready var first_player_score : Label = $Scores/Player1Score
onready var second_player_score : Label = $Scores/Player2Score

onready var screen_size : Vector2 = get_viewport().size

const ai_speed : int = 100

func empty_count() -> void:
	GLOBAL.first_score = 0
	GLOBAL.second_score = 0

func _ready() -> void:
	first_player_kinematic.start(first_pos.position, "wasd", false)
	second_player_kinematic.start(second_pos.position, "ai", true)
	ball.start(ball_position.position)
	empty_count()

func ai_movement_left(delta : float) -> void:
	#AI movement - left platform
	var ai_pos : Vector2 = second_player_kinematic.position
	#If ball near right platform
	if ball.position.x < screen_size.x / 2:
		if ai_pos.y > screen_size.y/2:
			ai_pos.y += -ai_speed * delta
		if ai_pos.y < screen_size.y/2:
			ai_pos.y += ai_speed * delta
	#If ball near ai (left) platform
	else:
		if ball.position.y > ai_pos.y :
			ai_pos.y += ai_speed * delta
		if ball.position.y < ai_pos.y:
			ai_pos.y += -ai_speed * delta
			
	second_player_kinematic.position = ai_pos

	
func _process(delta : float) -> void:
#	if Input.is_action_pressed("w_up"):
#		GLOBAL.camera.screen_shake(20.0, 0.1)
	ai_movement_left(delta)

	
	
func _on_FirstGoal_body_entered(body) -> void:
	if body.is_in_group("ball"):
		GLOBAL.camera.screen_shake(20.0, 0.1)
		GLOBAL.second_score += 1
		second_player_score.text = str(GLOBAL.second_score)

func _on_SecondGoal_body_entered(body) -> void:
	if body.is_in_group("ball"):
		GLOBAL.camera.screen_shake(20.0, 0.1)
		GLOBAL.first_score += 1
		first_player_score.text = str(GLOBAL.first_score)



