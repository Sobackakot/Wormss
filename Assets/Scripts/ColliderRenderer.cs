using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class ColliderRenderer : MonoBehaviour
{
    [SerializeField] PolygonCollider2D _collider;
    [SerializeField] MeshFilter _meshFilter;
    [SerializeField] MeshFilter _backMesh;


    private void Update()
    {
        if (transform.hasChanged)
        {
            CreateMesh();
        }
    }

    private void OnValidate()
    {
        var mesh = CreateMesh();
        if (_backMesh)
            _backMesh.mesh = mesh;
    }
    private void OnDrawGizmos()
    {
        for (int p = 0; p < _collider.pathCount; p++)
        {
            for (int i = 0; i < _collider.GetPath(p).Length; i++)
            {
                Handles.Label(_collider.transform.TransformPoint(_collider.GetPath(p)[i]), i.ToString());
            }
        }
    }
    public Mesh CreateMesh()
    {
        Mesh mesh = _collider.CreateMesh(true, true);
        _meshFilter.mesh = mesh;
        return mesh;
    }

}
