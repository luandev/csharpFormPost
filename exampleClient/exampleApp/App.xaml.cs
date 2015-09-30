using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace testPutDataWebservice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            method();
            Console.ReadLine();
            Application.Current.Shutdown();

        }


        public async void method()
        {
            List<field> campos = new List<field>()
            {
                new field("C:/Users/luan/Pictures/wall1.png", "image"),
            };


            while(true)
            {
                string s = await post.send(campos, "http://localhost/teste/teste");
                Console.WriteLine(s);
            }
    
        }


      


    }
}
