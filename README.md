# Ecommerce ASP.NET Core MVC

An Ecommerce web application built using ASP.NET Core MVC, Entity Framework Core, SQL Server, and Bootstrap.

The project contains two main areas:

- **User Area** – browse categories, products, and product details.
- **Admin Area** – manage categories and products.

---

## Features

### User Area

- Browse active categories
- View products by category
- View product details
- Display product image, price, availability, rating, and description
- Responsive store interface

### Admin Area

- View categories
- Create categories
- Edit categories
- Delete categories
- View products
- Create products
- Upload product images
- Edit product information
- Replace product images
- Delete products and their stored images

---

## Admin Panel

To access the Admin Dashboard, run the application and navigate to:

```text
/Admin/Home/Index
```

Example:

```text
https://localhost:7093/Admin/Home/Index
```

> The port number may be different depending on your local environment.

The customer-facing store is available from the application home page:

```text
/
```

---

## Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Razor Views
- Mapster
- Bootstrap
- Bootstrap Icons
- HTML
- CSS

---

## Project Structure

```text
Areas
├── Admin
│   ├── Controllers
│   └── Views
│
└── User
    ├── Controllers
    └── Views

Data
Models
ViewModels
wwwroot
```

The **Admin Area** is responsible for managing store data.

The **User Area** is responsible for displaying the store to customers.

---

## Database

The application uses SQL Server with Entity Framework Core.

After configuring the database connection, apply the migrations using:

```bash
dotnet ef database update
```

---

## Run the Project

Clone the repository:

```bash
git clone https://github.com/SewarAslan/mvcEcommerce
```

Move into the project directory:

```bash
cd Ecommerce
```

Restore project dependencies:

```bash
dotnet restore
```

Apply database migrations:

```bash
dotnet ef database update
```

Run the application:

```bash
dotnet run
```

Then open the localhost URL displayed in the terminal.

---

## Product Management

Product images are stored in:

```text
wwwroot/images/products
```

When an admin replaces a product image, the previous image is removed.

When a product is deleted, its stored image is also removed.

---

## User Navigation

Users can:

1. Browse available categories.
2. Select a category to view its products.
3. Open a product to view its details.
4. View product price, description, rating, stock availability, and image.

---

## Admin Navigation

Admins can access the dashboard through:

```text
/Admin/Home/Index
```

From the Admin Dashboard, they can manage:

- Categories
- Products
- Product images
- Product status
- Product inventory

---

## Author

**Sewar Aslan**