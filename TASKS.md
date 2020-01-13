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
At the root of the Tasker project, create a new class called `ApplicationDbContext` that inherits from the `DbContext` class.  
Inside this class create a constructor that accepts a `DbContextOptions` parameter called `options`, and passes that parameter into the base class constructor as well.
(Note: This can be done by adding `: base(options)` after the constructor method signature)

### Creating the Tasks Data Set
Create a `public` property named `Tasks` with a type of `DbSet<Task>`.  

### Registering the Database Context
In the `startup.cs` file, locate the `ConfigureServices` method and add the `ApplicationDbContext` class to the `services` collection by calling `AddDbContext<ApplicationDbContext>`.
Provide the argument `options => options.UseInMemoryDatabase("Tasker")` to the AddDbContext method.

### Injecting the Database Context
Inside the `CreateTask.cshtml.cs` class, create a constructor and inject the `ApplicationDbContext` class as a parameter called context.  
Inside the constructor method body, save the `context` parameter to a `readonly` class field called `_context`.

### Saving the New Task
Update the `OnPost` method to use the `_context` field to add the `newTask` to the `_context.Tasks`.
Remember to call `SaveChanges()` on `_context` to persist adding the `newTask`.

## Displaying Data on the Home Page

### Injecting the Database Context
Update the `Index.cshtml.cs` class to include a constructor that injects the `ApplicationDbContext` as a parameter called `context`.
Above the constructor, add a private class field called `_context` of type `ApplicationDbContext`.
Inside the constructor, assign the `context` parameter to the `_context` field so it can be used throughout the class.

### Creating the Tasks Property
At the top of the class, create a `public` property called `Tasks` with a type `List<Task>` to a hold the list of tasks that will display.

### Retrieving the Tasks
Inside of the `OnGet` method, use `_context.Tasks` to retrieve all of the tasks and assign them to the Tasks property.

### Filtering the Tasks
Append the linq `.OrderBy(x => x.Priority)` method after `_context.Tasks` to order the tasks by their priority.

### Displaying the Tasks
Inside of the `Index.cshtml` Razor markup file, add an opening and closing 'table' tag.
Inside the table create a foreach loop to iterate through the `Tasks` using an iteration variable called task.
Inside the loop, create a new 'tr' tag, and then print out each `task` property in a 'td' tag.  
(Note: The table columns should display in the order of: Id, Title, Description, and Priority.)


## Adding Validation to the Create Form

### Making Task Properties Required
Inside the `Task.cs` class, add the `[Required]` attribute above the Title, Description, and Priority properties.

### Controlling the Description Length
Add a `[MinLength]` attribute above the `Description` property and pass in a value of 10.

### Enforcing the Priority Range
Add a `[Range]` attribute above the `PriorityLevel` property and pass in a minimum value of 1 and a maximum of 5.

### Displaying the Validation Errors
Inside the `CreateTask.cshtml` markup, create an empty `div` tag above the existing `form` tag.
Add the `asp-validation-summary` tag helper with a value of `All` to the empty div to display any validation errors.

### Checking the Model State
At the top of the OnPost method of the `CreateTask.cshtml.cs` class, add a conditional to check if the `ModelState` is _not_ valid.  
Inside the conditional brackets, return `page()` to reload the invalid form and display the validation errors.