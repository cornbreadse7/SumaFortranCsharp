using System;
using Gtk;
using System.Runtime.InteropServices;

public class SumaApp : Window
{
    [DllImport("suma.so", CallingConvention = CallingConvention.Cdecl)]
    public static extern double suma(double a, double b);

    private Entry entryNum1;
    private Entry entryNum2;
    private Label resultadoLabel;

    public SumaApp() : base("Suma de dos números")
    {
        SetDefaultSize(250, 150);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };

        VBox vbox = new VBox();
        entryNum1 = new Entry();
        entryNum2 = new Entry();
        Button sumarButton = new Button("Sumar");
        resultadoLabel = new Label("Resultado: ");

        sumarButton.Clicked += OnSumarButtonClicked;

        vbox.PackStart(new Label("Número 1:"), false, false, 5);
        vbox.PackStart(entryNum1, false, false, 5);
        vbox.PackStart(new Label("Número 2:"), false, false, 5);
        vbox.PackStart(entryNum2, false, false, 5);
        vbox.PackStart(sumarButton, false, false, 5);
        vbox.PackStart(resultadoLabel, false, false, 5);

        Add(vbox);
        ShowAll();
    }

    private void OnSumarButtonClicked(object sender, EventArgs e)
    {
        try
        {
            double num1 = double.Parse(entryNum1.Text);
            double num2 = double.Parse(entryNum2.Text);
            double resultado = suma(num1, num2);
            resultadoLabel.Text = "Resultado: " + resultado.ToString();
        }
        catch (Exception ex)
        {
            resultadoLabel.Text = "Error: " + ex.Message;
        }
    }

    public static void Main()
    {
        Application.Init();
        new SumaApp();
        Application.Run();
    }
}
