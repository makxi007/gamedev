extends Node

#Players(platforms) / ball spawn
onready var first_player : Area2D = $Player1
onready var second_player : Area2D = $Player2
onready var first_pos : Position2D = $FirstPlatformPos
onready var second_pos : Position2D = $SecPlatformPos
onready var ball : KinematicBody2D = $Ball
onready var ball_position : Position2D= $BallPos

func _ready() -> void:
	first_player.start(first_pos.position, "wasd")
	second_player.start(second_pos.position, "arrows")
	ball.start(ball_position.position)
	pass
