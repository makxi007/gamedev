extends KinematicBody2D

func _ready() -> void:
	hide()

func start(pos : Vector2) -> void:
	position = pos
	show()
