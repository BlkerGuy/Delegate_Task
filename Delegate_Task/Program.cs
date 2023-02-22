using System;
using System.Collections.Generic;

namespace Delegate_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Exam> Exams = new List<Exam>();

            Exam exam = new Exam()
            {
                Subject = "Programing Quiz 1",
                startedAt = Convert.ToDateTime("20/02/2023 09:13"),
                FinishedAt = Convert.ToDateTime("20/02/2023 10:11")
            };
            Exams.Add(exam);
            Exam exam2 = new Exam()
            {
                Subject = "Programing Quiz 2",
                startedAt = Convert.ToDateTime("23/02/2023 09:05"),
                FinishedAt = Convert.ToDateTime("23/02/2023 10:00")
            };

            Exam exam5 = new Exam()
            {
                Subject = "Programming",
                startedAt = Convert.ToDateTime("23/02/2022 08:05"),
                FinishedAt = Convert.ToDateTime("23/02/2022 10:00")
            };

            Exams.Add(exam5);

            Exam exam3 = new Exam()
            {
                Subject = "Programing Project 1",
                startedAt = Convert.ToDateTime("16/02/2023 12:33"),
                FinishedAt = Convert.ToDateTime("20/02/2023 07:00")
            };
            Exams.Add(exam3);
            Exam exam4 = new Exam()
            {
                Subject = "Programing Project 2",
                startedAt = Convert.ToDateTime("25/02/2023 12:33"),
                FinishedAt = Convert.ToDateTime("26/02/2023 07:00")
            };
            Exams.Add(exam4);



            string opt;
            do
            {
                Console.WriteLine("1. 2 saatdan az cekmis imtahanlarin sayi.");
                Console.WriteLine("2. son 24 saatda bas verecek (hele baslamamis) imtahanlarin Subject ve StartedAt deyerlerini gosterin.");
                Console.WriteLine("3. Bu gun erzinde bas verecek (hele baslamamis ilk imtahan datasini gostermek)");
                Console.WriteLine("4. Kecen il bas vermis imtahanlar icersinde hec Programming imtahani olubmu yoxsa olmayibmi bunu gosterin.");
                Console.WriteLine("0. Cixis et.");
                Console.WriteLine("\nSecim edin:");
                opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        byte shortofTwohoursExamCount = 0;
                        foreach (var item in Exams)
                        {
                            //var NeedTime = item.FinishedAt -item.startedAt;
                            var needTIme = item.FinishedAt.Subtract(item.startedAt);
                            if (needTIme < new TimeSpan(02, 00, 00))
                            {
                                shortofTwohoursExamCount++;
                            }
                        }
                        if (shortofTwohoursExamCount > 0)
                            Console.WriteLine($"2 saatdan az cekmis imtahanlarin sayi: {shortofTwohoursExamCount}\n");
                        else Console.WriteLine("Hec bir netice tapilmadi:\a\n");
                        break;
                    case "2":
                        byte count = 0;
                        foreach (var item in Exams)
                        {
                            var needTIme = item.FinishedAt.Subtract(item.startedAt);
                            if (needTIme < new TimeSpan(24, 00, 00) && needTIme > DateTime.Now.TimeOfDay)
                            {
                                count++;
                                Console.WriteLine($"Subject: {item.Subject}  StartAt: {item.startedAt}");

                            }

                        }
                        if (count == 0)
                            Console.WriteLine("Son 24 saatda bas verecek, hec bir imtahan tarixi tapilmadi.");
                        break;
                    case "3":

                        count = 0;
                        TimeSpan set = new TimeSpan();
                        List<Exam> examForToday = new List<Exam>();
                        foreach (var item in Exams)
                        {
                            if (item.startedAt > DateTime.Now && item.FinishedAt > DateTime.Now)
                            {
                                var firstExamToDay = item.startedAt.Subtract(DateTime.Now);
                                if (set == new TimeSpan(00, 00, 00))
                                {
                                    set = firstExamToDay;
                                    examForToday.Add(new Exam { Subject = item.Subject, startedAt = item.startedAt, FinishedAt = item.FinishedAt });
                                }
                                if (firstExamToDay < set)
                                {
                                    examForToday.Clear();
                                    examForToday.Add(new Exam { Subject = item.Subject, startedAt = item.startedAt, FinishedAt = item.FinishedAt });
                                }
                            }
                            count++;
                        }
                        if (Exams.Count == count)
                            foreach (var item in examForToday)
                                Console.WriteLine($"Subject: {item.Subject}  StartAt: {item.startedAt} EndAt: {item.FinishedAt}");
                        else Console.WriteLine("Hec bir netice tapilmadi.");


                        break;
                    case "4":
                         count = 0;
                        foreach (var item in Exams)
                        {
                            //var needTIme = item.FinishedAt - item.startedAt;
                            if (item.startedAt.Year <DateTime.Now.Year && item.FinishedAt.Year < DateTime.Now.Year)
                            {
                                if ("Programming".ToLower().Contains(item.Subject.ToLower()))
                                {
                                    count++;
                                    Console.WriteLine("Olub");
                                    Console.WriteLine($"Subject: {item.Subject}  StartAt: {item.startedAt} EndAt: {item.FinishedAt}");
                                }
                            }
                        }
                        if (count == 0)
                            Console.WriteLine("Hec bir imtahan tarixi tapilmadi.");
                        break;
                    default:
                        break;
                }
            } while (opt != "0");


















        }
    }
}
