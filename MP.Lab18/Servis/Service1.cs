using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Servis
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        public void DoWork()
        {
        }

        public int Add(int a, int b)
        {
            Console.WriteLine("Add was called for {0},{1}",a,b);
            return a + b;
        }

        public int Mult(int a, int b)
        {
            return a * b;
        }

        public int Sub(SubData data)
        {
            Console.WriteLine("Sub was called for {0} and {1}. ", data.A, data.B);
            return data.A - data.B;
        }

        public DivOutputMessage Div(DivInputMessage message)
        {
            Console.WriteLine("Div was called for {0}, {1}", message.A, message.B);
            Console.WriteLine("Header : {0}", message.Header);
            DivOutputMessage outputMessage = new DivOutputMessage();
            if (message.B == 0)
            {
                outputMessage.Header = "Division by zero!";
            }
            else
            {
                outputMessage.Header = "OK";
                outputMessage.Result = message.A/message.B;
            }

            return outputMessage;
        }

        public List<Line> PDSK()
        {
            List<Line> coords = new List<Line>();
            var mLine = new Line();
            mLine.Stroke = Brushes.Black;
            mLine.X1 = 20;
            mLine.X2 = 20;
            mLine.Y1 = 40;
            mLine.Y2 = 330;
            mLine.HorizontalAlignment = HorizontalAlignment.Left;
            mLine.VerticalAlignment = VerticalAlignment.Center;
            mLine.StrokeThickness = 2;
            var mLine1 = new Line();
            mLine1.Stroke = Brushes.Black;
            mLine1.X1 = 20;
            mLine1.X2 = 400;
            mLine1.Y1 = 330;
            mLine1.Y2 = 330;
            mLine1.HorizontalAlignment = HorizontalAlignment.Left;
            mLine1.VerticalAlignment = VerticalAlignment.Center;
            mLine1.StrokeThickness = 1;
            coords.Add(mLine);
            coords.Add(mLine1);

            for (int i = 0; i < 6; i++)
            {
                var r = new Line();
                r.Stroke = Brushes.Black;
                r.X1 = 20;
                r.X2 = 23;
                r.Y1 = 330 - i * 50;
                r.Y2 = 330 - i * 50;
                var k = new Line();
                k.Stroke = Brushes.Black;
                k.X1 = 20 + i * 50;
                k.X2 = 20 + i * 50;
                k.Y1 = 330;
                k.Y2 = 328;
                coords.Add(k);
                coords.Add(r);
            }
            return coords;
        }
    }
}
