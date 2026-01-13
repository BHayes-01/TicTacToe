using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicTacToe.Business.Business;

public class ItemsViewModel
{

    public ObservableCollection<string> Items { get; } = new ObservableCollection<string>();


    private Regex MyRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%^&*()-_+=]).{10,}$");
}

