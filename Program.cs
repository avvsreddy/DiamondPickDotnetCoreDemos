using System;

namespace OOConceptsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NewHibridParser hp = new NewHibridParser();
            hp.Parser = new ABCParser();
            hp.Parse("small");
        }
    }

    abstract class GenericXMLParser
    {
        public abstract void Parse(string doc);
    }

    class DOMParser : GenericXMLParser
    {
        public override void Parse(string doc)
        {
            Console.WriteLine("Using DOM Parser");
        }
    }

    class SAXParser : GenericXMLParser
    {
        public override void Parse(string doc)
        {
            Console.WriteLine("Using SAX Parser");
        }
    }

    class MSParser : GenericXMLParser
    {
        public override void Parse(string doc)
        {
            Console.WriteLine("Using MS Parser");
        }
    }

    class ABCParser : GenericXMLParser
    {
        public override void Parse(string doc)
        {
            Console.WriteLine("Using ABC Parser");
        }
    }

    internal class HibridParser : DOMParser
    {
        //private SAXParser saxParser = new SAXParser();
        private MSParser msp = new MSParser();
        public override void Parse(string doc)
        {
            if (doc == "small")
                base.Parse(doc);
            else
                //saxParser.Parse(doc);
                msp.Parse(doc);
        }
    }

    class NewHibridParser : GenericXMLParser
    {
        public GenericXMLParser Parser { get; set; }
        private SAXParser saxParser = new SAXParser();
        public override void Parse(string doc)
        {
            if (doc == "small")
                Parser.Parse(doc);
            else
                saxParser.Parse(doc);
                
        }
    }
}
