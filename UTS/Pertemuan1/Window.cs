//using LearnOpenTK.Common;
//using OpenTK.Graphics.ES11;
//using OpenTK.Graphics.OpenGL4;
//using OpenTK.Windowing.Common;
//using OpenTK.Windowing.Desktop;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ClearBufferMask = OpenTK.Graphics.OpenGL4.ClearBufferMask;
//using GetPName = OpenTK.Graphics.OpenGL4.GetPName;
//using GL = OpenTK.Graphics.OpenGL4.GL;
//using VertexAttribPointerType = OpenTK.Graphics.OpenGL4.VertexAttribPointerType;
using LearnOpenTK.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Pertemuan1
{
    
    static class Constant
    {
        public const string PATH = "E:/My Stuff(s)/UKP/Informatika/Materi/Semester 4/" +
                "Grafika Komputer/Visual Studio/UTS/" +
                "Pertemuan1/Shader/";
    }
    internal class Window : GameWindow
    {
        //Asset2d[] _object = new Asset2d[10];
        //float[] _vertices =
        //{
        //    //x     //y   //z
        //    -0.5f, -0.5f, 0.0f, //vertices 1
        //    0.5f, -0.5f, 0.0f, //vertices 2
        //    0.0f, 0.5f, 0.0f //vertices 3
        //};
        //float[] _vertices =
        //{
        //    //x     //y   //z
        //    -0.75f, 0.0f, 0.0f, //vertices 1
        //    -0.25f, 0.0f, 0.0f, //vertices 2
        //    -0.5f, 0.5f, 0.0f //vertices 3
        //};

        //float[] _vertices =
        //        {
        //            //x     //y   //z
        //            -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f, //vertices 1
        //            0.5f, -0.5f, 0.0f, 0.0f, 1.0f, 0.0f,//vertices 2
        //            0.0f, 0.5f, 0.0f, 0.0f, 0.0f, 1.0f, //vertices 3
        //        };

        //float[] _vertices =
        //{
        //    0.5f, 0.5f, 0.0f, 
        //    0.5f, -0.5f, 0.0f,
        //    -0.5f, -0.5f, 0.0f,
        //    -0.5f, 0.5f, 0.0f
        //};
        //uint[] _indices =
        //{
        //    0,1,3,
        //    1,2,3
        //};
        //int _vertexBufferObject;
        //int _vertexArrayObject;
        //int _elementBufferObject;
        //Shader _shader;
        Asset3d[] _object = new Asset3d[20];
        Asset3d main_head;
        Asset3d cone;
        Asset3d cam = new Asset3d();
        float degree = 0;
        double _time = 0;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        public void makeEyes()
        {
            Asset3d eyes = new Asset3d();

            eyes.createEllipsoid2(0.1f, 0.15f, 0.1f, -0.1f, 0.15f, 0.4f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_head.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f, 0.15f, 0.1f, 0.1f, 0.15f, 0.4f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_head.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, 0.05f, 0.15f, 0.5f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_head.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, -0.05f, 0.15f, 0.5f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_head.addChildClass(eyes);
        }

        public void makeMouth()
        {
            Asset3d cheek = new Asset3d();
            Asset3d smile = new Asset3d();
            Asset3d nose = new Asset3d();
            cheek.createEllipsoid2(0.35f, 0.23f, 0.05f, 0.0f, 0.05f, 0.44f, 300, 100);
            cheek.setColor(new Vector3(255f, 255f, 255f));
            cheek.rotate(main_head._center, main_head._euler[0], 35);

            nose.createEllipsoid2(0.075f, 0.075f, 0.075f, 0.0f, 0.0f, 0.5f, 300, 100);
            nose.setColor(new Vector3(255.0f, 0.0f, 0.0f));

            smile.createHalfBall(0.2f, 0.15f, 0f, 0.0f, -0.1f, 0.5f, 800, 2000);
            smile.setColor(new Vector3(255f, 0f, 0f));
            smile.rotate(main_head._center, main_head._euler[2], 180);
            smile.rotate(main_head._center, main_head._euler[0], 35);
            main_head.addChildClass(smile);
            main_head.addChildClass(cheek);
            main_head.addChildClass(nose);
        }

        public void makeMustache()
        {
            Asset3d mustache;
            //Right Mustache
            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.52f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], 90);
            mustache.rotate(main_head._center, mustache._euler[0], -15);
            main_head.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.5f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], 90);
            main_head.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.5f, -0.12f, 0.15f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], 90);
            mustache.rotate(main_head._center, mustache._euler[0], 15);
            main_head.addChildClass(mustache);

            //Left Mustache
            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.49f, -0.12f, 0.13f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], -90);
            mustache.rotate(main_head._center, mustache._euler[0], 15);
            main_head.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.5f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], -90);
            main_head.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.52f, -0.12f, 0.08f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[1], -90);
            mustache.rotate(main_head._center, mustache._euler[0], -15);
            main_head.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 15f, 0.0014f, 0f, 0.53f, -0.115f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head._center, mustache._euler[0], 110);
            main_head.addChildClass(mustache);
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            ////Background 
            main_head = new Asset3d();
            //main_head.createElipseoid(0.5f, 0.45f, 0.4f, 0.5f, 0.5f, 0.5f);
            main_head.createEllipsoid2(0.5f, 0.45f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            main_head.setColor(new Vector3(255.0f, 255.0f, 0.0f));

            makeEyes();
            makeMouth();
            makeMustache();

            Asset3d ears;
            //right ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, -0.07f, 0f, -0.76f) ;
            ears.rotate(main_head._center, ears._euler[0], 90);
            ears.rotate(main_head._center, ears._euler[1], 15);
            ears.setColor(new Vector3(255.0f, 255.0f, 0.0f));
            main_head.addChildClass(ears);
            //left ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, 0.07f, 0f, -0.76f) ;
            ears.rotate(main_head._center, ears._euler[0], 90);
            ears.rotate(main_head._center, ears._euler[1], -15);
            ears.setColor(new Vector3(255.0f, 255.0f, 0.0f));
            main_head.addChildClass(ears);

            //inner left ear
            ears = new Asset3d();
            ears.EllipPara(0f, 0.021f/1.5f, 0.004f, 0.3193f, -0.1f, -0.58f) ;
            ears.rotate(main_head._center, ears._euler[0], 70);
            ears.rotate(main_head._center, ears._euler[1], -15);
            ears.rotate(main_head._center, ears._euler[2], 90);
            ears.setColor(new Vector3(210, 210, 183));
            main_head.addChildClass(ears);
            //inner left ear
            ears = new Asset3d();
            ears.EllipPara(0f, 0.021f/1.5f, 0.004f, 0.3193f, 0.1f, -0.58f) ;
            ears.rotate(main_head._center, ears._euler[0], 70);
            ears.rotate(main_head._center, ears._euler[1], 15);
            ears.rotate(main_head._center, ears._euler[2], 90);
            ears.setColor(new Vector3(210, 210, 183));
            main_head.addChildClass(ears);
            
            //cone = new Asset3d();
            //cone.createHalfBall(0.5f, 0.5f, 0.5f, -1.0f, 0.0f, 0.5f, 800, 2000);
            //cone.setColor(new Vector3(255, 0, 0));

            main_head.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            //cone.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            //cam.addChildClass(cone);
            cam.addChildClass(main_head);


            GL.GetInteger(GetPName.MaxVertexAttribs, out int maxAttributeCount);
            Console.WriteLine($"Maximum number of vertex attributes supported : {maxAttributeCount}");
            
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            _time += 9.0 * args.Time;
            Matrix4 temp = Matrix4.Identity;
            //temp = temp * Matrix4.CreateRotationZ(degree);
            //temp = temp * Matrix4.CreateTranslation(0.5f, 0.5f, 0f);
            //temp = temp * Matrix4.CreateScale(0.5f);
            //temp = temp * Matrix4.CreateRotationZ((float)MathHelper.DegreesToRadians(_time));
            //temp = temp * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(_time));
            //degree += MathHelper.DegreesToRadians(0.1f);
            //GL.Clear(ClearBufferMask.ColorBufferBit

            //Buat balik framenya, soalnya framenya ada di belakang, jadi kudu dibalik sek
            //_object[0].rotate(_object[0]._center, _object[0]._euler[1], 10);
            //_object[0].Child[0].rotate(_object[0].Child[0]._center, _object[0].Child[0]._euler[1], 10);
            //_object[0].render(0, temp);
            //_object[1].render(3);
            //_object[1].rotate(_object[1]._center, _object[1]._euler[1], 10);

            //_object[7].render(3, temp);
            //_object[7].rotate(_object[7]._center, _object[7]._euler[1], 1);
            //_object[8].render(3, temp);
            //_object[8].rotate(_object[8]._center, _object[8]._euler[1], 1);
            //_object[9].render(3, temp);
            //_object[9].rotate(_object[9]._center, _object[9]._euler[1], 1);
            //_object[10].render(3, temp);
            //_object[10].rotate(_object[10]._center, _object[10]._euler[1], 1);
            //_object[11].render(3, temp);
            //_object[11].rotate(_object[11]._center, _object[11]._euler[1], 1);
            //main_head.rotate(main_head._center, main_head._euler[1], 1);
            //smile.rotate(main_head._center, main_head._euler[2], 180);
            main_head.render(3, temp);
            //cone.rotate(cone._center, cone._euler[1], 1);
            //cone.render(3, temp);
            //main_head.Child[0].rotate(main_head.Child[0]._center, main_head.Child[0]._euler[1], 1);
            //main_head.Child[0].render(3, temp);
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Escape))
            {
                Close();
            }
            if (KeyboardState.IsKeyReleased(OpenTK.Windowing.GraphicsLibraryFramework.Keys.A))
            {
                Console.Write("Hello Glenn \n");
            }
            if (KeyboardState.IsKeyDown(Keys.Up))
            {
                cam.rotate(cam._center, cam._euler[0], -5);
            }
            if (KeyboardState.IsKeyDown(Keys.Down))
            {
                cam.rotate(cam._center, cam._euler[0], 5);
            }
            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                cam.rotate(cam._center, cam._euler[1], -5);
            }
            if (KeyboardState.IsKeyDown(Keys.Right))
            {
                cam.rotate(cam._center, cam._euler[1], 5);
            }
            if (KeyboardState.IsKeyDown(Keys.Q))
            {
                cam.rotate(cam._center, cam._euler[2], -5);
            }
            if (KeyboardState.IsKeyDown(Keys.E))
            {
                cam.rotate(cam._center, cam._euler[2], 5);
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if(e.Button == MouseButton.Left)
            {
                float _x, _y;
                _x = (MousePosition.X - Size.X / 2)/(Size.X/2);
                _y = (MousePosition.Y - Size.Y / 2) / (Size.Y / 2) * -1;

                Console.WriteLine("x = " + _x + " y = " + _y + "\n");
                //_object[3].updateMousePosition(_x, _y, 0);
            }
        }
    }
}
