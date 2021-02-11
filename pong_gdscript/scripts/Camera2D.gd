extends Camera2D

var screen_shake_start : bool = false
var screen_shake_intensity : float = 0

func _ready() -> void:
	GLOBAL.camera = self
	
func _exit_tree() -> void:
	GLOBAL.camera = null
	
func _process(delta : float) -> void:
	zoom = lerp(zoom, Vector2(1, 1), 0.15)
	if screen_shake_start == true:
		global_position += Vector2(rand_range(-screen_shake_intensity, screen_shake_intensity), rand_range(-screen_shake_intensity, screen_shake_intensity)) * delta

func screen_shake(intensity : float, time : float) -> void:
	zoom = Vector2(1,1) - Vector2(intensity*0.002, intensity*0.002)
	screen_shake_intensity = intensity
	$Timer.wait_time = time
	$Timer.start()
	screen_shake_start = true
	
func _on_Timer_timeout() -> void:
	screen_shake_start = false
	global_position = Vector2(512, 300)
