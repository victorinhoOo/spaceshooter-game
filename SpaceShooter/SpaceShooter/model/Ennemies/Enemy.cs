﻿using IUTGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter.model.Ennemies
{
    public abstract class Enemy : GameItem, IAnimable
    {
        private double speed = 200;
        public double Speed { get => speed; set => speed = value; }


        private double angle = 100;
        public double Angle { get=> angle; set => angle = value; }


        private int amount = 0;
        public int Amount { get=> amount; set => amount = value; }


        private TimeSpan waiting = TimeSpan.Zero;
        public TimeSpan Waiting { get => waiting; set => waiting = value; }


        private bool touched = false;
        public bool Touched { get => touched; set => touched = value; }



        public Enemy(double x, double y, Game g, string name = "", int zindex = 0) :
            base(x, y, g, name, zindex)
        {
            ++amount;
        }

        public override string TypeName => "Enemy";



        public override void CollideEffect(GameItem other)
        {
            if (touched == false)
            {
                waiting = new TimeSpan(0, 0, 0, 600);
                touched = true;
            }
            else if (touched == true && waiting <= TimeSpan.Zero)
            {
                touched = false;
            }
            if (other.TypeName == "Player")
            {
                TheGame.RemoveItem(this);
            }
            if (other.TypeName == "PlayerBullet")
            {
                //this.ChangeSprite("explosion.png");
                TheGame.RemoveItem(this);
                --amount;
            }
            if (other.TypeName == "Enemy")
            {
                Angle = (360 + 180 - Angle) % 360;
            }






        }
        public abstract void Animate(TimeSpan dt);
    }
}
    
