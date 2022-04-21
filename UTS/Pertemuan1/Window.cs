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
        Asset3d[] _object3d = new Asset3d[20];
        Asset3d body;
        Asset3d main_head;
        Asset3d cone;
        Asset3d right_hand;
        Asset3d left_hand;
        Asset3d right_foot;
        Asset3d left_foot;
        Asset3d cam = new Asset3d();
        Asset3d cape;
        Camera _camera;
        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0.0f, 0.0f, 0.0f);
        float _rotationSpeed = 1;

        Asset3d pawaemon = new Asset3d();
        float degree = 0;
        double _time = 0;
        
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        public void makeBody()
        {
            //Ganti Background
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            _object3d[0] = new Asset3d();
            body = new Asset3d();

            //Cape
            cape = new Asset3d();
            cape.EllipCone2(0.1f, 0.15f, 0.28f, 0f, -0.4f, 0.0f);
            cape.setColor(new Vector3(44, 87, 91));
            cape.rotate(cape._center, cape._euler[1], 90);
            body.addChildClass(cape);

            //Circle for cape
            cape = new Asset3d();
            cape.createEllipsoid2(0, 0.21f, 0.14f, -0.4f, -0.4f, 0.0f, 300, 100);
            cape.setColor(new Vector3(44, 87, 91));
            body.addChildClass(cape);

            //Circle for cape
            cape = new Asset3d();
            cape.createEllipsoid2(0, 0.21f, 0.14f, 0.4f, -0.4f, 0.0f, 300, 100);
            cape.setColor(new Vector3(44, 87, 91));
            body.addChildClass(cape);


            //Badan
            _object3d[0] = new Asset3d();
            _object3d[0].createEllipsoid2(0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            _object3d[0].setColor(new Vector3(44, 87, 91));
            body.addChildClass(_object3d[0]);


            //Outline Kantong
            _object3d[3] = new Asset3d();
            _object3d[3].createHalfBall(0.3f, 0.3f, 0.03f, 0.0f, -0.15f, 0.475f, 800, 2000);
            _object3d[3].rotate(_object3d[0]._center, _object3d[0]._euler[2], 180);
            _object3d[3].rotate(_object3d[0]._center, _object3d[0]._euler[0], 10);
            _object3d[3].setColor(new Vector3(0, 0, 0));
            body.addChildClass(_object3d[3]);

            //kantong
            _object3d[4] = new Asset3d();
            _object3d[4].createHalfBall(0.28f, 0.28f, 0.0f, 0.0f, -0.2f, 0.5f, 800, 2000);
            _object3d[4].rotate(_object3d[0]._center, _object3d[0]._euler[2], 180);
            _object3d[4].rotate(_object3d[0]._center, _object3d[0]._euler[0], 15);
            _object3d[4].setColor(new Vector3(255, 255, 255));
            body.addChildClass(_object3d[4]);

            //kalung lonceng
            _object3d[5] = new Asset3d();
            _object3d[5].createEllipsoid2(0.5f, 0.08f, 0.5f, 0.0f, 0.29f, 0.0f, 300, 100);
            _object3d[5].setColor(new Vector3(240, 57, 96));
            body.addChildClass(_object3d[5]);

            //Hem baju
            _object3d[1] = new Asset3d();
                                                    //x   //z   //y
            _object3d[1].EllipCone(0.14f, 0.02f, 0.15f, 0f, -0.5f, -0.1f);
            _object3d[1].setColor(new Vector3(0, 0, 0));
            _object3d[1].rotate(_object3d[0]._center, _object3d[0]._euler[0], -105);
            _object3d[1].rotate(_object3d[0]._center, _object3d[0]._euler[1], 0);

            body.addChildClass(_object3d[1]);

            //Hem baju
            _object3d[1] = new Asset3d();
                                                    //x   //z   //y
            _object3d[1].EllipCone(0.1f, 0.01f, 0.145f, 0f, -0.51f, -0.05f);
            _object3d[1].setColor(new Vector3(255, 255, 255));
            _object3d[1].rotate(_object3d[0]._center, _object3d[0]._euler[0], -100);
            //_object3d[1].rotate(_object3d[0]._center, _object3d[0]._euler[1], 25);

            body.addChildClass(_object3d[1]);
            
            //Lonceng
            _object3d[7] = new Asset3d();
            _object3d[7].createEllipsoid2(0.03f, 0.03f, 0.03f, 0.0f, 0.3f, 0.55f, 300, 100);
            _object3d[7].setColor(new Vector3(171, 57, 96));
            body.addChildClass(_object3d[7]);

            _object3d[7] = new Asset3d();
            _object3d[7].EllipCone(0.03f, 0.05f, 0.1f, -0.55f, 0.30f, 0f);
            _object3d[7].setColor(new Vector3(171, 57, 96));
            _object3d[7].rotate(_object3d[0]._center, _object3d[0]._euler[1], 90);
            body.addChildClass(_object3d[7]);

            _object3d[7] = new Asset3d();
            _object3d[7].EllipCone(0.03f, 0.05f, 0.1f, 0.55f, 0.30f, 0f);
            _object3d[7].setColor(new Vector3(171, 57, 96));
            _object3d[7].rotate(_object3d[0]._center, _object3d[0]._euler[1], -90);
            body.addChildClass(_object3d[7]);


        }

        public void makeHead()
        {
            main_head = new Asset3d();
            //main_head.createElipseoid(0.5f, 0.45f, 0.4f, 0.5f, 0.5f, 0.5f);
            main_head.createEllipsoid2(0.5f, 0.45f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            main_head.setColor(new Vector3(227, 184, 93));

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

            Asset3d ears;
            //right ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, -0.07f, 0f, -0.76f);
            ears.rotate(main_head._center, ears._euler[0], 90);
            ears.rotate(main_head._center, ears._euler[1], 15);
            ears.setColor(new Vector3(227, 184, 93));
            main_head.addChildClass(ears);
            //left ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, 0.07f, 0f, -0.76f);
            ears.rotate(main_head._center, ears._euler[0], 90);
            ears.rotate(main_head._center, ears._euler[1], -15);
            ears.setColor(new Vector3(227, 184, 93));
            main_head.addChildClass(ears);

            //inner left ear
            ears = new Asset3d();
            ears.EllipPara(0f, 0.021f / 1.5f, 0.004f, 0.3193f, -0.1f, -0.58f);
            ears.rotate(main_head._center, ears._euler[0], 70);
            ears.rotate(main_head._center, ears._euler[1], -15);
            ears.rotate(main_head._center, ears._euler[2], 90);
            ears.setColor(new Vector3(210, 210, 183));
            main_head.addChildClass(ears);
            //inner left ear
            ears = new Asset3d();
            ears.EllipPara(0f, 0.021f / 1.5f, 0.004f, 0.3193f, 0.1f, -0.58f);
            ears.rotate(main_head._center, ears._euler[0], 70);
            ears.rotate(main_head._center, ears._euler[1], 15);
            ears.rotate(main_head._center, ears._euler[2], 90);
            ears.setColor(new Vector3(210, 210, 183));
            main_head.addChildClass(ears);
        }

        public void makeHand()
        {
            //right hand
            right_hand = new Asset3d();
            right_hand.createEllipsoid2(0.12f, 0.12f, 0.12f, 0.55f, 0, 0.3f, 300, 100);
            right_hand.setColor(new Vector3(211, 211, 211));
            //right arm
            Asset3d arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, 0.45f, 0f, 0f);
            arm.setColor(new Vector3(236, 239, 241));
            arm.rotate(right_hand._center, arm._euler[0], 0);
            arm.rotate(right_hand._center, arm._euler[1], 15);
            right_hand.addChildClass(arm);

            arm = new Asset3d();
            arm.EllipPara(0.013f, 0.013f, 0.0035f, 0.45f, 0f, 0f);
            arm.setColor(new Vector3(44, 74, 91));
            //arm.rotate(right_hand._center, arm._euler[0], 90);
            arm.rotate(right_hand._center, arm._euler[0], 0);
            arm.rotate(right_hand._center, arm._euler[1], 15);
            right_hand.addChildClass(arm);


            //left arm
            left_hand = new Asset3d();
            left_hand.EllipPara(0.011f, 0.011f, 0.0035f, -0.45f, 0f, 0f);
            left_hand.setColor(new Vector3(44, 74, 91));
            //left_hand.rotate(right_hand._center, left_hand._euler[0], 90);
            left_hand.rotate(left_hand._center, left_hand._euler[0], 270);
            left_hand.rotate(left_hand._center, left_hand._euler[1], -15);

            //left arm
            arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, -0.45f, 0f, 0f);
            arm.setColor(new Vector3(236, 239, 241));
            arm.rotate(right_hand._center, arm._euler[0], 270);
            arm.rotate(right_hand._center, arm._euler[1], -15);
            left_hand.addChildClass(arm);

            //left hand
            arm = new Asset3d();
            arm.createEllipsoid2(0.12f, 0.12f, 0.12f, -0.55f, 0.3f, 0.0f, 300, 100);
            arm.setColor(new Vector3(211, 211, 211));
            left_hand.addChildClass(arm);
        }

        public void makeFoot()
        {
            //right foot
            right_foot = new Asset3d();
            right_foot.createEllipsoid2(0.2f, 0.1f, 0.2f, 0.2f, -0.75f, 0.0f, 300, 100);
            right_foot.setColor(new Vector3(56, 60, 61));
            //right leg
            Asset3d leg = new Asset3d();
            leg.createHalfBall(0.2f, 0.45f, 0.1f, 0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(227, 184, 93));
            right_foot.addChildClass(leg);

            //left foot
            left_foot = new Asset3d();
            left_foot.createEllipsoid2(0.2f, 0.1f, 0.2f, -0.2f, -0.75f, 0.0f, 300, 100);
            left_foot.setColor(new Vector3(56, 60, 61));
            //left leg
            leg = new Asset3d();
            leg.createHalfBall(0.2f, 0.45f, 0.1f, -0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(227, 184, 93));
            left_foot.addChildClass(leg);
        }

        public void makePawaemon()
        {
            makeFoot();
            makeHead();
            makeBody();
            makeHand();

            main_head.translateObject(0, 0.54f, 0);
            body.translateObject(0, -0.15f, 0);
            //right_foot.translateObject(0, -0.15f, 0);
            //left_foot.translateObject(0, -0.15f, 0);

            pawaemon.addChildClass(main_head);
            pawaemon.addChildClass(body);
            pawaemon.addChildClass(right_hand);
            pawaemon.addChildClass(left_hand);
            pawaemon.addChildClass(right_foot);
            pawaemon.addChildClass(left_foot);
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            
            makePawaemon();

            pawaemon.load(Constant.PATH + "shader.vert", Constant.PATH + "shader.frag", Size.X, Size.Y);
            _camera = new Camera(new Vector3(0, 0, 1), Size.X / Size.Y);
            cam.addChildClass(pawaemon);

            GL.GetInteger(GetPName.MaxVertexAttribs, out int maxAttributeCount);
            Console.WriteLine($"Maximum number of vertex attributes supported : {maxAttributeCount}");
        }
        bool plus = true;
        float rotate = 0;
        float totalRot = 30;
        float rotDeg = 1;
        int left = 1;
        bool [] leftFoot = {true, false};
        private void animate()
        {
            //condition of moving animation for positive degree
            if (rotate >= 0 && rotate < totalRot)
            {
                plus = true;
            }
            //condition of moving animation for negative degree
            else
            {
                //first checking after rotate is equal to total rotation (totalRot)
                if (plus)
                {
                    rotate = -1;
                }
                
                if (rotate > (-1 * totalRot - 1))
                {
                    plus = false;
                }
                //switching movement to positive degree condition
                else
                {
                    rotate = 0;
                    plus = true;
                    if (left == 1)
                    {
                        left = 0;
                    }else
                    {
                        left = 1;
                    }
                }
            }
            if (plus)
            {
                
                pawaemon.Child[3].rotate(pawaemon.Child[3]._center, pawaemon.Child[3]._euler[0], rotDeg);
                
                pawaemon.Child[2].rotate(pawaemon._center, pawaemon._euler[1], rotDeg * -1);
                if (leftFoot[left])
                {
                    pawaemon.Child[5].rotate(pawaemon._center, pawaemon._euler[0], rotDeg * -1);
                    pawaemon.Child[0].rotate(pawaemon.Child[0]._center, pawaemon.Child[3]._euler[2], rotDeg / 3);
                }
                else
                {
                    pawaemon.Child[4].rotate(pawaemon._center, pawaemon._euler[0], rotDeg * -1);
                    pawaemon.Child[0].rotate(pawaemon.Child[0]._center, pawaemon.Child[3]._euler[2], rotDeg / 3 * -1);
                }
                rotate += rotDeg;
            }
            else
            {
                //pawaemon.Child[0].rotate(pawaemon.Child[0]._center, pawaemon.Child[3]._euler[2], rotDeg * -1 / 3);
                pawaemon.Child[3].rotate(pawaemon.Child[3]._center, pawaemon.Child[3]._euler[0], rotDeg * -1);
                pawaemon.Child[2].rotate(pawaemon._center, pawaemon._euler[1], rotDeg);
                if (leftFoot[left])
                {
                    pawaemon.Child[5].rotate(pawaemon._center, pawaemon._euler[0], rotDeg);
                    pawaemon.Child[0].rotate(pawaemon.Child[0]._center, pawaemon.Child[3]._euler[2], rotDeg / 3 * -1);
                } else
                {
                    pawaemon.Child[4].rotate(pawaemon._center, pawaemon._euler[0], rotDeg);
                    pawaemon.Child[0].rotate(pawaemon.Child[0]._center, pawaemon.Child[3]._euler[2], rotDeg / 3);
                }
                
                rotate -= rotDeg;
            }
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            _time += 9.0 * args.Time;
            Matrix4 temp = Matrix4.Identity;

            //pawaemon.rotate(pawaemon._center, pawaemon._euler[1], -1);
            //pawaemon.rotate(pawaemon._center, pawaemon._euler[0], 1);

            animate();

            pawaemon.render(3, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            _camera.Fov = _camera.Fov - e.OffsetY;
        }



        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Escape))
            {
                Close();
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

            float cameraSpeed = 0.5f;
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.LeftShift))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }

            if (KeyboardState.IsKeyDown(Keys.N))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Position = Vector3.Transform(
                    _camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed)
                    .ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position
                    - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.Comma))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed)
                    .ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.K))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.M))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }

            var mouse = MouseState;
            var sensitivity = 0.2f;

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }
        }

        public Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatix = new Matrix4
            (
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatix;
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
