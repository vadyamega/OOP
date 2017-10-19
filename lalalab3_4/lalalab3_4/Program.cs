/*
 Создать класс типа -Дата с полями: день (1-31), месяц (1-12), год (целое число).
 \Свойстваустановки дня, месяца и годаи конструкторы должны проверять корректно
 сть задаваемых значений. Добавить методы печатипо шаблону:“5 января 2018года” и
 “05/01/2018”.Создать массив объектов. Вывести:a)  список дат для заданного года;
 b)  список дат, которыеимеют заданное число;
*/

/* 1)Определить класс, указанный в варианте, содержащий:
 * Не менее трех конструкторов(с параметрамии без, а также с параметрами по 
 * умолчанию);статический конструктор(конструктор типа);
 * определите закрытый конструктор; предложите варианты его вызова;
 * поле -только для чтения(например, для каждого экземпляра сделайте 
 * поле только для чтенияID-равнонекоторому уникальному номеру (хэшу) 
 * вычисляемому автоматически на основе инициализаторов объекта);
 * поле-константу;свойства(get, set) –для всех полекласса
 * (поля класса должны быть закрытыми);Для одного из свойств ограните 
 * доступ по setводном из методовклассадля работы с аргументами используйте
 * ref -и out-параметры.создайте в классе статическое поле, хранящее 
 * количество созданных объектов (инкрементируется в конструкторе) и статический
 * методвывода информации о классе.сделайте класс partialпереопределяете 
 * методыкласса Object: Equals, для сравнения объектов,GetHashCode; 
 * для алгоритма вычисления хэша руководствуйтесь стандартными рекомендациями, 
 * ToString –вывода строки –информации об объекте.2)Создайте несколько объектов
 * вашего типа. Выполните вызов конструкторов, свойств, методов,
 * сравнение объекты, проверьте тип созданного объекта и т.п. 3)
 * Создайте массив объектов вашего типа.И выполните задание, выделенное курсивом
 * в таблице.4)Создайте и выведите анонимный тип(по образцу вашего класса)
 */
using System;

namespace lalalab3_4
{
    public partial class MyData
    {
        public static int count;
        private int day;
        public int Day 
        {
            get { return this.day; }
            private set {this.day = value;}
        }
        public int month;
		public int Month
		{
			get { return this.month; }
			private set { this.month = value; }
		}
        public int year;
		public int Year
		{
			get { return this.year; }
			private set { this.year = value; }
		}
        public readonly string string_date;
        public const string kto_soset = "Bui soset";

        private MyData(int day)
        {
            Console.WriteLine("Вызван закрытый конструктор");
        }

        public static void Swap(ref int n1, ref int n2){
            int temp = n2;
            n2 = n1;
            n1 = temp;
        }

        public MyData() 
        {
            this.day = 1;
            this.month = 1;
            this.year = 1000;
            this.string_date = this.day + "." + this.month + "." + this.year;
            count += 1;
        }

        public MyData(int day = 1, int month = 1, int year = 1000)
        {
            if ((day > 31) || (day <1))
            {
                Console.WriteLine("SOSI");
                throw (new Exception("sosi"));
            }
			if ((month > 31) || (month < 1))
			{
				Console.WriteLine("SOSI");
				throw (new Exception("sosi"));
			}

            this.day = day;
            this.month = month;
			this.year = year;
			this.string_date = this.day + "." + this.month + "." + this.year;
            count += 1;
        }

        public MyData(MyData data)
        {
            this.day = data.Day;
            this.month = data.Month;
			this.year = data.Year;
			this.string_date = this.day + "." + this.month + "." + this.year;
            count += 1;
        }

        public static string GetStatistics()
        {
            string res = "Количество созданных объектов класса: " + count;
            return res;
        }

        static MyData()
        {
            Console.WriteLine("Byi Sosi");
            count = 0;
        }
    }

    public partial class MyData
    {

        public override bool Equals(System.Object obj)
        {
            if (obj.GetType().ToString().Equals("lalalab3_4.MyData"))
            {
                MyData data_obj = obj as MyData;
                if ((this.Day == data_obj.Day)
                   & (this.Month == data_obj.Month)
                   & (this.Year == data_obj.Year)) return true;
                else return false;
            }
            else 
            {
                Console.WriteLine("Types are not same");
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ (this.Day +this.Month + this.Year);
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}/{2}", Day, Month, Year);
        }

        public string BeautifulView()
        {
            string[] month_names = new string[] {
                "января",
                "февраля",
                "марта",
                "апреля",
                "мая",
                "июня",
                "июля",
                "августа",
                "сентября",
                "октября",
                "ноября",
                "декабря"
            };

            return string.Format("{0} {1} {2} года", Day, month_names[Month - 1], Year);
        }
    }


    class MainClass
    {
        public static void Main(string[] args)
        {
            MyData data1 = new MyData();
            MyData data2 = new MyData(15, 10, 2015);
            MyData data3 = new MyData(data2);
            // разкомментить для появления ошибки
           //MyData SosiData = new MyData(58, 10, 2015);

            Console.WriteLine(data3.string_date);

            int a = 1;
            int b = 2;

            MyData.Swap(ref a, ref b);
            Console.WriteLine(a+" "+b);
            Console.WriteLine(MyData.GetStatistics());

            Console.WriteLine(data1.GetType());
            Console.WriteLine("data2 == data3: "+data2.Equals(data3));
			Console.WriteLine("data2 hash: " + data2.GetHashCode());
            Console.WriteLine("data3 hash: " + data3.GetHashCode());

            Console.WriteLine(data1);
            Console.WriteLine(data2.BeautifulView());

            // работа с массивом 
			MyData d1 = new MyData(11, 10, 2007);
            MyData d2 = new MyData(10, 10, 2015);
            MyData d3 = new MyData(11, 9, 2001);
            MyData d4 = new MyData(1, 9, 1939);
            MyData d5 = new MyData(1, 6, 2007);
            MyData d6 = new MyData(11, 9, 2016);
            MyData d7 = new MyData(8, 12, 1998);

            MyData[] data_array = new MyData[] { d1, d2, d3, d4, d5, d6, d7 };

            Console.WriteLine();
            Console.WriteLine("Даты с 2007 годом: ");
            for (int i = 0; i < data_array.Length; i++)
            {
                if (data_array[i].Year == 2007)
                {
                    Console.WriteLine(data_array[i].BeautifulView());
                }
            }

            Console.WriteLine();
			Console.WriteLine("Даты с 11 числом: ");
			for (int i = 0; i < data_array.Length; i++)
			{
				if (data_array[i].Day == 11)
				{
					Console.WriteLine(data_array[i].BeautifulView());
				}
			}


            Console.WriteLine();
            Console.WriteLine("Анонимный тип: ");
            var anon_type = new { a = 5, b = 5 };

            Console.WriteLine(anon_type);
        }
    }
}
