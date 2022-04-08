using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pertemuan1
{
    internal class Asset2d
    {
        float[] _vertices =
        {
            //x     //y   //z
            //vertices 1
            //vertices 2
            //vertices 3
        };
        uint[] _indices =
        {
            
        };
        int _vertexBufferObject;
        int _vertexArrayObject;
        int _elementBufferObject;
        Shader _shader;

        int index;
        int[] _pascal = { };
        public Asset2d(float[] vertices, uint[] indices)
        {
            _vertices = vertices;
            _indices = indices;
        }
        public Asset2d()
        {
            _vertices = new float[1080];
            index = 0;
        }

        public void load(string shaderVert, string shaderFrag)
        {
            //Background color changing
            GL.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            // If object has different setting(s)


            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            //0 referensi dari param pertama di vertex attrib
            GL.EnableVertexAttribArray(0);

            if(_indices.Length != 0)
            {
                _elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length
                    * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
            }
            //_shader = new Shader("E:/My Stuff(s)/UKP/Informatika/Materi/Semester 4/" +
            //    "Grafika Komputer/Visual Studio/Pertemuan4/" +
            //    "Pertemuan1/Shader/shader.vert",
            //    "E:/My Stuff(s)/UKP/Informatika/Materi/Semester 4/" +
            //    "Grafika Komputer/Visual Studio/Pertemuan4/" +
            //    "Pertemuan1/Shader/shader.frag");
            _shader = new Shader(shaderVert, shaderFrag);
            _shader.Use();
        }

        public void render(int _lines)
        {
            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);
            if (_indices.Length != 0)
            {
                GL.DrawElements(OpenTK.Graphics.OpenGL4.PrimitiveType.Triangles, _indices.Length, OpenTK.Graphics.OpenGL4.DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                if (_lines == 0)
                {
                    GL.DrawArrays(OpenTK.Graphics.OpenGL4.PrimitiveType.TriangleFan, 0, 3);
                }
                else if (_lines == 1)
                {
                    GL.DrawArrays(OpenTK.Graphics.OpenGL4.PrimitiveType.TriangleFan, 0,(_vertices.Length + 1) / 3);
                }
                else if (_lines == 2)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, index);
                }
                else if (_lines == 3)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, (_vertices.Length + 1) / 3);
                }
            }
        }

        public void createCircle(float center_x, float center_y, float radius)
        {
            _vertices = new float[1080];
            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * Math.PI / 180;
                //x
                _vertices[i * 3] = radius * (float)Math.Cos(degInRad) + center_x;
                //y
                _vertices[i * 3 + 1] = radius * (float)Math.Sin(degInRad) + center_y;
                //z
                _vertices[i * 3 + 2] = 0; 
            }
        } public void createElipse(float center_x, float center_y, float radius_x,float radius_y)
        {
            _vertices = new float[1080];
            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * Math.PI / 180;
                //x
                _vertices[i * 3] = radius_x * (float)Math.Cos(degInRad) + center_x;
                //y
                _vertices[i * 3 + 1] = radius_y * (float)Math.Sin(degInRad) + center_y;
                //z
                _vertices[i * 3 + 2] = 0; 
            }
        }
        //public void updateMousePosition(float x, float y, float z)
        //{
        //    _vertices[index * 3] = x;
        //   _vertices[index * 3 + 1] = y;
        //   _vertices[index * 3 + 2] = z;
        //    index++;

        //    GL.BufferData(BufferTarget.ArrayBuffer, index * 3 * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
        //    GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        //}
        public void updateMousePosition(float x, float y, float z)
        {
            _vertices[index * 3] = x;
           _vertices[index * 3 + 1] = y;
           _vertices[index * 3 + 2] = z;
            index++;

            GL.BufferData(BufferTarget.ArrayBuffer, index * 3 * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }
        public List<int> getRow(int row_index)
        {
            List<int> current_row = new List<int>();
            current_row.Add(1);
            if(row_index == 0)
            {
                return current_row;
            }
            List<int> prev = getRow(row_index - 1);
            for(int i = 1;i<prev.Count;i++)
            {
                int curr = prev[i - 1] + prev[i];
                current_row.Add(curr);
            }
            current_row.Add(1);
            return current_row;
        }

        public List<float> CreateCurveBezier()
        {
            List<float> _vertices_bezier = new List<float>();
            List<int> pascal = getRow(index - 1);
            _pascal = pascal.ToArray();
            for (float t = 0; t <= 1.0f; t += 0.01f)
            {
                Vector2 p = getP(index, t);
                _vertices_bezier.Add(p.X);
                _vertices_bezier.Add(p.Y);
                _vertices_bezier.Add(0);
            }
            return _vertices_bezier;
        }
        public Vector2 getP (int n, float t)
        {
            Vector2 p = new Vector2(0, 0);
            float [] k = new float[n];
            for (int i = 0; i < n; i++)
            {
                k[i] = (float)Math.Pow((1 - t), n - 1 - i) * (float)Math.Pow(t,i) * _pascal[i];
                p.X += k[i] * _vertices[i * 3];
                p.Y += k[i] * _vertices[i * 3 + 1];
            }
            return p;
        }

        public bool getVerticesLength()
        {
            if (_vertices[0] == 0)
            {
                return false;
            } 
            if ((_vertices.Length + 1 / 3) > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public void setVertices(float[] vertices)
        {
            _vertices = vertices;
        }
    }
}
