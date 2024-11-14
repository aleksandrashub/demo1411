using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using demo1411shubenok.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace demo1411shubenok;

public partial class Catalog : Window
{
    public List<Prod> prods = Helper.user11019Context.Prods.Include(x => x.IdManNavigation).ToList();
    public Catalog()
    {
        InitializeComponent();
        updateList();
        if (Helper.isGuest == false)
        {
            fioClient.Text = Helper.currUser.Surname + " " + Helper.currUser.Name + " " + Helper.currUser.Lastname;
        }
        
    }

    private void updateList()
    {
        var currProds = prods;

        switch (sort.SelectedIndex)
        {
        case 0:
                currProds = prods.OrderBy(x => x.ItogCost).ToList();
                break;
        case 1:
                currProds = prods.OrderByDescending(x => x.ItogCost).ToList();
                break;
        case 2:
        default:
                break;
        
        }

        switch (filter.SelectedIndex)
        {
            case 0:
                currProds = prods.Where(x => x.CurrDisc < 10).ToList();
                break;
            case 1:
                currProds = prods.Where(x => x.CurrDisc < 15 && x.CurrDisc >=10).ToList();
                break;

            case 2:
                currProds = prods.Where(x => x.CurrDisc >= 15).ToList();
                break;
            case 3:
            default:
                break;
        
        }

        string searchText = poisk.Text ?? "";
        int count = searchText.Split(' ').Length;
        searchText = searchText.ToLower();
        string[] values = new string[count];
        values = searchText.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

        foreach (string s in values)
        {
            if (!string.IsNullOrEmpty(s))
            {
                currProds = prods.Where(x => x.Name.Contains(s)).ToList();

            }
            else
            {
                continue;
            }
        }
        listbox.ItemsSource = currProds;
    }

    private void Sort_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        updateList();
    }
    private void Filter_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
    {
        updateList();
    }

    private void Poisk_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        updateList();
    }

    private void MenuItem_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var product = listbox.SelectedItem as Prod;




    }
}