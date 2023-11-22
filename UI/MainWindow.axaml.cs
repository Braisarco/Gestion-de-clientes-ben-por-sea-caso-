using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using gestor_stock_clientes.Properties;

namespace UI;

public partial class MainWindow : Window
{
    private Clientes clientes = new Clientes();
    public List<Cliente> ListaClientes { get; set; }

    public MainWindow()
    {
        if (File.Exists("Clientes.xml"))
        {
            clientes.fromXML("Clientes.xml");
        }
        
        InitializeComponent();

        UpdateView();

        var botonAnhadir = this.FindControl<Button>("nuevoCliente");
        var textoBuscar = this.FindControl<TextBox>("buscador");
        
        botonAnhadir.Click += (_, _) => this.AnhadirCliente();
        textoBuscar.TextChanging += (_, _) => this.BuscarCliente(textoBuscar.Text);
    }

    void AnhadirCliente()
    {
        var nombre = this.FindControl<TextBox>("newName");
        var cif = this.FindControl<TextBox>("newCIF");
        var direccion = this.FindControl<TextBox>("newDireccion");
        
        Cliente c = new Cliente(cif.Text, nombre.Text, direccion.Text);
        
        this.clientes.AñadirCliente(c);
        this.clientes.saveXML();

        UpdateView();
    }

    void BuscarCliente(String nombre)
    {
        if (!nombre.Equals(""))
        {
            List<Cliente> auxiliar = this.clientes.buscarClienteNombre(nombre);
            this.ListaClientes = auxiliar;
            ItemsControl.ItemsSource = this.ListaClientes;
        }else{
         UpdateView();   
        }
        
    }

    void EliminarCliente(object? sender, RoutedEventArgs routedEventArgs)
    {
        Clientes auxiliar = new Clientes(this.clientes.ListaClientes);
        Button boton = (Button)sender;
        this.clientes.EliminarCliente(boton.Tag.ToString());
        
        UpdateView();
    }

    void UpdateView()
    {
        this.ListaClientes = clientes.ListaClientes.ToList();
        ItemsControl.ItemsSource = this.ListaClientes;
    }
    
}