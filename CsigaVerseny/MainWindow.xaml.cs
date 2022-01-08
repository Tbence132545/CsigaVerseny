using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace CsigaVerseny
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double[] sebessegek = new double[3] { 1.35, 1.5, 1.65};
        static List<int> kiMelyikSebessegetKapja = new List<int>() { 0, 0, 0 };
        static Csiga elsoJatekos = new Csiga("csiga1");
        static Csiga masodikJatekos = new Csiga("csiga2");
        static Csiga harmadikJatekos = new Csiga("csiga3");
        static List<Rectangle> helyezesek = new List<Rectangle>();

        DispatcherTimer idozito = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
    
            idozito.Tick += new EventHandler(IdozitoEvent);
            idozito.Interval = new TimeSpan(0, 0, 0, 0, 3);
           
        }
        static public void Pontszamito()
        {
            switch (helyezesek[0].Name)
            {
                case "csiga1":
                    elsoJatekos.hanyszorVoltElso++;
                    break;
                case "csiga2":
                    masodikJatekos.hanyszorVoltElso++;
                    break;
                case "csiga3":
                    harmadikJatekos.hanyszorVoltElso++;
                    break;
            }
            switch (helyezesek[1].Name)
            {
                case "csiga1":
                    elsoJatekos.hanyszorVoltMasodik++;
                    break;
                case "csiga2":
                    masodikJatekos.hanyszorVoltMasodik++;
                    break;
                case "csiga3":
                    harmadikJatekos.hanyszorVoltMasodik++;
                    break;
            }
            switch (helyezesek[2].Name)
            {
                case "csiga1":
                    elsoJatekos.hanyszorVoltHarmadik++;
                    break;
                case "csiga2":
                    masodikJatekos.hanyszorVoltHarmadik++;
                    break;
                case "csiga3":
                    harmadikJatekos.hanyszorVoltHarmadik++;
                    break;
            }
            elsoJatekos.pont = elsoJatekos.hanyszorVoltElso * 3 + elsoJatekos.hanyszorVoltMasodik * 2 + elsoJatekos.hanyszorVoltHarmadik * 1;
            masodikJatekos.pont = masodikJatekos.hanyszorVoltElso * 3 + masodikJatekos.hanyszorVoltMasodik * 2 + masodikJatekos.hanyszorVoltHarmadik * 1;
            harmadikJatekos.pont = harmadikJatekos.hanyszorVoltElso * 3 + harmadikJatekos.hanyszorVoltMasodik * 2 + harmadikJatekos.hanyszorVoltHarmadik * 1;
        }
        
        private void start_btn_Click(object sender, RoutedEventArgs e)

        {
            eredmenyek_btn.IsEnabled = false;
            ujbajnoksag_btn.IsEnabled = false;
            ujfutam_btn.IsEnabled = false;
            start_btn.IsEnabled = false;
            Random rnd = new Random();
            kiMelyikSebessegetKapja.Clear();
            for (int i = 0; i < 3; i++)
            {
                int random = rnd.Next(0, 3);
                if (kiMelyikSebessegetKapja.Contains(random))
                    while (kiMelyikSebessegetKapja.Contains(random))
                    {
                        random = rnd.Next(0, 3);
                    }
                kiMelyikSebessegetKapja.Add(random);

                
            }

            idozito.Start();
        }

        private void IdozitoEvent(object sender, EventArgs e)
        {
            //Külön alprogramot írok Mozogtat néven mert 3 csiga van

            Mozogtat(csiga1, csiga1mezony, sebessegek[kiMelyikSebessegetKapja[0]],csiga1_label);
            Mozogtat(csiga2, csiga2mezony, sebessegek[kiMelyikSebessegetKapja[1]],csiga2_label);
            Mozogtat(csiga3, csiga3mezony, sebessegek[kiMelyikSebessegetKapja[2]],csiga3_label);
            if (csiga1.Margin.Left == 930 && csiga2.Margin.Left == 930 && csiga3.Margin.Left == 930)
            {
                
                idozito.Stop();
                eredmenyek_btn.IsEnabled = true;
                ujbajnoksag_btn.IsEnabled = true;
                ujfutam_btn.IsEnabled = true;
            }
        }
        private static void Mozogtat(Rectangle csiganev, Rectangle csigamezony, double sebesseg, Label helyezesfelirat)
        {
            if (!helyezesek.Contains(csiganev)) {
                double currentLeft = csiganev.Margin.Left;
                double margintop = csiganev.Margin.Top;
                if (currentLeft + sebesseg < 930)
                {
                    csiganev.Margin = new Thickness(currentLeft += sebesseg, margintop, 0, 0);
                }
                else
                {
                    csiganev.Margin = new Thickness(930, margintop, 0, 0);
                    helyezesek.Add(csiganev);
                    int helyezes = helyezesek.FindIndex(x => x == csiganev);
                    switch (helyezes)
                    {
                        case 0:
                            csigamezony.Fill = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                            helyezesfelirat.Content = "1";
                            break;
                        case 1:
                            csigamezony.Fill = new SolidColorBrush(Color.FromRgb(211, 211, 211));
                            helyezesfelirat.Content = "2";
                            break;
                        case 2:
                            csigamezony.Fill = new SolidColorBrush(Color.FromRgb(169, 113, 66));
                            helyezesfelirat.Content = "3";
                            Pontszamito();
                            break;

                    }


                }
            }
        }
        private void Reset(Rectangle csiganev, Rectangle csigamezo,Label helyezesfelirat)
        {
            double currenttop = csiganev.Margin.Top;
            helyezesfelirat.Content = "";
            csiganev.Margin = new Thickness(10, currenttop, 0,0);
            csigamezo.Fill = new SolidColorBrush(Color.FromRgb(144, 238, 144));
            ujfutam_btn.IsEnabled = false;
            eredmenyek_btn.IsEnabled = false;
            ujbajnoksag_btn.IsEnabled = false;
            start_btn.IsEnabled = true;
            helyezesek.Clear();
            kiMelyikSebessegetKapja.Clear();
        }
        
        private void ujfutam_btn_Click(object sender, RoutedEventArgs e)
        {
            ujfutam_btn.IsEnabled = false;
            start_btn.IsEnabled = true;
            Reset(csiga1, csiga1mezony,csiga1_label);
            Reset(csiga2, csiga2mezony,csiga2_label);
            Reset(csiga3, csiga3mezony,csiga3_label);
        }

        private void eredmenyek_btn_Click(object sender, RoutedEventArgs e)
        {
            Window2 eredmeny = new Window2(elsoJatekos,masodikJatekos,harmadikJatekos);
            eredmeny.Show();
        }

        private void ujbajnoksag_btn_Click(object sender, RoutedEventArgs e)
        {
            Reset(csiga1, csiga1mezony, csiga1_label);
            Reset(csiga2, csiga2mezony, csiga2_label);
            Reset(csiga3, csiga3mezony, csiga3_label);
            Window2 eredmeny = new Window2(elsoJatekos, masodikJatekos, harmadikJatekos);
            eredmeny.felsoFelirat.Content = "Bajnokság végeredménye:";
            eredmeny.Show();


        }
       
        private void Turbo(object sender, MouseButtonEventArgs e)
        {
            if (start_btn.IsEnabled == false) { 
            Rectangle csiga = (Rectangle)sender;
            
            double currentMarginTop = csiga.Margin.Top;
            double currentLeft = csiga.Margin.Left;
            if(csiga.Margin.Left + 5 < 930) { 
            csiga.Margin = new Thickness(currentLeft += 5, currentMarginTop, 0, 0);
            }
            }
        }
    }
    public class Csiga
    {

        private int elso;
        private int masodik;
        private int harmadik;
        private int pontok;
        private string nev;

        public Csiga(string n)
        {

            elso = 0;
            masodik = 0;
            harmadik = 0;
            Nev = n;
            pontok = 0;

        }


        public int hanyszorVoltElso { get => elso; set => elso = value; }
        public int hanyszorVoltMasodik { get => masodik; set => masodik = value; }
        public int hanyszorVoltHarmadik { get => harmadik; set => harmadik = value; }
        public int pont { get => pontok; set => pontok = value; }
        public string Nev { get => nev; set => nev = value; }
    }
}
