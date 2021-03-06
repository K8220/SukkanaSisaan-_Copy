﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SukkanaSisaan
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game_map_01 : Page
    {
        // monster
        private Monster monster;

        // player
        private Player player;
        private Projectile projectile;

        // canvas width and height
        private double CanvasWidth;
        private double CanvasHeight;

        private bool UpPressed;
        private bool DownPressed;
        private bool LeftPressed;
        private bool RightPressed;
        private bool ZPressed;
        private bool ProjectileActive = false;

        private DispatcherTimer timer;
        private DispatcherTimer attTimer;

        public Game_map_01()
        {
            this.InitializeComponent();
            CanvasWidth = GameCanvas.Width;
            CanvasHeight = GameCanvas.Height;

            // monster location
            
            monster = new Monster
            {
                LocationX = 300,
                LocationY = 400
            };
            monster.UpdateMonster();
            // add monster to the canvas
            GameCanvas.Children.Add(monster);
            

            player = new Player
            {
                LocationX = GameCanvas.Width / 2,
                LocationY = GameCanvas.Height / 2
             };
            player.UpdatePlayer();

            // add player to the canvas
            GameCanvas.Children.Add(player);

            // key listeners
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            // game loop
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            timer.Tick += Timer_Tick;
            timer.Start();

            // attack timer
            attTimer = new DispatcherTimer();
            attTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            attTimer.Tick += attTimer_Tick;

            // update player position
            player.UpdatePlayer();
            //if (ProjectileActive == true)
        }
        private void attTimer_Tick(object sender, object e)
        {
            GameCanvas.Children.Remove(projectile);
            attTimer.Stop();
            ProjectileActive=false;
        }

        private void Timer_Tick(object sender, object e)
        {
            // moving
            
            if (UpPressed) player.MoveUp();
            if (DownPressed) player.MoveDown();
            if (LeftPressed) player.MoveLeft();
            if (RightPressed) player.MoveRight();
            if (ZPressed)
            {
                if (ProjectileActive == false)
                {
                    projectile = new Projectile
                    {
                        LocationX = player.LocationX,
                        LocationY = player.LocationY - 30
                    };
                    ProjectileActive = true;
                    GameCanvas.Children.Add(projectile);
                }
                attTimer.Start();
            }
            player.UpdatePlayer();
            if (ProjectileActive) projectile.UpdateProjectile();
        }

        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Up:
                    UpPressed = false;
                    break;
                case VirtualKey.Down:
                    DownPressed = false;
                    break;
                case VirtualKey.Left:
                    LeftPressed = false;
                    break;
                case VirtualKey.Right:
                    RightPressed = false;
                    break;
                case VirtualKey.Z:
                    ZPressed = false;
                    break;
            }
        }

        
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Up:
                    UpPressed = true;
                    break;
                case VirtualKey.Down:
                    DownPressed = true;
                    break;
                case VirtualKey.Left:
                    LeftPressed = true;
                    break;
                case VirtualKey.Right:
                    RightPressed = true;
                    break;
                case VirtualKey.Z:
                    // ProjectileActive = true;
                    ZPressed = true;
                    break;
            }
        }
    }
}
