﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KarliCards.Gui
{
    /// <summary>
    /// GameClientWindow.xaml 的交互逻辑
    /// </summary>
    public partial class GameClientWindow : Window
    {
        public GameClientWindow()
        {
            InitializeComponent();
            var position = new Point(15, 15);
            for(var i = 0; i < 4; i++)
            {
                var suit = (unit13_3.Suit)i;
                position.Y = 15;
                for(int rank= 1; rank < 14; rank++)
                {
                    position.Y += 30;
                    var card = new CardControl(new unit13_3.Card((unit13_3.Suit)suit, (unit13_3.Rank)rank));
                    card.VerticalAlignment = VerticalAlignment.Top;
                    card.HorizontalAlignment = HorizontalAlignment.Left;
                    card.Margin = new Thickness(position.X, position.Y, 0, 0);
                    contentGrid.Children.Add(card);
                }
                position.X += 112;
            }
        }
        //是否对用户可用
        private void CommandCanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Close)
                e.CanExecute = true;
            if (e.Command == ApplicationCommands.Save)
                e.CanExecute = false;
            e.Handled = true;
        }
        //在用户激活命令时调用
        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Close)
                this.Close();
            e.Handled = true;
        }
    }
}