using System;
using System.Collections.Generic;
using System.Linq;

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class Unemployed : Person
    {
        public int Age { get; set; }
        public string Education { get; set; }
        public string PreviousJob { get; set; }
    }

    class Customer : Person
    {
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    class JobPosting
    {
        public string Title { get; set; }
        public string Category { get; set; }
    }

    class Vacancy : JobPosting
    {
        public string Description { get; set; }
    }

    class Resume : JobPosting
    {
        public string Name { get; set; } 

        public string Experience { get; set; }
        public List<string> Skills { get; set; }
    }

    class Manager
    {
        public List<Unemployed> Unemployeds { get; private set; }

        public Manager()
        {
            Unemployeds = new List<Unemployed>();
        }

        public void AddUnemployed(Unemployed unemployed)
        {
            Unemployeds.Add(unemployed);
        }

        public void RemoveUnemployed(string firstName, string lastName)
        {
            Unemployeds.RemoveAll(u => u.FirstName == firstName && u.LastName == lastName);
        }

        public void UpdateUnemployed(string firstName, string lastName, Unemployed updatedUnemployed)
        {
            var unemployedToUpdate = Unemployeds.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName);
            if (unemployedToUpdate != null)
            {
                unemployedToUpdate.FirstName = updatedUnemployed.FirstName;
                unemployedToUpdate.LastName = updatedUnemployed.LastName;
                unemployedToUpdate.Age = updatedUnemployed.Age;
                unemployedToUpdate.Education = updatedUnemployed.Education;
                unemployedToUpdate.PreviousJob = updatedUnemployed.PreviousJob;
            }
            else
            {
                Console.WriteLine("Безробітний не знайдений.");
            }
        }

        public void DisplayUnemployedDetails(string firstName, string lastName)
        {
            var unemployed = Unemployeds.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName);
            if (unemployed != null)
            {
                Console.WriteLine($"Ім'я: {unemployed.FirstName}");
                Console.WriteLine($"Прізвище: {unemployed.LastName}");
                Console.WriteLine($"Вік: {unemployed.Age}");
                Console.WriteLine($"Освіта: {unemployed.Education}");
                Console.WriteLine($"Попередня робота: {unemployed.PreviousJob}");
            }
            else
            {
                Console.WriteLine("Безробітний не знайдений.");
            }
        }

        public void DisplayAllUnemployeds()
        {
            Console.WriteLine("Список всіх безробітних:");
            foreach (var unemployed in Unemployeds)
            {
                Console.WriteLine($"{unemployed.FirstName} {unemployed.LastName}");
            }
        }

        public void SortUnemployedsByName()
        {
            var sortedUnemployeds = Unemployeds.OrderBy(u => u.FirstName);
            Console.WriteLine("Відсортований список безробітних за іменем:");
            foreach (var unemployed in sortedUnemployeds)
            {
                Console.WriteLine($"{unemployed.FirstName} {unemployed.LastName}");
            }
        }

        public void SortUnemployedsByLastName()
        {
            var sortedUnemployeds = Unemployeds.OrderBy(u => u.LastName);
            Console.WriteLine("Відсортований список безробітних за прізвищем:");
            foreach (var unemployed in sortedUnemployeds)
            {
                Console.WriteLine($"{unemployed.LastName} {unemployed.FirstName}");
            }
        }

        public void SearchUnemployeds(string keyword)
        {
            var matchingUnemployeds = Unemployeds.Where(u => u.FirstName.Contains(keyword) || u.LastName.Contains(keyword) || u.Education.Contains(keyword) || u.PreviousJob.Contains(keyword));
            Console.WriteLine($"Результати пошуку за ключовим словом '{keyword}' у безробітних:");
            foreach (var unemployed in matchingUnemployeds)
            {
                Console.WriteLine($"Ім'я: {unemployed.FirstName}, Прізвище: {unemployed.LastName}, Вік: {unemployed.Age}, Освіта: {unemployed.Education}, Попередня робота: {unemployed.PreviousJob}");
            }
        }
    }

    class DataManager
    {
        public List<Vacancy> Vacancies { get; private set; }
        public List<Resume> Resumes { get; private set; }

        public DataManager()
        {
            Vacancies = new List<Vacancy>();
            Resumes = new List<Resume>();
        }

        public void AddVacancy(Vacancy vacancy)
        {
            Vacancies.Add(vacancy);
        }

        public void RemoveVacancy(string title)
        {
            Vacancies.RemoveAll(v => v.Title == title);
        }

        public void DisplaySortedVacancies()
        {
            var sortedVacancies = Vacancies.OrderBy(v => v.Title);
            foreach (var vacancy in sortedVacancies)
            {
                Console.WriteLine(vacancy.Title);
            }
        }

        public void DisplayAllVacancies()
        {
            Console.WriteLine("Усі вакансії:");
            foreach (var vacancy in Vacancies)
            {
                Console.WriteLine($"Назва: {vacancy.Title}, Опис: {vacancy.Description}, Категорія: {vacancy.Category}");
            }
        }

        public void UpdateVacancy(string title, Vacancy updatedVacancy)
        {
            var vacancyToUpdate = Vacancies.FirstOrDefault(v => v.Title == title);//використовується для перевірки кожного
                                                                                  //елемента в колекції Vacancies на відповідність умові v.Title == title
            if (vacancyToUpdate != null)
            {
                vacancyToUpdate.Title = updatedVacancy.Title;
                vacancyToUpdate.Description = updatedVacancy.Description;
                vacancyToUpdate.Category = updatedVacancy.Category;
            }
            else
            {
                Console.WriteLine("Вакансія не знайдена.");
            }
        }

        public void DisplayVacancyDetails(string title)
        {
            var vacancy = Vacancies.FirstOrDefault(v => v.Title == title);
            if (vacancy != null)
            {
                Console.WriteLine($"Назва: {vacancy.Title}");
                Console.WriteLine($"Опис: {vacancy.Description}");
                Console.WriteLine($"Категорія: {vacancy.Category}");
            }
            else
            {
                Console.WriteLine("Вакансія не знайдена.");
            }
        }

        public void AddResume(Resume resume)
        {
            Resumes.Add(resume);
        }

        public void RemoveResume(string name)
        {
            Resumes.RemoveAll(r => r.Name == name);
        }

        public void DisplaySortedResumes()
        {
            var sortedResumes = Resumes.OrderBy(r => r.Name);
            foreach (var resume in sortedResumes)
            {
                Console.WriteLine(resume.Name);
            }
        }

        public void DisplayAllResumes()
        {
            Console.WriteLine("Усі резюме:");
            foreach (var resume in Resumes)
            {
                Console.WriteLine($"Ім'я: {resume.Name}, Досвід: {resume.Experience}, Навички: {string.Join(", ", resume.Skills)}, Категорія: {resume.Category}");
            }
        }

        public void UpdateResume(string name, Resume updatedResume)
        {
            var resumeToUpdate = Resumes.FirstOrDefault(r => r.Name == name);
            if (resumeToUpdate != null)
            {
                resumeToUpdate.Name = updatedResume.Name;
                resumeToUpdate.Experience = updatedResume.Experience;
                resumeToUpdate.Skills = updatedResume.Skills;
                resumeToUpdate.Category = updatedResume.Category;
            }
            else
            {
                Console.WriteLine("Резюме не знайдено.");
            }
        }

        public void DisplayResumeDetails(string name)
        {
            var resume = Resumes.FirstOrDefault(r => r.Name == name);
            if (resume != null)
            {
                Console.WriteLine($"Ім'я: {resume.Name}");
                Console.WriteLine($"Досвід: {resume.Experience}");
                Console.WriteLine($"Навички: {string.Join(", ", resume.Skills)}");
                Console.WriteLine($"Категорія: {resume.Category}");
            }
            else
            {
                Console.WriteLine("Резюме не знайдено.");
            }
        }

        public void SearchVacancies(string keyword)
        {
            var matchingVacancies = Vacancies.Where(v => v.Title.Contains(keyword) || v.Description.Contains(keyword) || v.Category.Contains(keyword));
            Console.WriteLine($"Результати пошуку за ключовим словом '{keyword}' у вакансіях:");
            foreach (var vacancy in matchingVacancies)
            {
                Console.WriteLine($"Назва: {vacancy.Title}, Опис: {vacancy.Description}, Категорія: {vacancy.Category}");
            }
        }

        public void SearchResumes(string keyword)
        {
            var matchingResumes = Resumes.Where(r => r.Name.Contains(keyword) || r.Experience.Contains(keyword) || r.Skills.Any(s => s.Contains(keyword)) || r.Category.Contains(keyword));
            Console.WriteLine($"Результати пошуку за ключовим словом '{keyword}' у резюме:");
            foreach (var resume in matchingResumes)
            {
                Console.WriteLine($"Ім'я: {resume.Name}, Досвід: {resume.Experience}, Навички: {string.Join(", ", resume.Skills)}, Категорія: {resume.Category}");
            }
        }
    }

    class CustomerManager
    {
        public List<Customer> Customers { get; private set; }

        public CustomerManager()
        {
            Customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public void RemoveCustomer(string firstName, string lastName)
        {
            Customers.RemoveAll(c => c.FirstName == firstName && c.LastName == lastName);
        }

        public void UpdateCustomer(string firstName, string lastName, Customer updatedCustomer)
        {
            var customerToUpdate = Customers.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
            if (customerToUpdate != null)
            {
                customerToUpdate.FirstName = updatedCustomer.FirstName;
                customerToUpdate.LastName = updatedCustomer.LastName;
                customerToUpdate.Company = updatedCustomer.Company;
                customerToUpdate.Email = updatedCustomer.Email;
                customerToUpdate.Phone = updatedCustomer.Phone;
            }
            else
            {
                Console.WriteLine("Замовник не знайдений.");
            }
        }

        public void DisplayCustomerDetails(string firstName, string lastName)
        {
            var customer = Customers.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
            if (customer != null)
            {
                Console.WriteLine($"Ім'я: {customer.FirstName}");
                Console.WriteLine($"Прізвище: {customer.LastName}");
                Console.WriteLine($"Компанія: {customer.Company}");
                Console.WriteLine($"Електронна пошта: {customer.Email}");
                Console.WriteLine($"Телефон: {customer.Phone}");
            }
            else
            {
                Console.WriteLine("Замовник не знайдений.");
            }
        }

        public void DisplayAllCustomers()
        {
            Console.WriteLine("Список всіх замовників:");
            foreach (var customer in Customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            }
        }

        public void SortCustomersByName()
        {
            var sortedCustomers = Customers.OrderBy(c => c.FirstName);
            Console.WriteLine("Відсортований список замовників за іменем:");
            foreach (var customer in sortedCustomers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            }
        }

        public void SortCustomersByLastName()
        {
            var sortedCustomers = Customers.OrderBy(c => c.LastName);
            Console.WriteLine("Відсортований список замовників за прізвищем:");
            foreach (var customer in sortedCustomers)
            {
                Console.WriteLine($"{customer.LastName} {customer.FirstName}");
            }
        }
    }


class Program
{
    static void Main(string[] args)
    {
        DataManager dataManager = new DataManager();
        Manager Managers = new Manager();
        CustomerManager customerManager = new CustomerManager();


        while (true)
        {
        FirstMenu:
            Console.WriteLine("\nОберіть опцію:");
            Console.WriteLine("1. Додати вакансію");
            Console.WriteLine("2. Видалити вакансію");
            Console.WriteLine("3. Відобразити відсортовані вакансії");
            Console.WriteLine("4. Відобразити всі вакансії");
            Console.WriteLine("5. Оновити вакансію");
            Console.WriteLine("6. Переглянути деталі вакансії");
            Console.WriteLine("7. Додати резюме");
            Console.WriteLine("8. Видалити резюме");
            Console.WriteLine("9. Відобразити відсортовані резюме");
            Console.WriteLine("10. Відобразити всі резюме");
            Console.WriteLine("11. Оновити резюме");
            Console.WriteLine("12. Переглянути деталі резюме");
            Console.WriteLine("13. Вийти");

            Console.WriteLine("14. Наступна сторінка");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Неправильне введення. Будь ласка, введіть число.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введіть назву вакансії:");
                    string vacancyTitle = Console.ReadLine();
                    Console.WriteLine("Введіть опис вакансії:");
                    string vacancyDescription = Console.ReadLine();
                    Console.WriteLine("Введіть категорію вакансії:");
                    string vacancyCategory = Console.ReadLine();
                    dataManager.AddVacancy(new Vacancy { Title = vacancyTitle, Description = vacancyDescription, Category = vacancyCategory });
                    break;
                case 2:
                    Console.WriteLine("Введіть назву вакансії для видалення:");
                    string titleToRemove = Console.ReadLine();
                    dataManager.RemoveVacancy(titleToRemove);
                    break;
                case 3:
                    Console.WriteLine("Відсортовані вакансії:");
                    dataManager.DisplaySortedVacancies();
                    break;
                case 4:
                    dataManager.DisplayAllVacancies();
                    break;
                case 5:
                    Console.WriteLine("Введіть назву вакансії для оновлення:");
                    string titleToUpdate = Console.ReadLine();
                    Console.WriteLine("Введіть оновлену назву вакансії:");
                    string updatedVacancyTitle = Console.ReadLine();
                    Console.WriteLine("Введіть оновлений опис вакансії:");
                    string updatedVacancyDescription = Console.ReadLine();
                    Console.WriteLine("Введіть оновлену категорію вакансії:");
                    string updatedVacancyCategory = Console.ReadLine();
                    dataManager.UpdateVacancy(titleToUpdate, new Vacancy { Title = updatedVacancyTitle, Description = updatedVacancyDescription, Category = updatedVacancyCategory });
                    break;
                case 6:
                    Console.WriteLine("Введіть назву вакансії для перегляду деталей:");
                    string vacancyTitleToView = Console.ReadLine();
                    dataManager.DisplayVacancyDetails(vacancyTitleToView);
                    break;
                case 7:
                    Console.WriteLine("Введіть ім'я резюме:");
                    string resumeName = Console.ReadLine();
                    Console.WriteLine("Введіть досвід резюме:");
                    string resumeExperience = Console.ReadLine();
                    Console.WriteLine("Введіть навички резюме (розділені комами):");
                    string[] skills = Console.ReadLine().Split(',');
                    Console.WriteLine("Введіть категорію резюме:");
                    string resumeCategory = Console.ReadLine();
                    dataManager.AddResume(new Resume { Name = resumeName, Experience = resumeExperience, Skills = skills.ToList(), Category = resumeCategory });
                    break;
                case 8:
                    Console.WriteLine("Введіть ім'я резюме для видалення:");
                    string nameToRemove = Console.ReadLine();
                    dataManager.RemoveResume(nameToRemove);
                    break;
                case 9:
                    Console.WriteLine("Відсортовані резюме:");
                    dataManager.DisplaySortedResumes();
                    break;
                case 10:
                    dataManager.DisplayAllResumes();
                    break;
                case 11:
                    Console.WriteLine("Введіть ім'я резюме для оновлення:");
                    string nameToUpdate = Console.ReadLine();
                    Console.WriteLine("Введіть оновлене ім'я резюме:");
                    string updatedResumeName = Console.ReadLine();
                    Console.WriteLine("Введіть оновлений досвід резюме:");
                    string updatedResumeExperience = Console.ReadLine();
                    Console.WriteLine("Введіть оновлені навички резюме (розділені комами):");
                    string[] updatedSkills = Console.ReadLine().Split(',');
                    Console.WriteLine("Введіть оновлену категорію резюме:");
                    string updatedResumeCategory = Console.ReadLine();
                    dataManager.UpdateResume(nameToUpdate, new Resume { Name = updatedResumeName, Experience = updatedResumeExperience, Skills = updatedSkills.ToList(), Category = updatedResumeCategory });
                    break;
                case 12:
                    Console.WriteLine("Введіть ім'я резюме для перегляду деталей:");
                    string resumeNameToView = Console.ReadLine();
                    dataManager.DisplayResumeDetails(resumeNameToView);
                    break;
                case 13:
                    Environment.Exit(0);
                    break;
                case 14:
                    while (true)
                    {
                        SecondMenu:
                        Console.WriteLine("\nОберіть опцію:");
                        Console.WriteLine("1. Додати безробітного");
                        Console.WriteLine("2. Видалити безробітного");
                        Console.WriteLine("3. Оновити дані безробітного");
                        Console.WriteLine("4. Переглянути дані конкретного безробітного");
                        Console.WriteLine("5. Переглянути список всіх безробітних");
                        Console.WriteLine("6. Відсортувати список всіх безробітних за іменем");
                        Console.WriteLine("7. Відсортувати список всіх безробітних за прізвищем");
                        Console.WriteLine("8. Попередня сторінка");
                        Console.WriteLine("9. Наступна сторінка");

                        int choices;
                        if (!int.TryParse(Console.ReadLine(), out choices))
                        {
                            Console.WriteLine("Неправильне введення. Будь ласка, введіть число.");
                            continue;
                        }

                        switch (choices)
                        {
                            case 1:
                                AddUnemployed(Managers);
                                break;
                            case 2:
                                RemoveUnemployed(Managers);
                                ; break;
                            case 3:
                                UpdateUnemployed(Managers);
                                break;
                            case 4:
                                ViewUnemployedDetails(Managers);
                                break;
                            case 5:
                                Managers.DisplayAllUnemployeds();
                                break;
                            case 6:
                                Managers.SortUnemployedsByName();
                                break;
                            case 7:
                                Managers.SortUnemployedsByLastName();
                                break;
                            case 8:
                                goto FirstMenu;
                                break;
                            case 9:
                                while (true)
                                {
                                   ThrirdMenu:
                                    Console.WriteLine("\nОберіть опцію:");
                                    Console.WriteLine("1. Додати замовника");
                                    Console.WriteLine("2. Видалити замовника");
                                    Console.WriteLine("3. Оновити дані замовника");
                                    Console.WriteLine("4. Переглянути дані конкретного замовника");
                                    Console.WriteLine("5. Переглянути список всіх замовників");
                                    Console.WriteLine("6. Відсортувати список замовників за іменем");
                                    Console.WriteLine("7. Відсортувати список замовників за прізвищем");
                                    Console.WriteLine("8. Попередня сторінка");
                                    Console.WriteLine("9. Наступна сторінка");


                                    int option;
                                    if (!int.TryParse(Console.ReadLine(), out option))
                                    {
                                        Console.WriteLine("Невірний ввід. Будь ласка, введіть числове значення.");
                                        continue;
                                    }

                                    switch (option)
                                    {
                                        case 1:
                                            AddCustomer(customerManager);
                                            break;
                                        case 2:
                                            RemoveCustomer(customerManager);
                                            break;
                                        case 3:
                                            UpdateCustomer(customerManager);
                                            break;
                                        case 4:
                                            DisplayCustomerDetails(customerManager);
                                            break;
                                        case 5:
                                            customerManager.DisplayAllCustomers();
                                            break;
                                        case 6:
                                            customerManager.SortCustomersByName();
                                            break;
                                        case 7:
                                            customerManager.SortCustomersByLastName();
                                            break;
                                        case 8:
                                            goto SecondMenu;
                                            break;
                                        case 9:
                                            while (true)
                                            {
                                                FourMenu:
                                                Console.WriteLine("\nОберіть опцію:");
                                                Console.WriteLine("1. Пошук вакансій");
                                                Console.WriteLine("2. Пошук резюме");
                                                Console.WriteLine("3. Пошук безробітних");
                                                Console.WriteLine("4. Попередня сторінка");
                                                Console.WriteLine("5. Вихід");

                                                string options = Console.ReadLine();

                                                switch (options)
                                                {
                                                    case "1":
                                                        Console.WriteLine("Введіть ключове слово для пошуку вакансій:");
                                                        string keywordVacancy = Console.ReadLine();
                                                        dataManager.SearchVacancies(keywordVacancy);
                                                        break;
                                                    case "2":
                                                        Console.WriteLine("Введіть ключове слово для пошуку резюме:");
                                                        string keywordResume = Console.ReadLine();
                                                        dataManager.SearchResumes(keywordResume);
                                                        break;
                                                    case "3":
                                                        Console.WriteLine("Введіть ключове слово для пошуку безробітних:");
                                                        string keywordUnemployed = Console.ReadLine();
                                                        Managers.SearchUnemployeds(keywordUnemployed);
                                                        break;
                                                    case "4":
                                                        goto ThrirdMenu;
                                                        break;
                                                    case "5":
                                                        Environment.Exit(0);
                                                        break;
                                                    default:
                                                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                                                        break;
                                                }
                                            }
                                            break;

                                        default:
                                            Console.WriteLine("Неправильний вибір. Будь ласка, виберіть число від 1 до 8.");
                                            break;

                                    }
                                }
                                break;
                            default:
                                Console.WriteLine("Неправильний вибір. Будь ласка, виберіть число від 1 до 8.");
                                break;
                        }
                    }
                default:
                    Console.WriteLine("Неправильний вибір. Будь ласка, виберіть число від 1 до 8.");
                    break;
            }
        }
        static void AddCustomer(CustomerManager customerManager)
        {
            Console.WriteLine("Введіть ім'я замовника:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введіть прізвище замовника:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введіть назву компанії замовника:");
            string company = Console.ReadLine();
            Console.WriteLine("Введіть електронну пошту замовника:");
            string email = Console.ReadLine();
            Console.WriteLine("Введіть телефон замовника:");
            string phone = Console.ReadLine();

            customerManager.AddCustomer(new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Company = company,
                Email = email,
                Phone = phone
            });
            Console.WriteLine("Замовника успішно додано.");
        }

        static void RemoveCustomer(CustomerManager customerManager)
        {
            Console.WriteLine("Введіть ім'я замовника, якого потрібно видалити:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введіть прізвище замовника, якого потрібно видалити:");
            string lastName = Console.ReadLine();

            customerManager.RemoveCustomer(firstName, lastName);
            Console.WriteLine("Замовника успішно видалено.");
        }

        static void UpdateCustomer(CustomerManager customerManager)
        {
            Console.WriteLine("Введіть ім'я замовника для оновлення:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введіть прізвище замовника для оновлення:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введіть нове ім'я замовника:");
            string updatedFirstName = Console.ReadLine();
            Console.WriteLine("Введіть нове прізвище замовника:");
            string updatedLastName = Console.ReadLine();
            Console.WriteLine("Введіть нову назву компанії замовника:");
            string updatedCompany = Console.ReadLine();
            Console.WriteLine("Введіть нову електронну пошту замовника:");
            string updatedEmail = Console.ReadLine();
            Console.WriteLine("Введіть новий телефон замовника:");
            string updatedPhone = Console.ReadLine();

            customerManager.UpdateCustomer(firstName, lastName, new Customer
            {
                FirstName = updatedFirstName,
                LastName = updatedLastName,
                Company = updatedCompany,
                Email = updatedEmail,
                Phone = updatedPhone
            });
            Console.WriteLine("Дані замовника успішно оновлено.");
        }

        static void DisplayCustomerDetails(CustomerManager customerManager)
        {
            Console.WriteLine("Введіть ім'я замовника, чиї дані ви хочете переглянути:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введіть прізвище замовника, чиї дані ви хочете переглянути:");
            string lastName = Console.ReadLine();

            customerManager.DisplayCustomerDetails(firstName, lastName);
        }

        static void AddUnemployed(Manager Manager)
        {
            Console.WriteLine("Введіть ім'я безробітного:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введіть прізвище безробітного:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введіть вік безробітного:");
            int age;
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Неправильне введення віку.");
                return;
            }
            Console.WriteLine("Введіть освіту безробітного:");
            string education = Console.ReadLine();
            Console.WriteLine("Введіть попередню роботу безробітного:");
            string previousJob = Console.ReadLine();

            Manager.AddUnemployed(new Unemployed
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Education = education,
                PreviousJob = previousJob
            });
            Console.WriteLine("Безробітний успішно доданий.");
        }

        static void RemoveUnemployed(Manager Manager)
        {
            Console.WriteLine("Введіть ім'я безробітного для видалення:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введіть прізвище безробітного для видалення:");
            string lastName = Console.ReadLine();
            Manager.RemoveUnemployed(firstName, lastName);
            Console.WriteLine("Безробітний успішно видалений.");
        }

        static void UpdateUnemployed(Manager Manager)
        {
            Console.WriteLine("Введіть ім'я безробітного для оновлення:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введіть прізвище безробітного для оновлення:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введіть нове ім'я безробітного:");
            string updatedFirstName = Console.ReadLine();
            Console.WriteLine("Введіть нове прізвище безробітного:");
            string updatedLastName = Console.ReadLine();
            Console.WriteLine("Введіть новий вік безробітного:");
            int updatedAge;
            if (!int.TryParse(Console.ReadLine(), out updatedAge))
            {
                Console.WriteLine("Неправильне введення віку.");
                return;
            }
            Console.WriteLine("Введіть нову освіту безробітного:");
            string updatedEducation = Console.ReadLine();
            Console.WriteLine("Введіть нову попередню роботу безробітного:");
            string updatedPreviousJob = Console.ReadLine();

            Manager.UpdateUnemployed(firstName, lastName, new Unemployed
            {
                FirstName = updatedFirstName,
                LastName = updatedLastName,
                Age = updatedAge,
                Education = updatedEducation,
                PreviousJob = updatedPreviousJob
            });
            Console.WriteLine("Дані безробітного успішно оновлено.");
        }

        static void ViewUnemployedDetails(Manager Manager)
        {
            Console.WriteLine("Введіть ім'я безробітного для перегляду деталей:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введіть прізвище безробітного для перегляду деталей:");
            string lastName = Console.ReadLine();
            Manager.DisplayUnemployedDetails(firstName, lastName);
        }
    }
}

        





























