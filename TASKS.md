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


