using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ProceduralWorldGenerator : MonoBehaviour {

	public int width;
	public int height;

	public string seed;
	public bool useRandomSeed;

	[Range(0, 100)]
	public int randomFillPercent;

	int[,] map;

	void Start() {
		GenerateMap ();
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			print ("Pressed left click.");
			GenerateMap ();
		}
	}

	void GenerateMap() {
		map = new int[width, height];
		RandomFillMap();

		for (int i = 0; i < 5; i++) {
			SmoothMap ();
		}

		ProcessMap ();

		int borderSize = 5;
		int[,] borderedMap = new int[width + borderSize * 2, height + borderSize * 2];

		for (int x = 0; x < borderedMap.GetLength (0); x++) {
			for (int y = 0; y < borderedMap.GetLength (1); y++) {
				if (x >= borderSize && x < width + borderSize && y >= borderSize && y < height + borderSize) {
					borderedMap [x, y] = map [x - borderSize, y - borderSize];
				}
				else {
					borderedMap [x, y] = 1;
				}
			}
		}

		MeshGenerator meshGen = GetComponent<MeshGenerator> ();
		meshGen.GenerateMesh (map, 1);
	}

	void ProcessMap () {
		List<List<Coord>> roomRegions = GetRegions (0);
		int roomThresholdSize = 75;
		foreach(List<Coord> roomRegion in roomRegions) {
			if (roomRegion.Count < roomThresholdSize) {
				foreach (Coord tile in roomRegion) {
					map [tile.tileX, tile.tileY] = 1;
				}
			}
		}

		List<List<Coord>> wallRegions = GetRegions (1);
		int wallThresholdSize = 50;
		foreach(List<Coord> wallRegion in wallRegions) {
			if (wallRegion.Count < wallThresholdSize) {
				foreach (Coord tile in wallRegion) {
					map [tile.tileX, tile.tileY] = 0;
				}
			}
		}

	}

	List<List<Coord>> GetRegions (int tileType) {
		List<List<Coord>> regions = new List<List<Coord>> ();
		int[,] mapFlags = new int[width, height];

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				if (mapFlags[x,y] == 0 && map[x,y] == tileType) {
					List<Coord> newRegion = GetRegionTiles (x, y);
					regions.Add (newRegion);
					foreach (Coord tile in newRegion) {
						mapFlags [tile.tileX, tile.tileY] = 1;
					}
				}
			}
		}

		return regions;
	}

	List<Coord> GetRegionTiles(int startX, int startY) {
		List<Coord> tiles = new List<Coord> ();
		int[,] mapFlags = new int[width,height];
		int tileType = map[startX,startY];

		Queue<Coord> queue = new Queue<Coord> ();
		queue.Enqueue(new Coord(startX, startY));
		mapFlags[startX, startY] = 1;

		while (queue.Count > 0 ) {
			Coord tile = queue.Dequeue();
			tiles.Add(tile);

			for (int x = tile.tileX - 1; x <= tile.tileX + 1; x++) {
				for (int y = tile.tileY - 1; y <= tile.tileY + 1; y++) {
					if (IsInMapRange(x, y) && (x == tile.tileX ||y == tile.tileY)) {
						if (mapFlags[x,y] == 0 && map[x,y] == tileType) {
							mapFlags[x,y] = 1;
							queue.Enqueue(new Coord(x,y));
						}
					}
				}
			}
		}

		return tiles;
	}

	bool IsInMapRange(int x, int y) {
		return x >= 0 && x < width && y >= 0 && y < height;
	}

	void RandomFillMap() { 
		if (useRandomSeed) {
			seed = DateTime.Now.TimeOfDay.ToString();
			print (seed);
		}

		System.Random pseudoRandom = new System.Random(seed.GetHashCode());

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				if (x == 0 || x == width-1 || y == 0 || y == height-1) {
					map [x, y] = 1;
				}
				else {
					map [x, y] = pseudoRandom.Next(0, 100) < randomFillPercent ? 1 : 0;
				}
			}
		}
	}

	// how many neightboring tiles are walls?
	void SmoothMap() {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				int neighborWallTiles = GetSuroundingWallCount (x, y);

				if (neighborWallTiles > 4) {
					map [x, y] = 1;
				}
				else {
					map [x, y] = 0;
				}
			}
		}
	}

	int GetSuroundingWallCount(int gridX, int gridY) {
		int wallCount = 0;
		for (int neighborX = gridX - 1; neighborX <= gridX + 1; neighborX++) {
			for (int neighborY = gridY - 1; neighborY <= gridY + 1; neighborY++) {
				if (IsInMapRange(neighborX, neighborY)) {
					if (neighborX != gridX || neighborY != gridY) {
						wallCount += map [neighborX, neighborY];
					}
				}
				else {
					wallCount++;
				}
			}
		}

		return wallCount;
	}

	struct Coord {
		public int tileX;
		public int tileY;

		public Coord(int x, int y) {
			tileX = x;
			tileY = y;
		}
	}

	void OnDrawGizmos() {
		/*
		if (map != null) {
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
					Vector3 pos = new Vector3 (-width / 2 + x + .5f, -height / 2 + y + .5f, 0);
					Gizmos.DrawCube (pos, Vector3.one);
				}
			}
		}
		*/
	}
}
