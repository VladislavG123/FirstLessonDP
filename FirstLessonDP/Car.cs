using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLessonDP
{
    public class Car : IMovable
    {
        private Engine _engine;

        public Car(Engine engine)
        {
            _engine = engine;
        }

        public void Move()
        {
            Console.WriteLine("Машина едет");
        }
    }
}
