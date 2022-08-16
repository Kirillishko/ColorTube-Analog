using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSegmentGenerator : MonoBehaviour
{
	public List<GameObject> gameObjects = new List<GameObject>();
	public GameObject template;

	public float OuterRadius = 2;
	public float InnerRadius = 1;
	public float angleDegree = 360;
	public int segments = 45;
	public bool sub1 = true;
	public bool sub2 = true;
	public bool RecalculateNormals = false;
	public bool isUV = true;
	[Range(0, 1)] public int sub1index = 0;
	[Range(0, 1)] public int sub2index = 1;

	public List<int> Triangles = new List<int>();

	private void Awake()
	{
		//GenerateShape(InnerRadius, OuterRadius, angleDegree);
	}

	private void Update()
	{
		//CreateMesh();
		GenerateShape(InnerRadius, OuterRadius, angleDegree);
	}

	[ContextMenu("CreateMesh")]
	public void CreateMesh()
	{
		gameObjects.ForEach(gameObject => Destroy(gameObject));
		gameObjects.Clear();


		int num = (segments * 2 + 2) * 2;
		Vector3[] verticles = new Vector3[num];
		Vector2[] uv = new Vector2[num];
		Vector3[] normals = new Vector3[num];
		List<int> triangles0 = new List<int>();
		List<int> triangles1 = new List<int>();

		float num2 = (float)Mathf.PI / 180f * angleDegree;
		float num3 = num2 / (float)segments;
		float num4 = num2;
		for (int i = 0; i < num; i += 4)
		{
			float num5 = Mathf.Cos(num4);
			float num6 = Mathf.Sin(num4);
			ref Vector3 reference = ref verticles[i];
			reference = new Vector3(OuterRadius * num5, OuterRadius * num6, 0f);
			gameObjects.Add(Instantiate(template, reference, Quaternion.identity));
			ref Vector3 reference2 = ref verticles[i + 1];
			reference2 = new Vector3(InnerRadius * num5, InnerRadius * num6, 0f);
			gameObjects.Add(Instantiate(template, reference2, Quaternion.identity));
			ref Vector3 reference3 = ref verticles[i + 2];
			reference3 = new Vector3(OuterRadius * num5, OuterRadius * num6, 0.25f);
			gameObjects.Add(Instantiate(template, reference3, Quaternion.identity));
			ref Vector3 reference4 = ref verticles[i + 3];
			reference4 = new Vector3(InnerRadius * num5, InnerRadius * num6, 0.25f);
			gameObjects.Add(Instantiate(template, reference4, Quaternion.identity));

			if (RecalculateNormals == false)
			{
				ref Vector3 reference5 = ref normals[i];
				reference5 = new Vector3(0f, 0f, 1f);
				ref Vector3 reference6 = ref normals[i + 1];
				reference6 = new Vector3(0f, 0f, 1f);
				ref Vector3 reference7 = ref normals[i + 2];
				reference7 = new Vector3(0f, 0f, 1f);
				ref Vector3 reference8 = ref normals[i + 3];
				reference8 = new Vector3(0f, 0f, 1f);
			}
			num4 -= num3;
			//StartCoroutine(SetMesh(verticles, triangles0, triangles1, uv, normals, 0));
			//Debug.Break();
		}

		for (int j = 0; j < num - 4; j += 4)
		{
			triangles0.Add(j);
			triangles0.Add(j + 6);
			triangles0.Add(j + 4);
			triangles0.Add(j);
			triangles0.Add(j + 2);
			triangles0.Add(j + 6);
			if (isUV)
			{
				ref Vector2 reference9 = ref uv[j];
				reference9 = new Vector2(0f, 0f);
				ref Vector2 reference10 = ref uv[j + 2];
				reference10 = new Vector2(1f, 0f);
				ref Vector2 reference11 = ref uv[j + 4];
				reference11 = new Vector2(1f, 1f);
				ref Vector2 reference12 = ref uv[j + 6];
				reference12 = new Vector2(0f, 1f);
			}
			triangles1.Add(j + 1);
			triangles1.Add(j + 5);
			triangles1.Add(j + 7);
			triangles1.Add(j + 1);
			triangles1.Add(j + 7);
			triangles1.Add(j + 3);
			if (isUV)
			{
				ref Vector2 reference13 = ref uv[j + 1];
				reference13 = new Vector2(0f, 0f);
				ref Vector2 reference14 = ref uv[j + 3];
				reference14 = new Vector2(1f, 0f);
				ref Vector2 reference15 = ref uv[j + 5];
				reference15 = new Vector2(1f, 1f);
				ref Vector2 reference16 = ref uv[j + 7];
				reference16 = new Vector2(0f, 1f);
			}
			triangles0.Add(j + 3);
			triangles0.Add(j + 7);
			triangles0.Add(j + 6);
			triangles0.Add(j + 3);
			triangles0.Add(j + 6);
			triangles0.Add(j + 2);
			if (isUV)
			{
				ref Vector2 reference17 = ref uv[j + 2];
				reference17 = new Vector2(0f, 0f);
				ref Vector2 reference18 = ref uv[j + 3];
				reference18 = new Vector2(1f, 0f);
				ref Vector2 reference19 = ref uv[j + 6];
				reference19 = new Vector2(1f, 1f);
				ref Vector2 reference20 = ref uv[j + 7];
				reference20 = new Vector2(0f, 1f);
			}
			triangles0.Add(j + 1);
			triangles0.Add(j + 4);
			triangles0.Add(j + 5);
			triangles0.Add(j + 1);
			triangles0.Add(j);
			triangles0.Add(j + 4);
			if (isUV)
			{
				ref Vector2 reference21 = ref uv[j];
				reference21 = new Vector2(0f, 0f);
				ref Vector2 reference22 = ref uv[j + 1];
				reference22 = new Vector2(1f, 0f);
				ref Vector2 reference23 = ref uv[j + 4];
				reference23 = new Vector2(1f, 1f);
				ref Vector2 reference24 = ref uv[j + 5];
				reference24 = new Vector2(0f, 1f);
			}
			if (angleDegree < 360f)
			{
				if (j == 0)
				{
					triangles1.Add(j + 1);
					triangles1.Add(j + 3);
					triangles1.Add(j + 2);
					triangles1.Add(j + 1);
					triangles1.Add(j + 2);
					triangles1.Add(j);
					if (isUV)
					{
						ref Vector2 reference25 = ref uv[j];
						reference25 = new Vector2(0f, 0f);
						ref Vector2 reference26 = ref uv[j + 1];
						reference26 = new Vector2(1f, 0f);
						ref Vector2 reference27 = ref uv[j + 2];
						reference27 = new Vector2(1f, 1f);
						ref Vector2 reference28 = ref uv[j + 3];
						reference28 = new Vector2(0f, 1f);
					}
				}
				if (j == num - 8)
				{
					triangles1.Add(j + 7);
					triangles1.Add(j + 5);
					triangles1.Add(j + 4);
					triangles1.Add(j + 7);
					triangles1.Add(j + 4);
					triangles1.Add(j + 6);
					if (isUV)
					{
						ref Vector2 reference29 = ref uv[j + 4];
						reference29 = new Vector2(0f, 0f);
						ref Vector2 reference30 = ref uv[j + 5];
						reference30 = new Vector2(1f, 0f);
						ref Vector2 reference31 = ref uv[j + 6];
						reference31 = new Vector2(1f, 1f);
						ref Vector2 reference32 = ref uv[j + 7];
						reference32 = new Vector2(0f, 1f);
					}
				}
			}

			//StartCoroutine(SetMesh(verticles, triangles0, triangles1, uv, normals, 1));
			//Debug.Break();
		}

		SetMesh(verticles, triangles0, triangles1, uv, normals, 2);
		//Debug.Break();

		//Mesh mesh = new Mesh();
		//GetComponent<MeshFilter>().mesh = mesh;

		//mesh.subMeshCount = 2;
		//mesh.vertices = verticles;

		//List<int> trianglesBoth = new List<int>();
		//trianglesBoth.AddRange(triangles0);
		//trianglesBoth.AddRange(triangles1);

		//if (sub1) mesh.SetTriangles(triangles0.ToArray(), sub1index);
		//if (sub2) mesh.SetTriangles(triangles1.ToArray(), sub2index);

		//if (isUV)
		//{
		//	mesh.uv = uv;
		//}

		//if (RecalculateNormals)
		//	mesh.RecalculateNormals();
		//else mesh.normals = normals;
	}


	public void Generate()
	{
		gameObjects.ForEach(gameObject => Destroy(gameObject));
		gameObjects.Clear();


		int num = (segments * 2 + 2) * 2;
		Vector3[] verticles = new Vector3[num];
		Vector2[] uv = new Vector2[num];
		Vector3[] normals = new Vector3[num];
		List<int> triangles0 = new List<int>();
		List<int> triangles1 = new List<int>();

		float num2 = (float)Mathf.PI / 180f * angleDegree;
		float num3 = num2 / (float)segments;
		float num4 = num2;

		//for (int i = 0; i < 2; i++)
		//      {
		//	GenerateShape
		//      }
	}

	private void GenerateShape(float innerRadius, float outerRadius, float angleDegree)
	{
		List<Vector3> verticles = new List<Vector3>();
		List<int> triangles = new List<int>();

		angleDegree *= Mathf.Deg2Rad;
		float cos = Mathf.Cos(angleDegree);
		float sin = Mathf.Sin(angleDegree);

		//GameObject temp;

		verticles.Add(new Vector3(innerRadius * cos, innerRadius * sin, 0.5f));
		//temp = Instantiate(template, verticles[0], Quaternion.identity);
		//temp.transform.localScale *= 1.1f;
		//temp.name = "0";

		verticles.Add(new Vector3(innerRadius * cos, innerRadius * sin, 0));
		//temp = Instantiate(template, verticles[1], Quaternion.identity);
		//temp.transform.localScale *= 1.3f;
		//temp.name = "1";

		verticles.Add(new Vector3(outerRadius * cos, outerRadius * sin, 0.5f));
		//temp = Instantiate(template, verticles[2], Quaternion.identity);
		//temp.transform.localScale *= 1.5f;
		//temp.name = "2";

		verticles.Add(new Vector3(outerRadius * cos, outerRadius * sin, 0));
		//temp = Instantiate(template, verticles[3], Quaternion.identity);
		//temp.transform.localScale *= 1.7f;
		//temp.name = "3";

		// for
		// 2, 1, 0,
		// 1, 2, 3
		triangles.Add(0);
		triangles.Add(1);
		triangles.Add(2);
		triangles.Add(2);
		triangles.Add(3);
		triangles.Add(1);

		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

		mesh.vertices = verticles.ToArray();
		mesh.triangles = Triangles.ToArray();

		mesh.RecalculateNormals();
	}

	private void SetMesh(Vector3[] verticles, List<int> triangles0, List<int> triangles1, Vector2[] uv, Vector3[] normals, int debug)
	{
		Mesh mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

		mesh.subMeshCount = 2;
		mesh.vertices = verticles;

		//List<int> trianglesBoth = new List<int>();
		//trianglesBoth.AddRange(triangles0);
		//trianglesBoth.AddRange(triangles1);

		if (sub1) mesh.SetTriangles(triangles0.ToArray(), sub1index);
		if (sub2) mesh.SetTriangles(triangles1.ToArray(), sub2index);

		if (isUV)
		{
			mesh.uv = uv;
		}

		if (RecalculateNormals)
			mesh.RecalculateNormals();
		else mesh.normals = normals;
	}
}
