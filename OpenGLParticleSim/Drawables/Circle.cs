﻿using System.Collections;
using OpenTK.Mathematics;

namespace OpenGLParticleSim.Drawables;

public class Circle : DrawableObjectBase
{
    private float _radius;

    private List<ConfigurableShape> _triangles = new();

    public Circle(float radius = 0.5f)
    {
        _radius = radius;
        
        var array = new List<float>();

        for (int i = 0; i <= 360; i+=6)
        {
            float cosine = _radius*(float)Math.Cos(MathHelper.DegreesToRadians(i));
            float sine = _radius*(float)Math.Sin(MathHelper.DegreesToRadians(i));
            
            
            Vector3 vertex1 = Vector3.Zero;
            Vector3 vertex2 = new Vector3(cosine, 0, 0);
            Vector3 vertex3 = new Vector3(cosine, sine, 0);
            
            Console.WriteLine($"Vertex: {vertex1}, Vertex 2: {vertex2}, Vertex 3: {vertex3}");

            
            array.Add(vertex1.X);
            array.Add(vertex1.Y);
            array.Add(vertex1.Z);

            array.Add(vertex2.X);
            array.Add(vertex2.Y);
            array.Add(vertex2.Z);
            
            array.Add(vertex3.X);
            array.Add(vertex3.Y);
            array.Add(vertex3.Z);

            float[] vertexData = array.ToArray();

            ConfigurableShape shape = new ConfigurableShape(vertexData);
            shape.Initialize();
            _triangles.Add(shape);
            array.Clear();
        }
        Console.WriteLine("----------------------------");
    }
    
    
    public override void DrawCall()
    {
        foreach (var triangle in _triangles)
        {
            triangle.DrawCall();
        }
    }

    public override void SetPosition(Vector3 newPosition)
    {
        Position = newPosition;
        foreach (var triangle in _triangles)
        {
            triangle.SetPosition(newPosition);
        }
    }

    public override void SetRotation(Vector3 newRotation)
    {
        throw new NotImplementedException();
    }

    public override void SetScale(Vector3 newScale)
    {
        Scale = newScale;
        foreach (var triangle in _triangles)
        {
            triangle.SetScale(newScale);
        }
    }
}