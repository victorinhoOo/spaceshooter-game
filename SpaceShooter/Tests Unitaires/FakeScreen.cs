#region assembly IUTGame, Version=2.1.2.0, Culture=neutral, PublicKeyToken=null
// C:\Users\clementboutet\Desktop\S2_01\2022-23_S2-01_C1_SpaceShooter\SpaceShooter\SpaceShooter\IUTGame.dll
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion

using IUTGame;
using IUTGame.WPF;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Tests_Unitaires
{
    public class FakeScreen : IScreen
    {
        private Canvas canvas;

        private KeyEvent keyDown;

        private KeyEvent keyUp;

        private MouseWheelEvent mouseWheel;

        private MouseButtonEvent mouseDown;

        private MouseButtonEvent mouseUp;

        private MouseMoveEvent mouseMove;

        private List<Sprite> sprites;

        private SpriteStore spriteStore;

        public KeyEvent KeyDown
        {
            get
            {
                return keyDown;
            }
            set
            {
                keyDown = value;
            }
        }

        public KeyEvent KeyUp
        {
            get
            {
                return keyUp;
            }
            set
            {
                keyUp = value;
            }
        }

        public MouseWheelEvent MouseWheel
        {
            get
            {
                return mouseWheel;
            }
            set
            {
                mouseWheel = value;
            }
        }

        public MouseButtonEvent MouseDown
        {
            get
            {
                return mouseDown;
            }
            set
            {
                mouseDown = value;
            }
        }

        public MouseButtonEvent MouseUp
        {
            get
            {
                return mouseUp;
            }
            set
            {
                mouseUp = value;
            }
        }

        public MouseMoveEvent MouseMove
        {
            get
            {
                return mouseMove;
            }
            set
            {
                mouseMove = value;
            }
        }

        public double Width => canvas.ActualWidth;

        public double Height => 0.1;

        public FakeScreen()
        {

        }

        public void Focus()
        {

        }

        public void InitSpritesStore(string spritesFolderName)
        {
    
        }

        public int LoadSprite(string spriteName)
        {
            return 1;
        }

        public void RemoveSprite(int spriteID)
        {
            if (spriteID > -1)
            {
                canvas.Children.Remove(sprites[spriteID].Image);
            }
        }

        public void DrawSprite(int spriteID, double x, double y, double angle = 0.0, double scaleX = 1.0, double scaleY = 1.0, int zindex = 1)
        {
            sprites[spriteID].Draw(x, y, angle, scaleX, scaleY, zindex);
        }

        public double GetSpriteWidth(int spriteID)
        {
            double result = 0.0;

            return result;
        }

        public double GetSpriteHeight(int spriteID)
        {
            double result = 0.0;

            

            return result;
        }
    }
}
