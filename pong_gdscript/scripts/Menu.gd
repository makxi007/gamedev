extends Node2D

func _on_Quit_pressed() -> void:
	get_tree().quit()

func _on_Start_pressed() -> void:
	get_tree().change_scene("res://scenes/MainGame.tscn")

