using Avalonia.Controls;
using demo1411shubenok.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace demo1411shubenok
{
    public partial class MainWindow : Window
    {
        public List<Client> clients = Helper.user11019Context.Clients.Include(x => x.IdRoleNavigation).ToList();
        public bool access = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Guest_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Helper.isGuest = true;
            Catalog catalog = new Catalog();
            catalog.Show();
            this.Close();



        }

        private void vhod_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            string loginStr = loginTb.Text;
            string passwdStr = paswdTb.Text;
            foreach (Client client in clients) 
            {
                if (client.Login == loginStr && client.Passwd == passwdStr)
                { 
                    access = true;
                    Helper.currUser = client;
                
                }
            }
            if (access)
            { 
            
            
            }

        }
    }
}