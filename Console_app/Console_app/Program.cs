using System.Runtime.InteropServices;

namespace Console_app
{
    internal class Program
    {
       static List<Group> groups = new List<Group>();
       public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Yeni qrup yarat");
                Console.WriteLine("2. Qruplarin siyahisini goster");
                Console.WriteLine("3. Qrup uzerinde duzelis et");
                Console.WriteLine("4. Qrupdaki telebelerin siyahisini goster");
                Console.WriteLine("5. Butun telebelerin siyahisini goster");
                Console.WriteLine("6. Telebe yarat");
                Console.WriteLine("0. Cixis et");


                Console.Write("Secim edin: ");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        {
                            CreateGroup();
                            break;
                        }
                    case "2":
                        {
                            ShowGroups();
                            break;
                        }
                    case "3":
                        {
                            EditGroup();
                            break;
                        }
                    case "4":
                        {
                            ShowStudentsInGroup();
                            break;
                        }
                    case "5":
                        {
                            ShowAllStudents();
                            break;
                        }
                    case "6":
                        {
                            CreateStudent();
                            break;
                        }
                    case "0":
                        {
                            Console.WriteLine("Cixis etdiniz");
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Duzgun secim daxil  edin");
                            break;
                        }


                }
                
                

            }
            
            
        }
        public static void CreateGroup()
        {
            Console.WriteLine("Qrup nomresi daxil edin :");
            string no = Console.ReadLine();
            if (groups.Any(g => g.NO == no))
            {
                Console.WriteLine("Bu qrup artiq movcuddur");
                return;
            }
            Console.WriteLine("zehmet olmasa bu kategoriyalardan birini yazin : ");
            Console.WriteLine("Category ---- (programming, design, system administration)");
            string category = Console.ReadLine();
            if (category != "programming" && category != "design" && category != "system administration")
            {
                Console.WriteLine("Duzgun kategoriya daxil edin");
                return;
            }
            Console.WriteLine("Qrupun online olub olmadigini daxil edin (true/false) :");
            string isOnlineStr = Console.ReadLine();

            Group group = new Group();
            group.NO = no;
            group.Category = category;
            group.IsOnline = bool.Parse(isOnlineStr);
            groups.Add(group);
            Console.WriteLine("Qrup yaradildi");
        }
        public static void ShowGroups()
        {
            if (groups.Count == 0)
            {
                Console.WriteLine("Heç bir qrup yoxdur");
                return;
            }
            foreach (var group in groups)
            {
                Console.WriteLine($"Qrup nomresi : {group.NO} , Kategoriya : {group.Category} , Online : {group.IsOnline}");
            }
        }
        public static void EditGroup()
        {
            Console.WriteLine("Duzelis etmek istediyiniz qrupun nomresini daxil edin :");
            string no = Console.ReadLine();
            foreach (var group in groups)
            {
                if (group.NO == no)
                {
                    Console.WriteLine("Yeni Qrup nomresini daxil edin :");
                    string newNo = Console.ReadLine();

                    if (groups.Any(g => g.NO == newNo))
                    {
                        Console.WriteLine("Bu qrup artiq movcuddur");
                        return;
                    }
                    group.NO = newNo;
                    Console.WriteLine("Qrup nomresi duzelis edildi");
                    return;
                }
                else
                {
                    Console.WriteLine("Bu qrup movcud deyil");
                    return;
                }
            }


        }
        public static void ShowStudentsInGroup()
        {
            Console.WriteLine("hansi qrupdaki telebeleri gormek isteyirsizse o qrupun nomresini daxil edin :");
            string no = Console.ReadLine();
            if(groups.Count == 0)
            {
                Console.WriteLine("Heç bir qrup yoxdur");
                return;
            }
                groups.Find(g => g.NO == no).students.ForEach(s => Console.WriteLine($"Ad: {s.Name}, Soyad: {s.Surname}, Qrup nomresi: {s.GroupNO}"));

        }
        public static void ShowAllStudents()
        {
            if (groups.Count == 0)
            {
                Console.WriteLine("Heç bir qrup yoxdur");
                return;
            }
            foreach (var group in groups)
            {
                group.students.ForEach(s => Console.WriteLine($"Ad: {s.Name}, Soyad: {s.Surname}, Qrup nomresi: {s.GroupNO}"));
            }
        }
        public static void CreateStudent()
        {
            Console.WriteLine("Telebe adini daxil edin :");
            string name = Console.ReadLine();
            Console.WriteLine("Telebe soyadini daxil edin :");
            string surname = Console.ReadLine();
            Console.WriteLine("Telebe qrup nomresini daxil edin :");
            string groupNo = Console.ReadLine();
            Console.WriteLine("telebe tipi zemanetli/zemanetsiz");
            string groupType = Console.ReadLine();

            Group group = groups.Find(g => g.NO == groupNo);
            if (group == null)
            {
                Console.WriteLine("Bu qrup movcud deyil");
                return;
            }
            if (group.students.Count >= group.limit)
            {
                Console.WriteLine("Bu qrupda telebe sayi dolub");
                return;
            }
            Student student = new Student();
            student.Name = name;
            student.Surname = surname;
            student.GroupNO = groupNo;
            student.Type = groupType;
            group.students.Add(student);
            Console.WriteLine("Telebe yaradildi");
        }
      
    }
}
