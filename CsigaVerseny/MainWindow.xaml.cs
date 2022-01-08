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
        static List<Rectangle> helyezesek = new List<Rectangle>();

        DispatcherTimer idozito = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
    
            idozito.Tick += new EventHandler(IdozitoEvent);
            idozito.Interval = new TimeSpan(0, 0, 0, 0, 6);
           
        }

        private void start_btn_Click(object sender, RoutedEventArgs e)
        {
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
            helyezesek.Clear();
            kiMelyikSebessegetKapja.Clear();
        }
        
        private void ujfutam_btn_Click(object sender, RoutedEventArgs e)
        {
            Reset(csiga1, csiga1mezony,csiga1_label);
            Reset(csiga2, csiga2mezony,csiga2_label);
            Reset(csiga3, csiga3mezony,csiga3_label);
        }
    }
}
