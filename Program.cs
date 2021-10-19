using System;
using System.Collections.Generic;

namespace TemplateMethod_Visitor
{
    #region Template Method

    abstract class Education
    {
        public void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }
        public abstract void Enter();
        public abstract void Study();
        public virtual void PassExams()
        {
            Console.WriteLine("Сдаем выпускные экзамены");
        }
        public abstract void GetDocument();
    }

    class School : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Идем в первый класс");
        }

        public override void Study()
        {
            Console.WriteLine("Посещаем уроки, делаем домашние задания");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Получаем аттестат о среднем образовании");
        }
    }

    class University : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Сдаем вступительные экзамены и поступаем в ВУЗ");
        }

        public override void Study()
        {
            Console.WriteLine("Посещаем лекции");
            Console.WriteLine("Проходим практику");
        }

        public override void PassExams()
        {
            Console.WriteLine("Сдаем экзамен по специальности");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Получаем диплом о высшем образовании");
        }
    }

    #endregion Template Method

    #region Visitor

    abstract class Visitor
    {
        public abstract void VisitElementA(ElementA elemA);
        public abstract void VisitElementB(ElementB elemB);
    }

    class ConcreteVisitor1 : Visitor
    {
        public override void VisitElementA(ElementA elementA)
        {
            elementA.OperationA();
        }
        public override void VisitElementB(ElementB elementB)
        {
            elementB.OperationB();
        }
    }
    class ConcreteVisitor2 : Visitor
    {
        public override void VisitElementA(ElementA elementA)
        {
            elementA.OperationA();
        }
        public override void VisitElementB(ElementB elementB)
        {
            elementB.OperationB();
        }
    }

    class ObjectStructure
    {
        List<Element> elements = new List<Element>();
        public void Add(Element element)
        {
            elements.Add(element);
        }
        public void Remove(Element element)
        {
            elements.Remove(element);
        }
        public void Accept(Visitor visitor)
        {
            foreach (Element element in elements)
                element.Accept(visitor);
        }
    }

    abstract class Element
    {
        public abstract void Accept(Visitor visitor);
        public string SomeState { get; set; }
    }

    class ElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElementA(this);
        }
        public void OperationA() { }
    }

    class ElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitElementB(this);
        }
        public void OperationB() { }
    }

    #endregion Visitor

    class Program
    {
        static void Main(string[] args)
        {
            #region Template Method

            School school = new School();
            University university = new University();

            school.Learn();
            university.Learn();

            Console.Read();

            #endregion Template Method

            #region Visitor

            var structure = new ObjectStructure();
            structure.Add(new ElementA());
            structure.Add(new ElementB());
            structure.Accept(new ConcreteVisitor1());
            structure.Accept(new ConcreteVisitor2());

            #endregion Visitor
        }
    }
}
