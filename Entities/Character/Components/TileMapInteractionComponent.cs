using Godot;
using System;
using static Enums;


public partial class TileMapInteractionComponent : RayCast2D
{

	public int CheckTileType(Vector2 position){
		ForceRaycastUpdate();

		int checkedTileType = -1;

		if(ValidatePosition(position)){
			TileMap tilemap = (TileMap)GetCollider();
			TileData td = tilemap.GetCellTileData(0, tilemap.LocalToMap(tilemap.ToLocal((Vector2I)position)));
			checkedTileType = td.GetCustomData("Type").AsInt32();
		}

		return checkedTileType;
	}

	public bool ValidatePosition(Vector2 positionToValidate){
		TargetPosition = positionToValidate;
		ForceRaycastUpdate();
		var r = IsColliding();
		return r;
		// return IsColliding();
	}
	
}

public class TileInfo {
	private string _title_name;
	public string title_name {get {return _title_name;} set{ _title_name = value;} }
	 

}
