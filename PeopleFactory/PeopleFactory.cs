using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSandbox
{
    class PeopleFactory
    {
        class MainApp
        {
            static void Main()
            {
                Console.WriteLine("Hello, World!");

                // Wait for user input
                Console.ReadKey();
            }
        }
        

        abstract class PersonFactory
        {
            public abstract Male CreateMale();
            public abstract Female CreateFemale();
        }

        class GayFactory : PersonFactory
        {
            public override Male CreateMale()
            {
                return new GayMan();
            }
            public override Female CreateFemale()
            {
                return new GayWoman();
            }
        }
        class StraightFactory : PersonFactory
        {
            public override Male CreateMale()
            {
                return new StraightMan();
            }
            public override Female CreateFemale()
            {
                return new StraightWoman();
            }
        }

        abstract class Male
        {
            public abstract void Fuck(Female f);
        }
        abstract class Female
        {
            public abstract void Fuck(Male m);
        }

        class GayMan : Male
        {
            public override void Fuck(Male m)
            {
                // Fuck Men
                Console.WriteLine(this.GetType().Name + " fucks " + m.GetType().Name);
            }
        }
        class StraightMan : Male
        {

        }

        class GayWoman : Female
        {

        }
        class StraightWoman : Female
        {

        }

        class PersonWorld
        {
            private Male _male;
            private Female _female;

            // Constructor
            public PersonWorld(PersonFactory factory)
            {
                _male = factory.CreateMale();
                _female = factory.CreateFemale();
            }

            public void LetsFuck()
            {
                _male.Fuck(_female);
            }
        }
    }
}
