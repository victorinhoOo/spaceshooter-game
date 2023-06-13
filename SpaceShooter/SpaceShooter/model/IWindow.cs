using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model
{
    public interface IWindow
    {
        public void UpdateScore(int score);
        public void CloseWindow();
    }
}
