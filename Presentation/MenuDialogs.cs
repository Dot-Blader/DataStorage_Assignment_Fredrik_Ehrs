using Business.Models;
using Business.Services;
using System.ComponentModel.Design;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Presentation;

public class MenuDialogs(CustomerService customerService, UserService userService, ProductService productService, StatusTypeService statusService, ProjectService projectService)
{
    private readonly CustomerService _customerService = customerService;
    private readonly UserService _userService = userService;
    private readonly ProductService _productService = productService;
    private readonly StatusTypeService _statusService = statusService;
    private readonly ProjectService _projectService = projectService;


    public async Task Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Type the number corresponding to the collection of services you want to access.");
            Console.WriteLine("1. Customer Services");
            Console.WriteLine("2. User Services");
            Console.WriteLine("3. Product Services");
            Console.WriteLine("4. Status Type Services");
            Console.WriteLine("5. Project Services");
            Console.WriteLine("6. Quit");
            string input = Console.ReadLine()!;
            if (input == "1")
            {
                CustomerDialogs();
            }
            else if (input == "2")
            {
                UserDialogs();
            }
            else if (input == "3")
            {
                ProductDialogs();
            }
            else if (input == "4")
            {
                StatusDialogs();
            }
            else if (input == "5")
            {
                ProjectDialogs();
            }
            else if (input == "6")
            {
                break;
            }
        }
    }

    public async void CustomerDialogs()
    {
        Console.Clear();
        Console.WriteLine("Type the number corresponding to the service you want to use.");
        Console.WriteLine("1. Create new Customer");
        Console.WriteLine("2. Edit existing Customer");
        Console.WriteLine("3. View all Customers");
        string input = Console.ReadLine()!;
        if (input == "1")
        {
            Console.Clear();
            Console.WriteLine("Input Customer Name");
            string input2 = Console.ReadLine()!;
            CustomerRegistrationForm form = new() { CustomerName = input2 };
            await _customerService.CreateCustomerAsync(form);
        }
        else if (input == "2")
        {
            Console.Clear();
            Console.WriteLine("Input Customer Name");
            string input2 = Console.ReadLine()!;
            Customer? customer = await _customerService.GetCustomerByCustomerNameAsync(input2);
            Console.WriteLine("Input New Name");
            string input3 = Console.ReadLine()!;
            customer!.CustomerName = input3;
            bool update = await _customerService.UpdateCustomerAsync(customer);
            if (update)
            {
                Console.WriteLine("Success");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failed");
                Console.ReadKey();
            }
        }
        else if (input == "3")
        {
            Console.Clear();
            IEnumerable<Customer?> list = await _customerService.GetCustomersAsync();
            foreach (Customer? customer in list)
            {
                Console.WriteLine(customer!.Id.ToString() + ". " + customer.CustomerName);
            }
            Console.ReadKey();
        }
    }
    public async void UserDialogs()
    {
        Console.Clear();
        Console.WriteLine("Type the number corresponding to the service you want to use.");
        Console.WriteLine("1. Create new User");
        Console.WriteLine("2. Edit existing User");
        Console.WriteLine("3. View all Users");
        string input = Console.ReadLine()!;
        if (input == "1")
        {
            Console.Clear();
            Console.WriteLine("Input First Name");
            string firstName = Console.ReadLine()!;
            Console.WriteLine("Input Last Name");
            string lastName = Console.ReadLine()!;
            Console.WriteLine("Input Email");
            string email = Console.ReadLine()!;
            UserRegistrationForm form = new() { FirstName = firstName, LastName = lastName, Email = email };
            await _userService.CreateUserAsync(form);
        }
        else if (input == "2")
        {
            Console.Clear();
            Console.WriteLine("Input First Name");
            string firstName = Console.ReadLine()!;
            Console.WriteLine("Input Last Name");
            string lastName = Console.ReadLine()!;
            User? user = await _userService.GetUserByNameAsync(firstName, lastName);
            Console.WriteLine("Input New First Name");
            string firstName2 = Console.ReadLine()!;
            Console.WriteLine("Input New Last Name");
            string lastName2 = Console.ReadLine()!;
            user!.FirstName = firstName2;
            user!.LastName = lastName2;
            bool update = await _userService.UpdateUserAsync(user);
            if (update)
            {
                Console.WriteLine("Success");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failed");
                Console.ReadKey();
            }
        }
        else if (input == "3")
        {
            Console.Clear();
            IEnumerable<User?> list = await _userService.GetUsersAsync();
            foreach (User? user in list)
            {
                Console.WriteLine($"{user!.Id.ToString()}. {user!.FirstName} {user!.LastName}");
            }
            Console.ReadKey();
        }
    }
    public async void ProductDialogs()
    {
        Console.Clear();
        Console.WriteLine("Type the number corresponding to the service you want to use.");
        Console.WriteLine("1. Create new Product");
        Console.WriteLine("2. Edit existing Product");
        Console.WriteLine("3. View all Products");
        string input = Console.ReadLine()!;
        if (input == "1")
        {
            Console.Clear();
            Console.WriteLine("Input Product Name");
            string input2 = Console.ReadLine()!;
            Console.WriteLine("Input Price");
            string input3 = Console.ReadLine()!;
            ProductRegistrationForm form = new() { ProductName = input2, Price = Decimal.Parse(input3) };
            await _productService.CreateProductAsync(form);
        }
        else if (input == "2")
        {
            Console.Clear();
            Console.WriteLine("Input Product Name");
            string input2 = Console.ReadLine()!;
            Product? product = await _productService.GetProductByProductNameAsync(input2);
            Console.WriteLine("Input New Name");
            string input3 = Console.ReadLine()!;
            Console.WriteLine("Input New Price");
            string input4 = Console.ReadLine()!;
            product!.ProductName = input3;
            product!.Price = Decimal.Parse(input4);
            bool update = await _productService.UpdateProductAsync(product);
            if (update)
            {
                Console.WriteLine("Success");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failed");
                Console.ReadKey();
            }
        }
        else if (input == "3")
        {
            Console.Clear();
            IEnumerable<Product?> list = await _productService.GetProductsAsync();
            foreach (Product? product in list)
            {
                Console.WriteLine($"{product!.Id.ToString()}. {product!.ProductName}, {product!.Price}kr/h");
            }
            Console.ReadKey();
        }
    }
    public async void StatusDialogs()
    {
        Console.Clear();
        Console.WriteLine("Type the number corresponding to the service you want to use.");
        Console.WriteLine("1. Create new Status Type");
        Console.WriteLine("2. Edit existing Status Type");
        Console.WriteLine("3. View all Status Types");
        string input = Console.ReadLine()!;
        if (input == "1")
        {
            Console.Clear();
            Console.WriteLine("Input Status Type Name");
            string input2 = Console.ReadLine()!;
            StatusTypeRegForm form = new() { StatusName = input2 };
            await _statusService.CreateStatusTypeAsync(form);
        }
        else if (input == "2")
        {
            Console.Clear();
            Console.WriteLine("Input Status Type Name");
            string input2 = Console.ReadLine()!;
            StatusType? statusType = await _statusService.GetStatusTypeByStatusNameAsync(input2);
            Console.WriteLine("Input New Name");
            string input3 = Console.ReadLine()!;
            statusType!.StatusName = input3;
            bool update = await _statusService.UpdateStatusTypeAsync(statusType);
            if (update)
            {
                Console.WriteLine("Success");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failed");
                Console.ReadKey();
            }
        }
        else if (input == "3")
        {
            Console.Clear();
            IEnumerable<StatusType?> list = await _statusService.GetStatusTypesAsync();
            foreach (StatusType? statusType in list)
            {
                Console.WriteLine(statusType!.Id.ToString() + ". " + statusType!.StatusName);
            }
            Console.ReadKey();
        }
    }
    public async void ProjectDialogs()
    {
        Console.Clear();
        Console.WriteLine("Type the number corresponding to the service you want to use.");
        Console.WriteLine("1. Create new Project");
        Console.WriteLine("2. Edit existing Project");
        Console.WriteLine("3. View all Projects");
        string input = Console.ReadLine()!;
        if (input == "1")
        {
            Console.Clear();
            Console.WriteLine("Input Project Title");
            string title = Console.ReadLine()!;
            Console.WriteLine("Input Description");
            string desc = Console.ReadLine()!;
            Console.WriteLine("Input Start Date like: 12 Juni 2025");
            var cultureInfo = new CultureInfo("de-DE");
            string start = Console.ReadLine()!;
            DateTime startDate = DateTime.Parse(start, cultureInfo);
            Console.WriteLine("Input End Date like: 12 Juni 2025");
            string end = Console.ReadLine()!;
            DateTime endDate = DateTime.Parse(end, cultureInfo);
            Console.WriteLine("Input Customer ID");
            string customer = Console.ReadLine()!;
            Console.WriteLine("Input Status Type ID");
            string status = Console.ReadLine()!;
            Console.WriteLine("Input User ID");
            string user = Console.ReadLine()!;
            Console.WriteLine("Input Product ID");
            string product = Console.ReadLine()!;
            ProjectRegistrationForm form = new() { Title = title, Description = desc, StartDate = startDate, EndDate = endDate,
            CustomerId = customer, StatusId = status, UserId = user, ProductId = product};
            await _projectService.CreateProjectAsync(form);
        }
        else if (input == "2")
        {
            Console.Clear();
            Console.WriteLine("Input Project Title");
            string input2 = Console.ReadLine()!;
            Project? project = await _projectService.GetProjectByTitleAsync(input2);
            Console.WriteLine("Input New Project Title");
            string title = Console.ReadLine()!;
            Console.WriteLine("Input New Description");
            string desc = Console.ReadLine()!;
            Console.WriteLine("Input New Start Date like: 12 Juni 2025");
            var cultureInfo = new CultureInfo("de-DE");
            string start = Console.ReadLine()!;
            DateTime startDate = DateTime.Parse(start, cultureInfo);
            Console.WriteLine("Input New End Date like: 12 Juni 2025");
            string end = Console.ReadLine()!;
            DateTime endDate = DateTime.Parse(end, cultureInfo);
            Console.WriteLine("Input New Customer ID");
            string customer = Console.ReadLine()!;
            Console.WriteLine("Input New Status Type ID");
            string status = Console.ReadLine()!;
            Console.WriteLine("Input New User ID");
            string user = Console.ReadLine()!;
            Console.WriteLine("Input New Product ID");
            string product = Console.ReadLine()!;
            project!.Title = title;
            project!.Description = desc;
            project!.StartDate = startDate;
            project!.EndDate = endDate;
            project!.CustomerId = customer;
            project!.StatusId = status;
            project!.UserId = user;
            project!.ProductId = product;
            bool update = await _projectService.UpdateProjectAsync(project);
            if (update)
            {
                Console.WriteLine("Success");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failed");
                Console.ReadKey();
            }
        }
        else if (input == "3")
        {
            Console.Clear();
            IEnumerable<Project?> list = await _projectService.GetProjectsAsync();
            foreach (Project? project in list)
            {
                Console.WriteLine($"ID: {project!.Id.ToString()}. { project.Title}, {project.Description}. Start Date: {project.StartDate}, End Date: {project.EndDate}.");
                Console.WriteLine($"- Customer ID: {project.CustomerId}, Status Type ID: {project.StatusId}, User ID: {project.UserId}, Product ID: {project.ProductId}.");
            }
            Console.ReadKey();
        }
    }
}
