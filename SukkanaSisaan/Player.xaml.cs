﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SukkanaSisaan
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Player : UserControl
    {
        // offset
        // private int currentFrame = 0
        // private int frameheight = X

        // private DispatcherTimer timer;

        // private double 
        private double speed = 10;

        public double LocationX { get; set; }
        public double LocationY { get; set; }


        public Player()
        {
            this.InitializeComponent();
        }

        // MOVEMENTS
        public void MoveUp()

        {
            LocationY = LocationY - speed;
        }

        public void MoveDown()
        {
            LocationY = LocationY + speed;
        }

        public void MoveLeft()
        {
            LocationX = LocationX - speed;
        }

        public void MoveRight()
        {
            LocationX = LocationX + speed;
        }

        // Attack
        public void PlayerAttack()
        {

        }

        public void UpdatePlayer()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
    }
}
