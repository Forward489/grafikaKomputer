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
        Asset3d[] _object3dPawaemon = new Asset3d[20];
        Asset3d bodyPawaemon;
        Asset3d main_head_pawaemon;
        Asset3d cone;
        Asset3d right_hand_pawaemon;
        Asset3d left_hand_pawaemon;
        Asset3d right_foot_pawaemon;
        Asset3d left_foot_pawaemon;
        Asset3d cam = new Asset3d();
        Asset3d cape_pawaemon;
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

        public void makeBodyPawaemon()
        {
            //Ganti Background
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            _object3dPawaemon[0] = new Asset3d();
            bodyPawaemon = new Asset3d();

            //cape_pawaemon
            cape_pawaemon = new Asset3d();
            cape_pawaemon.EllipCone2(0.1f, 0.15f, 0.28f, 0f, -0.4f, 0.0f);
            cape_pawaemon.setColor(new Vector3(44, 87, 91));
            cape_pawaemon.rotate(cape_pawaemon._center, cape_pawaemon._euler[1], 90);
            bodyPawaemon.addChildClass(cape_pawaemon);

            //Circle for cape_pawaemon
            cape_pawaemon = new Asset3d();
            cape_pawaemon.createEllipsoid2(0, 0.21f, 0.14f, -0.4f, -0.4f, 0.0f, 300, 100);
            cape_pawaemon.setColor(new Vector3(44, 87, 91));
            bodyPawaemon.addChildClass(cape_pawaemon);

            //Circle for cape_pawaemon
            cape_pawaemon = new Asset3d();
            cape_pawaemon.createEllipsoid2(0, 0.21f, 0.14f, 0.4f, -0.4f, 0.0f, 300, 100);
            cape_pawaemon.setColor(new Vector3(44, 87, 91));
            bodyPawaemon.addChildClass(cape_pawaemon);


            //Badan
            _object3dPawaemon[0] = new Asset3d();
            _object3dPawaemon[0].createEllipsoid2(0.5f, 0.5f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            _object3dPawaemon[0].setColor(new Vector3(44, 87, 91));
            bodyPawaemon.addChildClass(_object3dPawaemon[0]);


            //Outline Kantong
            _object3dPawaemon[3] = new Asset3d();
            _object3dPawaemon[3].createHalfBall(0.3f, 0.3f, 0.03f, 0.0f, -0.15f, 0.475f, 800, 2000);
            _object3dPawaemon[3].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[2], 180);
            _object3dPawaemon[3].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[0], 10);
            _object3dPawaemon[3].setColor(new Vector3(0, 0, 0));
            bodyPawaemon.addChildClass(_object3dPawaemon[3]);

            //kantong
            _object3dPawaemon[4] = new Asset3d();
            _object3dPawaemon[4].createHalfBall(0.28f, 0.28f, 0.0f, 0.0f, -0.2f, 0.5f, 800, 2000);
            _object3dPawaemon[4].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[2], 180);
            _object3dPawaemon[4].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[0], 15);
            _object3dPawaemon[4].setColor(new Vector3(255, 255, 255));
            bodyPawaemon.addChildClass(_object3dPawaemon[4]);

            //kalung lonceng
            _object3dPawaemon[5] = new Asset3d();
            _object3dPawaemon[5].createEllipsoid2(0.5f, 0.08f, 0.5f, 0.0f, 0.29f, 0.0f, 300, 100);
            _object3dPawaemon[5].setColor(new Vector3(240, 57, 96));
            bodyPawaemon.addChildClass(_object3dPawaemon[5]);

            //Hem baju
            _object3dPawaemon[1] = new Asset3d();
                                                    //x   //z   //y
            _object3dPawaemon[1].EllipCone(0.14f, 0.02f, 0.15f, 0f, -0.5f, -0.1f);
            _object3dPawaemon[1].setColor(new Vector3(0, 0, 0));
            _object3dPawaemon[1].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[0], -105);
            _object3dPawaemon[1].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[1], 0);

            bodyPawaemon.addChildClass(_object3dPawaemon[1]);

            //Hem baju
            _object3dPawaemon[1] = new Asset3d();
                                                    //x   //z   //y
            _object3dPawaemon[1].EllipCone(0.1f, 0.01f, 0.145f, 0f, -0.51f, -0.05f);
            _object3dPawaemon[1].setColor(new Vector3(255, 255, 255));
            _object3dPawaemon[1].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[0], -100);
            //_object3dPawaemon[1].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[1], 25);

            bodyPawaemon.addChildClass(_object3dPawaemon[1]);
            
            //Lonceng
            _object3dPawaemon[7] = new Asset3d();
            _object3dPawaemon[7].createEllipsoid2(0.03f, 0.03f, 0.03f, 0.0f, 0.3f, 0.55f, 300, 100);
            _object3dPawaemon[7].setColor(new Vector3(171, 57, 96));
            bodyPawaemon.addChildClass(_object3dPawaemon[7]);

            _object3dPawaemon[7] = new Asset3d();
            _object3dPawaemon[7].EllipCone(0.03f, 0.05f, 0.1f, -0.55f, 0.30f, 0f);
            _object3dPawaemon[7].setColor(new Vector3(171, 57, 96));
            _object3dPawaemon[7].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[1], 90);
            bodyPawaemon.addChildClass(_object3dPawaemon[7]);

            _object3dPawaemon[7] = new Asset3d();
            _object3dPawaemon[7].EllipCone(0.03f, 0.05f, 0.1f, 0.55f, 0.30f, 0f);
            _object3dPawaemon[7].setColor(new Vector3(171, 57, 96));
            _object3dPawaemon[7].rotate(_object3dPawaemon[0]._center, _object3dPawaemon[0]._euler[1], -90);
            bodyPawaemon.addChildClass(_object3dPawaemon[7]);


        }

        public void makeHeadPawaemon()
        {
            main_head_pawaemon = new Asset3d();
            //main_head_pawaemon.createElipseoid(0.5f, 0.45f, 0.4f, 0.5f, 0.5f, 0.5f);
            main_head_pawaemon.createEllipsoid2(0.5f, 0.45f, 0.5f, 0.0f, 0.0f, 0.0f, 300, 100);
            main_head_pawaemon.setColor(new Vector3(227, 184, 93));

            Asset3d eyes = new Asset3d();

            eyes.createEllipsoid2(0.1f, 0.15f, 0.1f, -0.1f, 0.15f, 0.4f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_head_pawaemon.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f, 0.15f, 0.1f, 0.1f, 0.15f, 0.4f, 300, 100);
            eyes.setColor(new Vector3(255.0f, 255.0f, 255.0f));
            main_head_pawaemon.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, 0.05f, 0.15f, 0.5f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_head_pawaemon.addChildClass(eyes);

            eyes = new Asset3d();
            eyes.createEllipsoid2(0.1f / 3f, 0.15f / 3f, 0.05f / 3f, -0.05f, 0.15f, 0.5f, 300, 100);
            eyes.setColor(new Vector3(0.0f, 0.0f, 0.0f));
            main_head_pawaemon.addChildClass(eyes);
            Asset3d cheek = new Asset3d();
            Asset3d smile = new Asset3d();
            Asset3d nose = new Asset3d();
            cheek.createEllipsoid2(0.35f, 0.23f, 0.05f, 0.0f, 0.05f, 0.44f, 300, 100);
            cheek.setColor(new Vector3(255f, 255f, 255f));
            cheek.rotate(main_head_pawaemon._center, main_head_pawaemon._euler[0], 35);

            nose.createEllipsoid2(0.075f, 0.075f, 0.075f, 0.0f, 0.0f, 0.5f, 300, 100);
            nose.setColor(new Vector3(255.0f, 0.0f, 0.0f));

            smile.createHalfBall(0.2f, 0.15f, 0f, 0.0f, -0.1f, 0.5f, 800, 2000);
            smile.setColor(new Vector3(255f, 0f, 0f));
            smile.rotate(main_head_pawaemon._center, main_head_pawaemon._euler[2], 180);
            smile.rotate(main_head_pawaemon._center, main_head_pawaemon._euler[0], 35);
            main_head_pawaemon.addChildClass(smile);
            main_head_pawaemon.addChildClass(cheek);
            main_head_pawaemon.addChildClass(nose);
            Asset3d mustache;
            //Right Mustache
            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.52f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], 90);
            mustache.rotate(main_head_pawaemon._center, mustache._euler[0], -15);
            main_head_pawaemon.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.5f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], 90);
            main_head_pawaemon.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, -0.5f, -0.12f, 0.15f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], 90);
            mustache.rotate(main_head_pawaemon._center, mustache._euler[0], 15);
            main_head_pawaemon.addChildClass(mustache);

            //Left Mustache
            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.49f, -0.12f, 0.13f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], -90);
            mustache.rotate(main_head_pawaemon._center, mustache._euler[0], 15);
            main_head_pawaemon.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.5f, -0.12f, 0.1f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], -90);
            main_head_pawaemon.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 9f, 0.004f, 0.52f, -0.12f, 0.08f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[1], -90);
            mustache.rotate(main_head_pawaemon._center, mustache._euler[0], -15);
            main_head_pawaemon.addChildClass(mustache);

            mustache = new Asset3d();
            mustache.EllipPara(0.01f / 9f, 0.01f / 15f, 0.0014f, 0f, 0.53f, -0.115f);
            mustache.setColor(new Vector3(0, 0, 0));
            mustache.rotate(main_head_pawaemon._center, mustache._euler[0], 110);
            main_head_pawaemon.addChildClass(mustache);

            Asset3d ears;
            //right ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, -0.07f, 0f, -0.76f);
            ears.rotate(main_head_pawaemon._center, ears._euler[0], 90);
            ears.rotate(main_head_pawaemon._center, ears._euler[1], 15);
            ears.setColor(new Vector3(227, 184, 93));
            main_head_pawaemon.addChildClass(ears);
            //left_pawaemon ear
            ears = new Asset3d();
            ears.EllipPara(0.021f, 0.021f, 0.004f, 0.07f, 0f, -0.76f);
            ears.rotate(main_head_pawaemon._center, ears._euler[0], 90);
            ears.rotate(main_head_pawaemon._center, ears._euler[1], -15);
            ears.setColor(new Vector3(227, 184, 93));
            main_head_pawaemon.addChildClass(ears);

            //inner left_pawaemon ear
            ears = new Asset3d();
            ears.EllipPara(0f, 0.021f / 1.5f, 0.004f, 0.3193f, -0.1f, -0.58f);
            ears.rotate(main_head_pawaemon._center, ears._euler[0], 70);
            ears.rotate(main_head_pawaemon._center, ears._euler[1], -15);
            ears.rotate(main_head_pawaemon._center, ears._euler[2], 90);
            ears.setColor(new Vector3(210, 210, 183));
            main_head_pawaemon.addChildClass(ears);
            //inner left_pawaemon ear
            ears = new Asset3d();
            ears.EllipPara(0f, 0.021f / 1.5f, 0.004f, 0.3193f, 0.1f, -0.58f);
            ears.rotate(main_head_pawaemon._center, ears._euler[0], 70);
            ears.rotate(main_head_pawaemon._center, ears._euler[1], 15);
            ears.rotate(main_head_pawaemon._center, ears._euler[2], 90);
            ears.setColor(new Vector3(210, 210, 183));
            main_head_pawaemon.addChildClass(ears);
        }

        public void makeHandPawaemon()
        {
            //right hand
            right_hand_pawaemon = new Asset3d();
            right_hand_pawaemon.createEllipsoid2(0.12f, 0.12f, 0.12f, 0.55f, 0, 0.3f, 300, 100);
            right_hand_pawaemon.setColor(new Vector3(211, 211, 211));
            //right arm
            Asset3d arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, 0.45f, 0f, 0f);
            arm.setColor(new Vector3(236, 239, 241));
            arm.rotate(right_hand_pawaemon._center, arm._euler[0], 0);
            arm.rotate(right_hand_pawaemon._center, arm._euler[1], 15);
            right_hand_pawaemon.addChildClass(arm);

            arm = new Asset3d();
            arm.EllipPara(0.013f, 0.013f, 0.0035f, 0.45f, 0f, 0f);
            arm.setColor(new Vector3(44, 74, 91));
            //arm.rotate(right_hand_pawaemon._center, arm._euler[0], 90);
            arm.rotate(right_hand_pawaemon._center, arm._euler[0], 0);
            arm.rotate(right_hand_pawaemon._center, arm._euler[1], 15);
            right_hand_pawaemon.addChildClass(arm);


            //left_pawaemon arm
            left_hand_pawaemon = new Asset3d();
            left_hand_pawaemon.EllipPara(0.011f, 0.011f, 0.0035f, -0.45f, 0f, 0f);
            left_hand_pawaemon.setColor(new Vector3(44, 74, 91));
            //left_hand_pawaemon.rotate(right_hand_pawaemon._center, left_hand_pawaemon._euler[0], 90);
            left_hand_pawaemon.rotate(left_hand_pawaemon._center, left_hand_pawaemon._euler[0], 270);
            left_hand_pawaemon.rotate(left_hand_pawaemon._center, left_hand_pawaemon._euler[1], -15);

            //left_pawaemon arm
            arm = new Asset3d();
            arm.EllipPara(0.011f, 0.011f, 0.004f, -0.45f, 0f, 0f);
            arm.setColor(new Vector3(236, 239, 241));
            arm.rotate(right_hand_pawaemon._center, arm._euler[0], 270);
            arm.rotate(right_hand_pawaemon._center, arm._euler[1], -15);
            left_hand_pawaemon.addChildClass(arm);

            //left_pawaemon hand
            arm = new Asset3d();
            arm.createEllipsoid2(0.12f, 0.12f, 0.12f, -0.55f, 0.3f, 0.0f, 300, 100);
            arm.setColor(new Vector3(211, 211, 211));
            left_hand_pawaemon.addChildClass(arm);
        }

        public void makeFootPawaemon()
        {
            //right foot
            right_foot_pawaemon = new Asset3d();
            right_foot_pawaemon.createEllipsoid2(0.2f, 0.1f, 0.2f, 0.2f, -0.75f, 0.0f, 300, 100);
            right_foot_pawaemon.setColor(new Vector3(56, 60, 61));
            //right leg
            Asset3d leg = new Asset3d();
            leg.createHalfBall(0.2f, 0.45f, 0.1f, 0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(227, 184, 93));
            right_foot_pawaemon.addChildClass(leg);

            //left_pawaemon foot
            left_foot_pawaemon = new Asset3d();
            left_foot_pawaemon.createEllipsoid2(0.2f, 0.1f, 0.2f, -0.2f, -0.75f, 0.0f, 300, 100);
            left_foot_pawaemon.setColor(new Vector3(56, 60, 61));
            //left_pawaemon leg
            leg = new Asset3d();
            leg.createHalfBall(0.2f, 0.45f, 0.1f, -0.2f, -0.7f, 0.0f, 800, 2000);
            leg.setColor(new Vector3(227, 184, 93));
            left_foot_pawaemon.addChildClass(leg);
        }

        public void makePawaemon()
        {
            makeFootPawaemon();
            makeHeadPawaemon();
            makeBodyPawaemon();
            makeHandPawaemon();

            main_head_pawaemon.translateObject(0, 0.7f, 0);
            bodyPawaemon.translateObject(0, -0.15f, 0);
            main_head_pawaemon.translateObject(2, -0.15f, 0);
            bodyPawaemon.translateObject(2, 0, 0);
            right_hand_pawaemon.translateObject(2, 0, 0);
            left_hand_pawaemon.translateObject(2, 0, 0);
            right_foot_pawaemon.translateObject(2, 0, 0);
            left_foot_pawaemon.translateObject(2, 0, 0);

            pawaemon.addChildClass(main_head_pawaemon);
            pawaemon.addChildClass(bodyPawaemon);
            pawaemon.addChildClass(right_hand_pawaemon);
            pawaemon.addChildClass(left_hand_pawaemon);
            pawaemon.addChildClass(right_foot_pawaemon);
            pawaemon.addChildClass(left_foot_pawaemon);
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
        bool plus_pawaemon = true;
        float rotate_pawaemon = 0;
        float totalRotPawaemon = 10;
        float rotDegPawaemon = 1;
        int left_pawaemon = 1;
        bool [] leftFootPawaemon = {true, false};
        private void animatePawaemon()
        {
            //condition of moving animation for positive degree
            if (rotate_pawaemon >= 0 && rotate_pawaemon < totalRotPawaemon)
            {
                plus_pawaemon = true;
            }
            //condition of moving animation for negative degree
            else
            {
                //first checking after rotate_pawaemon is equal to total rotation (totalRotPawaemon)
                if (plus_pawaemon)
                {
                    rotate_pawaemon = -1;
                }
                
                //-1 > -30 or -2 > -30 or -3 > -30 and until -30 == -30
                if (rotate_pawaemon > (-1 * totalRotPawaemon - 1))
                {
                    plus_pawaemon = false;
                }
                //switching movement back to positive degree condition
                else
                {
                    rotate_pawaemon = 0;
                    plus_pawaemon = true;
                    if (left_pawaemon == 1)
                    {
                        left_pawaemon = 0;
                    }
                    else
                    {
                        left_pawaemon = 1;
                    }
                }
            }
            if (plus_pawaemon)
            {
                
                pawaemon.Child[3].rotate(pawaemon.Child[3]._center, pawaemon.Child[3]._euler[1], rotDegPawaemon / 3 * -1);
                
                pawaemon.Child[2].rotate(pawaemon.Child[2]._center, pawaemon.Child[2]._euler[1], rotDegPawaemon / 3* -1);
                if (leftFootPawaemon[left_pawaemon])
                {
                    pawaemon.Child[5].rotate(pawaemon.Child[5]._center, pawaemon.Child[5]._euler[0], rotDegPawaemon * -2);
                    pawaemon.Child[0].rotate(pawaemon._center, pawaemon.Child[0]._euler[0], rotDegPawaemon / 4);
                }
                else
                {
                    pawaemon.Child[4].rotate(pawaemon.Child[4]._center, pawaemon.Child[4]._euler[0], rotDegPawaemon * -2);
                    pawaemon.Child[0].rotate(pawaemon._center, pawaemon.Child[0]._euler[0], rotDegPawaemon / 4 * -1);
                }
                rotate_pawaemon += rotDegPawaemon;
            }
            else
            {
                pawaemon.Child[3].rotate(pawaemon.Child[3]._center, pawaemon.Child[3]._euler[1], rotDegPawaemon / 3 * 1);
                pawaemon.Child[2].rotate(pawaemon.Child[2]._center, pawaemon.Child[2]._euler[1], rotDegPawaemon / 3);
                if (leftFootPawaemon[left_pawaemon])
                {
                    pawaemon.Child[5].rotate(pawaemon.Child[5]._center, pawaemon.Child[5]._euler[0], rotDegPawaemon * 2);
                    pawaemon.Child[0].rotate(pawaemon._center, pawaemon.Child[0]._euler[0], rotDegPawaemon / 4 * -1);
                } 
                else
                {
                    pawaemon.Child[4].rotate(pawaemon.Child[4]._center, pawaemon.Child[4]._euler[0], rotDegPawaemon * 2);
                    pawaemon.Child[0].rotate(pawaemon._center, pawaemon.Child[0]._euler[0], rotDegPawaemon / 4);
                }
                rotate_pawaemon -= rotDegPawaemon;
            }
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            _time += 9.0 * args.Time;
            Matrix4 temp = Matrix4.Identity;

            animatePawaemon();

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
