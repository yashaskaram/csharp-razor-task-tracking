# Tasks

## Creating the Layout and Navigation

### Creating the Index Page
Inside the `Pages` folder of the solution, create a new Razor Page called `Index`. 
Update this page to contain an `h1` HTML tag with the text `All Tasks`. Note creating a Razor Page `Index` will create a file called `Index.cshtml`.

### Creating the CreateTask Page
Inside the `Pages` folder of the solution, create a new Razor page called `CreateTask`.  
Update this page to contain an `h1` tag with the text `New Task`.

### Updating the Navigation Links
In the `Shared/_Layout.cshtml` file, locate the `a` tag that contains the text `Home` and add an `asp-page` tag helper with a value of `Index`.  
Locate the `a` tag that contains the text `New Task` and add an `asp-page` tag helper with a value of `CreateTask`.

### Rendering Content in the Layout File
Next, locate the `main` tag and replace the comment inside of it with the `@Renderbody()` directive.

### Adding a Friendly Route
In the `CreateTask.cshtml` page, add a more user-friendly route template by updating the `@page` directive to read `@page "/create-task"`.

## Building the Task Form

### Creating the Task Class
At the root of the Tasker project, add a new class called Task. Inside the new Task class, add the following public properties:
* An `int` called Id
* A `string` called Title
* A `string` called Description
* An `int` called Priority

### Adding the Task to the CreateTask Page
Inside the `CreateTask.cshtml.cs` class, add a public property with a type of `Task` called NewTask.  
Add the `BindProperty` attribute above this property.

### Creating the Form
Inside the `CreateTask.cshtml` Razor markup file, create a new opening and closing `form` tag.  
Add the `asp-page` tag helper to the `form` tag with a value of "CreateTask" to ensure the form posts to the current page.
Add the `method="post"` attribute to the `form` tag to ensure the form submits correctly.

### Creating the Form Inputs
Inside of the `form` tag, add an opening and closing `label` tag with the text `Title`.  The `label` should also include an `asp-for` tag helper with a value of `NewTask.Title`.
Below the `label` tag, add an `input` tag with a `type="text"` attribute.  The `input` should include an `asp-for` tag helper with a value of `NewTask.Title`.
Repeat this process to create `label` and `input` tags for the Description and Priority of the NewTask property.

### Completing the Form
Inside of the `form` tag, add an `input` tag with a `type="submit"` attribute so that the form can be submitted.

### Creating the Form Handler Method
Inside of the `CreateTask.cshtml.cs` class, add a new public method called OnPost that returns an `IActionResult`.  
In the body of the method return a `RedirectToPage` and pass in a value of `Index`.

## Saving Data to the Database

### Creating the Database Context Class
At the root of the Tasker project, add a new class called ApplicationDbContext that inherits from the DbContext class.  
Inside this class create a constructor that accepts a DbContextOptions parameter called options, and passes that parameter into the base class constructor as well.

### Creating the Tasks Data Set
Create a public DbSet property called Tasks with a type parameter of Task.  

### Registering the Database Context
In the startup.cs file, register the ApplicationDbContext class as a singleton on the services collection.  Pass in an option to use the InMemoryDatabase.

### Injecting the Database Context
Inside the CreateTask class, inject the ApplicationDbContext class into the constructor as a parameter called context.  
Inside the constructor, save the context parameter to a read only class field called _context.

### Saving the New Task
Update the OnPost method to use the _context field to add the new Task to the Tasks data set.
Call save changes on _context to persist the data.

## Displaying Data on the Home Page

### Injecting the Database Context
Update the Index class to include a constructor that injects the ApplicationDbContext as a parameter called context.
Store the context parameter in a readonly class field called _context.

### Creating the Tasks Property
Create a List property with a type of Task called Tasks to a hold the list of tasks that will display.

### Retrieving the Tasks
Inside of the OnGet method, use the _context to retrieve all of the tasks and store them in the Tasks property.

### Filtering the Tasks
Inside of the OnGet method, using the linq orderby method to order the tasks by their priority.

### Displaying the Tasks
Inside of the Index Razor markup, add an opening and closing 'table' tag.
Inside the table tags, add a foreach loop that iterates through the Tasks property.  
Inside the loop, create a new 'tr' tag, and then print out each task property in a 'td' tag.


## Adding Validation to the Create Form

### Making Task Properties Required
Inside the Task class, add the '[Required]' attribute above the Title, Description, and PriorityLevel properties.

### Controlling the Description Length
Add a MinLength attribute above the Description property and pass in a value of 10.

### Enforcing the Priority Range
Add a Range attribute to the PriorityLevel property with a minimum value of 1 and a maximum of 5.

### Displaying the Validation Errors
Inside the CreateTask Razor markup, create an empty 'div' tag above the existing 'form' tag.
Add the 'asp-validation-summary' tag helper to the empty div to display any validation errors.

### Checking the Model State
Inside the OnPost method of the CreateTask class, add a conditional to check if the ModelState is valid.  
If the data is not valid, return Page() to reload the page with errors.
If the data is valid, redirect to the home page.


