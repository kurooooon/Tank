using UnityEngine;
using System.Collections;

/// <summary>
/// Terrain controller.
/// </summary>
public class TerrainController : MonoBehaviour {

//	private GameObject _terrain;
//	private Terrain _terrainParam;
	private float[,] _origin;
	private float[,] _heights;

	// Use this for initialization
	void Start () {
//		_terrain = GameObject.Find(GameConfig.CODE_TERRAIN);
//		_terrainParam = gameObject.GetComponent<Terrain> ();
//
//		TerrainData terrainData = _terrainParam.terrainData;
//		Debug.Log("terrain info width=" + terrainData.heightmapWidth + ", height=" + terrainData.heightmapHeight);
//		_heights = terrainData.GetHeights(0, 0, terrainData.heightmapWidth, terrainData.heightmapHeight); // 高さマップ
		Terrain terrain = gameObject.GetComponent<Terrain>();
		int w = terrain.terrainData.heightmapWidth;
		int h = terrain.terrainData.heightmapHeight;
		_origin = terrain.terrainData.GetHeights(0, 0, w, h);;
		_heights = terrain.terrainData.GetHeights(0, 0, w, h); // 高さマップ
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {

		if (col.gameObject.tag == GameConfig.TAG_BULLET) {
//			// 穴を掘る
//			TerrainData data = _terrainParam.terrainData;
//			int radius = 5; // 穴の半径
//			float depth = 0.002f; // 穴の深さ
//			int w = data.heightmapWidth;
//			int h = data.heightmapHeight;
//			int mapX = (int)(col.contacts [0].point.z * w / data.size.x); // heightmap 上の座標
//			int mapZ = (int)(col.contacts [0].point.x * h / data.size.z); // heightmap 上の座標
//			int mapR = (int)(radius * w / data.size.z); // heightmap 上の座標
//			// z -> x
//			int z1 = (int)Mathf.Max (-mapR, -mapZ);
//			int z2 = (int)Mathf.Min (mapR, -mapZ + h - 1);
//			for (int z = z1; z <= z2; ++z) {
//				// x -> y
//				int mapW = (int)Mathf.Sqrt (mapR * mapR - z * z);
//				int x1 = (int)Mathf.Max (-mapW, -mapX);
//				int x2 = (int)Mathf.Min (mapW, -mapX + w - 1);
//				for (int x = x1; x <= x2; ++x) {
//					_heights [x + mapX, z + mapZ] = Mathf.Max (0, _heights [x + mapX, z + mapZ] - depth * Mathf.Sqrt (mapW * mapW - x * x));
//					Debug.Log (_heights [x + mapX, z + mapZ]);
//				}
//			}
//			data.SetHeights (0, 0, _heights);
//
//			Debug.Log (_heights);

			// 穴を掘る
			Terrain terrain = gameObject.GetComponent<Terrain>();
			int R = 5; // 穴の半径
			float D = 0.0002f; // 穴の深さ
			int w = terrain.terrainData.heightmapWidth;
			int h = terrain.terrainData.heightmapHeight;
			int mapX = (int) (col.contacts[0].point.z * w / terrain.terrainData.size.x); // heightmap 上の座標
			int mapZ = (int) (col.contacts[0].point.x * h / terrain.terrainData.size.z); // heightmap 上の座標
				int mapR = (int) (R * w / terrain.terrainData.size.z); // heightmap 上の座標
			// z -> x
			int z1 = Mathf.Max(-mapR, -mapZ);
			int z2 = Mathf.Min(mapR, -mapZ + h - 1);
			for (int z = z1; z <= z2; ++ z) {
				// x -> y
				int mapW = (int) Mathf.Sqrt(mapR * mapR - z * z);
				int x1 = Mathf.Max(-mapW, -mapX);
				int x2 = Mathf.Min(mapW, -mapX + w - 1);
				for (int x = x1; x <= x2; ++ x) {
					_heights[x + mapX, z + mapZ] = Mathf.Max(0, _heights[x + mapX, z + mapZ] - D * Mathf.Sqrt(mapW * mapW - x * x));
				}
			}
			terrain.terrainData.SetHeights(0, 0, _heights);
			// ヒット。
//			for (var cannon: GameObject in [player, other]) {
//				if ((cannon.transform.position - collision.transform.position).magnitude
//					< cannon.transform.FindChild("Sphere").transform.localScale.x / 2 + R) {
//					cannon.GetComponent(cannonScript).Hit();
//				}
//			}
		}
	}

	void OnApplicationQuit () {
		Terrain terrain = gameObject.GetComponent<Terrain>();
		terrain.terrainData.SetHeights(0, 0, _origin); // 変更前の高さマップ
	}
}
