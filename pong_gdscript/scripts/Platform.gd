extends Area2D

#SPEED variables
const speed : int = 1
var velocity : Vector2 = Vector2.ZERO

#INPUT SETTING
var input_settings : String

#SPRITE
onready var sprite : Sprite = $Sprite

#SCREEN
onready var screen_size : Vector2 = get_viewport().size

func _ready() -> void:
	hide()

func start(pos : Vector2, input_sets : String) -> void:
	position = pos
	input_settings = input_sets
	show()
	
func stabilize_velocity(max_velocity: int) -> void:
	if (velocity.y >= max_velocity):
		velocity.y = max_velocity
	if (velocity.y <= -max_velocity):
		velocity.y = -max_velocity

func wasd_input() -> void:
	if Input.is_action_pressed("w_up"):
		velocity.y -= speed
	
	if Input.is_action_pressed("s_down"):
		velocity.y += speed
	
	stabilize_velocity(2)
	
	position += velocity
	
func arrows_input() -> void:
	if Input.is_action_pressed("ui_up"):
		velocity.y -= speed
	
	if Input.is_action_pressed("ui_down"):
		velocity.y += speed
	
	stabilize_velocity(2)
	
	position += velocity
	
func _physics_process(delta : float) -> void:
	if input_settings == "wasd":
		wasd_input()
	if input_settings == "arrows":
		arrows_input()
		
	position.y = clamp(position.y, 0 - sprite.get_rect().position.y, screen_size.y + sprite.get_rect().position.y)
