using System.Globalization;
using System.Security.Permissions;
using NUnit.Framework;

namespace ObjectPrinting.Tests
{
    [TestFixture]
    public class ObjectPrinterAcceptanceTests
    {
        [Test]
        public void Demo()
        {
            var person = new Person {Name = "Alex", Age = 19};

            //1. Исключить из сериализации свойства определенного типа
            var printer = ObjectPrinter.For<Person>()
                .Exclude<double>()
                //2. Указать альтернативный способ сериализации для определенного типа
                .Printing<int>().Using(num => num.ToString())
                //3. Для числовых типов указать культуру
                .Printing<int>().ChangeCulture(CultureInfo.CurrentCulture);
            //4. Настроить сериализацию конкретного свойства
            //5. Настроить обрезание строковых свойств (метод должен быть виден только для строковых свойств)
            //6. Исключить из сериализации конкретного свойства

            string s1 = printer.PrintToString(person);

            //7. Синтаксический сахар в виде метода расширения, сериализующего по-умолчанию        
            //8. ...с конфигурированием
        }
    }
}