using UnityEngine;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, CreateAssetMenu]
public sealed class GameSetup : ScriptableObject
{
	public GameObject playerPrefab;
	public float rotationSpeed = 180f;
	public float playerMovementSpeed = 200f;
	public float laserSpeed = 10f;
	public float asteroidSpeed = 0.5f;
	public GameObject laser;
	public GameObject[] bigAsteroids;
	public GameObject[] mediumAsteroids;
	public GameObject[] smallAsteroids;
	public GameObject[] tinyAsteroids;
}
