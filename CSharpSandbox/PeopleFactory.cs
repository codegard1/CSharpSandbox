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
            public static void Main()
            {
                // Create and run the Straight Person world
                PersonFactory straight = new StraightFactory();
                PersonWorld world = new PersonWorld(straight);
                world.LoveIn();

                // Create and run the Gay Person world
                PersonFactory gay = new GayFactory();
                PersonWorld world1 = new PersonWorld(gay);
                world1.LoveIn();

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

        abstract class Person
        {
            public abstract void Love(Person p);
        }

        abstract class Male : Person
        {
            
        }

        abstract class Female : Person
        {
            
        }

        class GayMan : Male
        {
            private string s;

            public override void Love(Person p)
            {
                if (p.GetType() == this.GetType())
                {
                    s = " loves ";
                }
                else
                {
                    s = " does not love ";
                }
                Console.WriteLine(this.GetType().Name + s + p.GetType().Name);
            }
        }
        class StraightMan : Male
        {

            public override void Love(Person p)
            {
                Console.WriteLine(this.GetType().Name + " loves " + p.GetType().Name);
            }
        }

        class GayWoman : Female
        {
            private string s;

            public override void Love(Person p)
            {
                if (p.GetType() == this.GetType())
                {
                    s = " loves ";
                }
                else
                {
                    s = " does not love ";
                }
                Console.WriteLine(this.GetType().Name + s + p.GetType().Name);
            }
        }
        class StraightWoman : Female
        {

            public override void Love(Person p)
            {
                Console.WriteLine(this.GetType().Name + " loves " + p.GetType().Name);
            }
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


            public void LoveIn()
            {
                _male.Love(_female);
            }
        }
    }
}
